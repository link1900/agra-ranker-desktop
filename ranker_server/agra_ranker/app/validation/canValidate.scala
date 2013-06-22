package validation

import validation.FieldValidation

/**
 * Apply to an Object so it can be determined as valid or not
 */
trait canValidate {
	val validations : List[FieldValidation[this.type]] = Nil

	/**
	 * Validate an entity by the list of validators.
	 * @return
	 */
	def validate : EvaluationResults = {
		internalValidation(this.validations)
	}

	def validateFields(fieldsToValidate : List[String]) : EvaluationResults = {
		val partialValidations : List[FieldValidation[this.type]] = this.validations.filter({validator => fieldsToValidate.contains(validator.field)})
		internalValidation(partialValidations)
	}

	private def internalValidation(someValidations : List[FieldValidation[this.type]]) : EvaluationResults = {
		someValidations.map(_.evaluate(this)).foldLeft(EvaluationResults.valid)((a,b) => a+b)
	}

	/**
	 * Validate an entity by the set list of validators.
	 * @return Returns an none if it is valid
	 */
	def validateAsOption() : Option[EvaluationResults] = {
		val result = this.validate
		if (result.valid)
			None
		else
			Some(result)
	}

	def createFieldValidation(fieldName : String, validationFunction : this.type => EvaluationResults) : FieldValidation[this.type] = {
		FieldValidation[this.type](this.getClass.getSimpleName, fieldName, validationFunction)
	}
}
