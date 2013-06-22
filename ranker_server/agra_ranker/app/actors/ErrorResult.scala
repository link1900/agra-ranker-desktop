package actors

case class ErrorResult(msg: String)

object ErrorResult{
  val unknownMessage = ErrorResult("unknown.message")
}