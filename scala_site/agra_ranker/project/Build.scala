import sbt._
import Keys._
import PlayProject._

object ApplicationBuild extends Build {

    val appName         = "agra_ranker"
    val appVersion      = "1.0"

    val appDependencies = Seq(
      // Add your project dependencies here,
    )

    val main = PlayProject(appName, appVersion, appDependencies, mainLang = SCALA).settings(
      		resolvers ++= Seq(
			"repo.novus snaps" at "http://repo.novus.com/snapshots/",
			"snapshots" at "https://oss.sonatype.org/content/repositories/snapshots",
			"releases"  at "http://oss.sonatype.org/content/repositories/releases",
			"Typesafe Repository" at "http://repo.typesafe.com/typesafe/releases/"
		)
    )

}
