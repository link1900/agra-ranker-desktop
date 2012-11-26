/**
 * Module dependencies.
 */

var express = require('express');
var http = require('http');
var passport = require('passport')
var mongoose = require('mongoose')
var mongoStore = require('connect-mongodb');

var app = module.exports = express.createServer();
global.app = app;

var DB = require('./accessDB');
var conn = 'mongodb://localhost/agradb';
DB.startup(conn);

app.configure(function() {
    app.set('port', process.env.PORT || 3000);
    app.set('views', __dirname + '/views');
    app.set('view engine', 'jade');
    app.use(express.favicon());
    app.use(express.cookieParser());
    app.use(express.logger('dev'));
    app.use(express.bodyParser());
    app.use(express.methodOverride());
    app.use(express.session({ 
		store: mongoStore(conn),
		secret: 'poweroverload'
  	}));
    app.use(app.router);
    app.use(passport.initialize());
  	app.use(passport.session());
    app.use(express.static(__dirname + '/public'));
});

app.configure('development', function() {
    app.use(express.errorHandler({ dumpExceptions: true, showStack: true }));
});

app.configure('production', function() {
    app.use(express.errorHandler());
});

// Routes
require('./routes')(app);

http.createServer(app).listen(app.get('port'), function() {
	console.log("Node Express server started at " + new Date() + " listening on port %d in %s mode", app.get('port'), app.settings.env);
});