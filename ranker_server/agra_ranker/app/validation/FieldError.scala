package validation

case class FieldError(resource: String, field: String, message: String, messageProperties : List[String] = Nil){

}