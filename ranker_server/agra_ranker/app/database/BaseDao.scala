package database

import com.novus.salat.annotations._
import com.novus.salat.{TypeHintFrequency, StringTypeHintStrategy, Context}
import com.novus.salat.json.{StringObjectIdStrategy, JSONConfig}
import com.novus.salat.dao.ModelCompanion
import com.mongodb.casbah.commons.TypeImports.ObjectId
import collection.mutable
import models.{EntityRef}
import validation.canValidate
import json.Jsonable

@Salat
trait BaseDao extends Jsonable with canValidate with Copyable {
	@Key("_id") val id: ObjectId = new ObjectId
	val collectionName : String = ""

	def asEntityRef : EntityRef = {
		EntityRef(this.id, this.collectionName)
	}
}

trait BaseModelCompanion[ObjectType <: AnyRef, ID <: Any] extends ModelCompanion[ObjectType, ID] with Projectable with Queryable with Sortable {
	com.mongodb.casbah.commons.conversions.scala.RegisterJodaTimeConversionHelpers()
	implicit val ctx = new Context {
		val name = "json-context"
		override val jsonConfig = JSONConfig(
			objectIdStrategy = StringObjectIdStrategy)
		override val typeHintStrategy = StringTypeHintStrategy(when = TypeHintFrequency.Always,
			typeHint = "_typeHint")
	}
}

