import sbt._
import Keys._
import PlayProject._

object ApplicationBuild extends Build {

    val appName         = "agra_ranker"
    val appVersion      = "1.0"

    val appDependencies = Seq(
      "org.json4s" %% "json4s-native" % "3.1.0",
      "org.scalaj" %% "scalaj-time" % "0.6",
      "com.novus" %% "salat-core" % "1.9.1",
      "se.radley" %% "play-plugins-salat" % "1.1",
      "com.typesafe.akka" % "akka-actor" % "2.0.3"
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
