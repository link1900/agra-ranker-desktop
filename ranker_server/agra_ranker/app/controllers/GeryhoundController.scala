package controllers

import play.api._
import play.api.mvc._

class GeryhoundController extends Controller {

  def test = Action { implicit request =>
    DatabaseAccessor ! Reader()
    Ok("Coming soon")
  }

}
