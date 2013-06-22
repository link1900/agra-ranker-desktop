package database

import com.mongodb.casbah.commons.MongoDBObject

trait Projectable {
	def projectionBuilder(fields: Option[String]) = {
		fields match {
			case Some(fieldString) =>
				val builder = MongoDBObject.newBuilder
				fieldString.split("""\|""").foreach(builder += _ -> "1")
				builder.result
			case None =>
				MongoDBObject()
		}
	}
}
