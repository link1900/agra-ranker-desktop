package database

import com.mongodb.casbah.commons.MongoDBObject
import validation.ValidationException

/**
 * Sort clause must be of format SortField:SortDirection - where SortDirection can be omitted (defaults to ascending)."
 */
trait Sortable {
	def sortBuilder(fields: Option[String]) = {
		fields match {
			case Some(fieldString) =>
				val builder = MongoDBObject.newBuilder

				for(sortField <- fieldString.split("""\|""")) {
					val splitField = sortField.split("""\:""")

					splitField.length match {
						case 1 =>
							builder += splitField(0) -> 1
						case 2 =>
							val field = splitField(0)
							splitField(1) match {
								case "asc" =>
									builder += splitField(0) -> 1
								case "desc" =>
									builder += splitField(0) -> -1
								case _ =>
									throw ValidationException("sort.clause.invalid",List(sortField))
							}
						case _ =>
							throw ValidationException("sort.clause.invalid",List(sortField))
					}
				}
				builder.result
			case None =>
				MongoDBObject()
		}
	}
}
