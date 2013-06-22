package database

import com.mongodb.casbah.commons.MongoDBObject
import org.bson.types.ObjectId
import validation.ValidationException

trait Queryable {
	def queryBuilder(query: Option[String]) = {
		query match {
			case Some(queryString) =>
				val builder = MongoDBObject.newBuilder

				for(clause <- queryString.split("""\|""")) {
					val clauseElements = clause.split(":").toList
					val fieldType = queryMap.get(clauseElements(0))
					if (clauseElements.length == 2) { // base case, equality
						builder += parseSingleArgument(clauseElements(0),clauseElements(1), fieldType)
					} else if (clauseElements.length > 2) { // parse additional terms
						builder += parseManyArguments(clauseElements, fieldType)
					}
				}
				builder.result

			case None =>
				MongoDBObject()
		}
	}

	def parseSingleArgument(field: String, value : String, fieldType : Option[String]) : Tuple2[String, Any] = {
		fieldType match {
			case Some(x) if(x == "Double") =>
				field -> strToDouble(field, value)
			case Some(x) if(x == "Int") =>
				field -> strToInt(field, value)
			case Some(x) if(x == "String") =>
				field -> value
			case Some(x) if(x == "ObjectId") =>
				field -> strToObjectId(field, value)
			case _ =>
				throw ValidationException("non.queryable.field", List(field))
		}
	}

	def parseManyArguments(clauseElements : List[String], fieldType : Option[String]) : Tuple2[String, Any] = {
		if (clauseElements.length % 2 == 0)
			throw throw ValidationException("query.invalid.not.enough.arguments")
		val elementBuilder = MongoDBObject.newBuilder
		for (i <- 1 to clauseElements.length-1 by 2 ) {
			if (List("in","nin").contains(clauseElements(i))) {
				val inElements = clauseElements(i+1).split(",")

				fieldType match {
					case Some(x) if(x == "Double" && allowedClause(clauseElements(0), x, clauseElements(i))) =>
						elementBuilder += "$" + clauseElements(i) -> inElements.map(strToDouble(clauseElements(0), _))
					case Some(x) if(x == "Int" && allowedClause(clauseElements(0), x, clauseElements(i))) =>
						elementBuilder += "$" + clauseElements(i) -> inElements.map(strToInt(clauseElements(0), _))
					case Some(x) if(x == "String" && allowedClause(clauseElements(0), x, clauseElements(i))) =>
						elementBuilder += "$" + clauseElements(i) -> inElements
					case Some(x) if(x == "ObjectId" && allowedClause(clauseElements(0), x, clauseElements(i))) =>
						elementBuilder += "$" + clauseElements(i) -> inElements.map(strToObjectId(clauseElements(0), _))
					case _ =>
						throw throw ValidationException("non.queryable.field", List(clauseElements(0)))
				}
			} else if(List("like").contains(clauseElements(i))) {
				fieldType match {
					case Some(x) if(x == "String" && allowedClause(clauseElements(0), x, clauseElements(i))) =>
						return clauseElements(0) -> ("(?i)"+clauseElements(i+1)).r
					case _ =>
						parseSingleArgument(clauseElements(0),clauseElements(i+1), fieldType)
				}
			} else
				fieldType match {
					case Some(x) if(x == "Double" && allowedClause(clauseElements(0), x, clauseElements(i))) =>
						elementBuilder += "$" + clauseElements(i) -> strToDouble(clauseElements(0), clauseElements(i+1))
					case Some(x) if(x == "Int" && allowedClause(clauseElements(0), x, clauseElements(i))) =>
						elementBuilder += "$" + clauseElements(i) -> strToInt(clauseElements(0), clauseElements(i+1))
					case Some(x) if(x == "String" && allowedClause(clauseElements(0), x, clauseElements(i))) =>
						elementBuilder += "$" + clauseElements(i) -> clauseElements(i+1)
					case Some(x) if(x == "ObjectId" && allowedClause(clauseElements(0), x, clauseElements(i))) =>
						elementBuilder += "$" + clauseElements(i) -> strToObjectId(clauseElements(0), clauseElements(i+1))
					case _ =>
						throw ValidationException("non.queryable.field", List(clauseElements(0)))
				}
		}
		clauseElements(0) -> elementBuilder.result()
	}

	val queryMap = scala.collection.mutable.Map[String,String]()
	queryMap +=  ("_id" -> "ObjectId")
	val allowedDoubleClauses = List("gt","gte","lt","lte","ne","in","nin")
	val allowedIntClauses = List("gt","gte","lt","lte","ne","in","nin")
	val allowedStringClauses = List("gt","gte","lt","lte","ne","in","nin", "like")
	val allowedObjectIdClauses = List("in","nin")

	def strToDouble(field: String, valString: String) = {
		try { valString.toDouble }
		catch {
			case e: NumberFormatException =>
				throw throw ValidationException("query.field.not.double", List(field, valString))
		}
	}
	def strToInt(field: String, valString: String) = {
		try { valString.toInt }
		catch {
			case e: NumberFormatException =>
				throw throw ValidationException("query.field.not.int", List(field, valString))
		}
	}
	def strToObjectId(field: String, valString: String) = {
		try { new ObjectId(valString) }
		catch {
			case e: IllegalArgumentException =>
				throw throw ValidationException("query.field.not.objectId", List(field, valString))
		}
	}

	def allowedClause(fieldName: String, fieldType: String, clause: String) = {
		fieldType match {
			case "Double" => if(!allowedDoubleClauses.contains(clause))
				throw throw ValidationException("query.field.not.allowed.operation", List(fieldName, allowedDoubleClauses.toString(), clause))
			case "Int" => if(!allowedIntClauses.contains(clause))
				throw throw ValidationException("query.field.not.allowed.operation", List(fieldName, allowedDoubleClauses.toString(), clause))
			case "String" =>  if(!allowedStringClauses.contains(clause))
				throw throw ValidationException("query.field.not.allowed.operation", List(fieldName, allowedDoubleClauses.toString(), clause))
			case "ObjectId" =>    if(!allowedObjectIdClauses.contains(clause))
				throw throw ValidationException("query.field.not.allowed.operation", List(fieldName, allowedDoubleClauses.toString(), clause))
		}
		true
	}
}
