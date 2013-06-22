package models

import com.novus.salat.dao.SalatDAO
import com.mongodb.casbah.Imports._
import se.radley.plugin.salat._
import play.api.Play.current
import database.{BaseModelCompanion, BaseDao}

case class Relationship(
  override val id: ObjectId = new ObjectId,
  relationshipType : String,
  leftEntity : EntityRef,
	rightEntity : EntityRef,
  actionOnUpdate : String = Relationship.DeleteActions.nothing,
  actionOnDelete : String = Relationship.UpdateActions.nothing
) extends BaseDao {
}

case class EntityRef(id : ObjectId, collectionName : String){
//	def getEntity : Option[_] = {
//		//todo
//	}
}

object Relationship extends BaseModelCompanion[Relationship, ObjectId] {
	queryMap += {"relationshipType" -> "String"}
	queryMap += {"leftEntity.id" -> "ObjectId"}
	queryMap += {"rightEntity.id" -> "ObjectId"}
	val dao = new SalatDAO[Relationship, ObjectId](collection = mongoCollection("relationship")) {}

	object DeleteActions {
		val nothing = "nothing"
		val deleteReference = "deleteReference"
		val deleteEntity = "deleteEntity"
	}

	object UpdateActions {
		val nothing = "nothing"
		val doUpdate ="doUpdate"
	}
}

