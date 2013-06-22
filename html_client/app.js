var express = require('express');
var http = require('http');
var app = module.exports = express();
global.app = app;

app.configure(function() {
	app.set('port', 8080);
    app.use(express.static(__dirname + '/'));
});


http.createServer(app).listen(app.get('port'), function() {
	console.log("Node Express server started at " + new Date() + " listening on port %d in %s mode", app.get('port'), app.settings.env);
});
