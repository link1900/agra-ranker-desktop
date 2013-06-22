package validation

import validation.EvaluationResult

case class FieldValidation[T](resource: String, field: String, evaluation : T => EvaluationResults) {
	def evaluate(subject : T) : EvaluationResults = {
		val result = evaluation(subject)
		EvaluationResults(result.evaluationResults.map(subEval => remapFieldNames(subEval)))
	}

	def remapFieldNames(subEval : EvaluationResult) : EvaluationResult = {
		val subField = if (!subEval.field.isEmpty) "."+subEval.field else ""
		subEval.copy(resource=this.resource,field=this.field+subField)
	}
}
