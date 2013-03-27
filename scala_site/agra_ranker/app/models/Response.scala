package models

import play.api.mvc.{PlainResult, Controller}
import models.FieldError
import models.Jsonable



case class Response(message : String, status: ResponseStatus, errors : Traversable[FieldError] = Nil) extends Jsonable{

  def asPlayResult : PlainResult = {
    this.status match {
      case ResponseStatus.Ok200 => Ok(this.asJson).as(JSON)
      case ResponseStatus.BadRequest400 => BadRequest(this.asJson).as(JSON)
      case ResponseStatus.actionNotFound404 => NotFound(this.asJson).as(JSON)
      case ResponseStatus.InternalServerError500 => InternalServerError(this.asJson).as(JSON)
    }
  }

  def valid : Boolean = {
    status == ResponseStatus.Ok200
  }

}

object Response {
  val success = Response("success", ResponseStatus.Ok200)
  val invalidRequest = Response("invalid.request", ResponseStatus.BadRequest400)
  val invalidAction = Response("unknown.action",ResponseStatus.BadRequest400)
  val unknownException = Response("server.exception",ResponseStatus.InternalServerError500)
}

case class ResponseStatus(code : String){}

object ResponseStatus{
  val Ok200 = ResponseStatus("200")
  val BadRequest400 = ResponseStatus("400")
  val actionNotFound404 = ResponseStatus("404")
  val InternalServerError500 = ResponseStatus("500")
}