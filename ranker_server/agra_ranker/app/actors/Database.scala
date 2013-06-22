package actors

import akka.actor._
import com.mongodb.casbah.commons.MongoDBObject
import database.BaseModelCompanion
import com.mongodb.casbah.Imports._

class DatabaseAccessor extends Actor{
  val maxRetrievalLimit = 100
  def receive = {
    case creator : Creator => {
    }
    case reader : Reader => {
      sender ! ManyResults(reader.dao.find(reader.query, reader.projection).limit(reader.limit.min(maxRetrievalLimit)).sort(reader.sort).skip(reader.offset).toTraversable)
    }
    case _ => sender ! ErrorResult.unknownMessage
  }
}

case class Reader(
  query:MongoDBObject,
  projection:MongoDBObject,
  sort:MongoDBObject,
  limit:Int,
  offset:Int,
  dao: BaseModelCompanion[Any, ObjectId]
){}

case class ManyResults(results: Traversable[Any])
case class Creator(msg:String){}
