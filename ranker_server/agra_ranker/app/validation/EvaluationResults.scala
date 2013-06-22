package validation

case class EvaluationResult(valid : Boolean, resource: String="",field:String="", messageKey: String="", messageProperties : List[String]=Nil){
}

case class EvaluationResults(evaluationResults : List[EvaluationResult]){

	def asFieldErrors : List[FieldError] ={
		evaluationResults.filter(_.valid==false).map(f => FieldError(f.resource,f.field,f.messageKey,f.messageProperties))
	}

	def asFieldErrors(givenResource : String, givenField : String) : List[FieldError] ={
		evaluationResults.filter(_.valid==false).map(f => FieldError(givenResource,givenField,f.messageKey,f.messageProperties))
	}

	def mapResultFields(newField : String) : EvaluationResults = {
		EvaluationResults(evaluationResults.map(f => f.copy(field=newField)))
	}

	def asBoolean : Boolean = valid

	def asResponse : Response = {
		val fieldErrors = this.asFieldErrors
		if (fieldErrors.size == 0)
			Response.success
		else
			Response.failedValidation(fieldErrors)
	}

	def + (ev1 : EvaluationResults) : EvaluationResults = {
		EvaluationResults(this.evaluationResults ::: ev1.evaluationResults)
	}

	def valid : Boolean = evaluationResults.filter(_.valid == false).size == 0

	def invalid = !this.valid
}

case class ValidationException(messageKey: String, messageProperties : List[String] = Nil) extends Exception(messageKey) {

	def asEvaluationResult : EvaluationResult = {
		EvaluationResult(valid=false, messageKey=this.messageKey,messageProperties=this.messageProperties)
	}

	def asEvaluationResults : EvaluationResults = {
		EvaluationResults(List(this.asEvaluationResult))
	}
}

object EvaluationResults{
	def invalidType : EvaluationResults = {
		invalid("validation.invalid.type")
	}

	def invalidException(e : Exception) : EvaluationResults = {
		invalid(e.toString)
	}

	def invalid(failureReason : String) : EvaluationResults = {
		EvaluationResults(List(EvaluationResult(valid = false, messageKey=failureReason)))
	}

	def invalid(failureReason : String, failureProperties : String) : EvaluationResults = {
		EvaluationResults(List(EvaluationResult(valid = false, messageKey=failureReason, messageProperties=List(failureProperties))))
	}

	def invalid(failureReason : String, failureProperties : List[String]) : EvaluationResults = {
		EvaluationResults(List(EvaluationResult(valid = false, messageKey=failureReason, messageProperties=failureProperties)))
	}

	def valid : EvaluationResults = EvaluationResults(List(EvaluationResult(true)))
}
