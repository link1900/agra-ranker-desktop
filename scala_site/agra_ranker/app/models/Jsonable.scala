package models

import org.json4s._
import org.json4s.native.JsonMethods._
import org.json4s.native.Serialization
import org.json4s.native.Serialization.{read, write}
import play.api.mvc.{PlainResult}
import org.bson.types.ObjectId
import org.joda.time.Interval
import reflect.Manifest
import play.api.libs.json.JsValue
import play.api.mvc.Results
import play.api.http.ContentTypes


/**
 * Trait meaning that the applied object can be converted to json.
 */
trait Jsonable {

	val removedFields : List[String] = Nil

	/**
	 * Convert this to json
	 * @param onlyFields
	 * @param removeFields
	 * @return
	 */
	def asJson(onlyFields : List[String], removeFields : List[String]) : String = {
		Jsonable.toJson(this, onlyFields, removeFields)
	}

	/**
	 * Converts this to json wrapped in a play Ok Response
	 * @param onlyFields
	 * @return
	 */
	def asOkJson(onlyFields : List[String]) : PlainResult = {
    Results.Ok(this.asJson(onlyFields,removedFields)).as(ContentTypes.JSON)
	}

	/**
	 *  Converts this to json wrapped in a play Ok Response
	 * @return
	 */
	def asOkJson : PlainResult = {
    Results.Ok(this.asJson).as(ContentTypes.JSON)
	}

	/**
	 * Convert this to json
	 * @return
	 */
	def asJson : String = {
		asJson(Nil, removedFields)
	}
}

/**
 * Used to provide custom conversion of the ObjectId class to a from a json string
 */
class ObjectIdSerializer extends CustomSerializer[ObjectId](format => (
	{
		case JString(s) =>
			new ObjectId(s)
	},
	{
		case x: ObjectId =>
			JString(x.toString)
	}
	))
{}

/**
 * Main json converter for services level conversion of entities to and from json. Used by Jsonable trait to do
 * conversions and Service Trait to do parsing.
 */
object Jsonable {
	val formats = Serialization.formats(NoTypeHints) + new ObjectIdSerializer ++ JodaTimeSerializers.all

	/**
	 * Converts given traversable to json
	 * @param entities
	 * @return
	 */
	def toJson(entities : Traversable[Jsonable]) : String = {
		if (entities.nonEmpty){
			toJson(entities,Nil,entities.head.removedFields)
		}else{
			toJson(entities,Nil,Nil)
		}
	}

	/**
	 * Converts a given jsonable object to json
	 * @param entity
	 * @return
	 */
	def toJson(entity : Jsonable) : String = {
		toJson(entity,Nil,entity.removedFields)
	}

	/**
	 * Converts any to json
	 * @param entity
	 * @param onlyFields
	 * @param removeFields
	 * @return
	 */
	def toJson(entity : Any, onlyFields : List[String], removeFields : List[String]) : String = {
		implicit val formats = Jsonable.formats
		val jsonAST = Extraction.decompose(entity)

		val keepFields: List[String] = onlyFields.flatMap(string => {
			if(string.contains(".")) {
				string.split("""\.""").toList
			}else{
				List(string)
			}
		}).distinct

		val cleanedJsonAST = {
			if (keepFields.isEmpty)
				jsonAST
			else
				jsonAST.removeField(p => !keepFields.contains(p._1))
		}

		val finalJsonAST = {
			if (removeFields.isEmpty)
				cleanedJsonAST
			else
				cleanedJsonAST.removeField(p => removeFields.contains(p._1))
		}
		compact(render(finalJsonAST))
	}

	/**
	 * Converts string to the define type.
	 * @param jsonEntity
	 * @param mf
	 * @tparam T
	 * @return
	 */
	def fromJson[T](jsonEntity : String)(implicit mf: Manifest[T]): Either[T,Response] = fromJson(jsonEntity, None)

	/**
	 * Converts json4s json object to the define type.
	 * @param jsonObject
	 * @param mf
	 * @tparam T
	 * @return
	 */
	def fromJson[T](jsonObject : JValue)(implicit mf: Manifest[T]) : Either[T,Response] = {
		implicit val formats = Jsonable.formats
		try{
			Left(jsonObject.extract[T])
		}catch {
			case ex : Exception => Right(Response.requestBadJson)
		}
	}

	/**
	 * Converts a json string into the service entity model using the dao json converter. It will attempt to merge
	 * the json with the original json from the database. This allow from provided json to be a partial representation
	 * of the intended entity.
	 * @param jsonEntity
	 * @return
	 */
	def fromJson[T](jsonEntity : String, possibleOriginalEntity : Option[String])(implicit mf: Manifest[T]): Either[T,Response] = {
		implicit val formats = Jsonable.formats

		val mergeResult = possibleOriginalEntity match {
			case Some(originalEntity) => {
				try{
					parse(originalEntity).merge(parse(jsonEntity))
				}catch {
					case e : Exception => return Right(Response.requestBadJson)
				}
			}
			case None => {
				try{
					parse(jsonEntity)
				}catch {
					case e : Exception => return Right(Response.requestBadJson)
				}
			}
		}
		fromJson[T](mergeResult)
	}

	def fromPlayJson[T](playJson : Option[JsValue])(implicit mf: Manifest[T]) : Either[T,Response] = {
		playJson match {
			case Some(someJson) => {
				Jsonable.fromJson[T](someJson.toString())
			}
			case None => Right(Response.requestBadJson)
		}
	}
}



