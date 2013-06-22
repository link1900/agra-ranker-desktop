import play.api.mvc.{Result, RequestHeader}
import play.api._
import Play.current
import validation.Response

object Global extends GlobalSettings {
  override def onStart(app: Application) {
    Logger.info("Play Server has started")
    Logger.info(appName)
  }

  override def onStop(app: Application) {
    Logger.info("Play Server has stopped")
  }

  override def onBadRequest(request: RequestHeader, error: String): Result = {
    Response.invalidRequest.asPlayResult
  }

  override def onHandlerNotFound(request: RequestHeader): Result = {
    Response.invalidAction.asPlayResult
  }

  def appName : String = {
    current.configuration.getString("app.name").getOrElse("")
  }

  def hostUrl : String = {
    val url = current.configuration.getString("app.host.url").getOrElse("")
    val port =  current.configuration.getString("app.host.port").getOrElse("")
    val urlAndPort = {if (!port.isEmpty)
      url+":"+port
    else
      url}
    prefixHost(urlAndPort)
  }

  def prefixHost(host :String, secure: Boolean = false) : String =  {
    "http" + (if (secure) "s" else "") + "://" + host
  }

  def nodeName : Option[String] = {
    current.configuration.getString("app.node.name")
  }

  def smptDefaultFromAddress : Option[String] = {
    current.configuration.getString("smtp.from")
  }
}
