package validation

import play.api.mvc.PlainResult
import play.api.mvc.Results
import play.api.http.ContentTypes
import json.Jsonable


case class Response(message : String, status: ResponseStatus, errors : Option[Seq[FieldError]] = Nil) extends Jsonable{

  def asPlayResult : PlainResult = {
    this.status match {
      case ResponseStatus.Ok200 => Results.Ok(this.asJson).as(ContentTypes.JSON)
      case ResponseStatus.BadRequest400 => Results.BadRequest(this.asJson).as(ContentTypes.JSON)
      case ResponseStatus.actionNotFound404 => Results.NotFound(this.asJson).as(ContentTypes.JSON)
      case ResponseStatus.InternalServerError500 => Results.InternalServerError(this.asJson).as(ContentTypes.JSON)
    }
  }

  def valid : Boolean = {
    status == ResponseStatus.Ok200
  }

}

object Response {
  val success = Response("success", ResponseStatus.Ok200)
  val failedValidation = Response("invalid.validation", ResponseStatus.BadRequest400)
  val invalidRequest = Response("invalid.request", ResponseStatus.BadRequest400)
  val requestBadJson = Response("invalid.json.request", ResponseStatus.BadRequest400)
  val invalidAction = Response("unknown.action",ResponseStatus.BadRequest400)
  val unknownException = Response("server.exception",ResponseStatus.InternalServerError500)
  def invalidValidation(someFieldErrors : Seq[FieldError]) : Response = {
    Response("invalid.validation",ResponseStatus.BadRequest400,Some(someFieldErrors))
  }

  def failedValidation(someFieldErrors : FieldError) : Response = {
    Response("validation.failed",ResponseStatus.BadRequest400,Some(someFieldErrors :: Nil))
  }
}

case class ResponseStatus(code : String){}

object ResponseStatus{
  val Ok200 = ResponseStatus("200")
  val BadRequest400 = ResponseStatus("400")
  val actionNotFound404 = ResponseStatus("404")
  val InternalServerError500 = ResponseStatus("500")
}