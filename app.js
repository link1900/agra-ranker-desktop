/**
 * Module dependencies.
 */

var express = require('express');
var http = require('http');

var app = express();

app.configure(function() {
    app.set('port', process.env.PORT || 3000);
    app.set('views', __dirname + '/views');
    app.set('view engine', 'jade');
    app.use(express.favicon());
    app.use(express.logger('dev'));
    app.use(express.bodyParser());
    app.use(express.methodOverride());
    app.use(app.router);
    app.use(express.static(__dirname + '/public'));
});

app.configure('development', function() {
    app.use(express.errorHandler());
});

app.get('/', function(req, res) {
    res.render('index', {
        title: 'AGRA Ranker'
    });
});

app.get('/greyhound', function(req, res) {
    res.render('greyhound', {
        title: 'AGRA Ranker'
    });
});

app.get('/api/greyhounds', function(req, res) {
    res.send({
        "greyhounds": [{
            "name": "dog1",
            "sire": "dog1Father",
            "dam": "dog1Mother"
        }, {
            "name": "dog2",
            "sire": "dog1Father",
            "dam": "dog1Mother"
        }, {
            "name": "dog3",
            "sire": "dog1Father",
            "dam": "dog1Mother"
        }]
    });
});

app.get('/race', function(req, res) {
    res.render('race', {
        title: 'AGRA Ranker'
    });
});

app.get('/api/races', function(req, res) {
    res.send({
        "races": [{
            "name": "Race 1",
            "date": new Date().toDateString,
            "group": "Group 1",
            "raceLength": "500",
            "isNoRace": "false",
            "placings": [{
                "place": "1",
                "greyhound": "dog1"
            }, {
                "place": "2",
                "greyhound": "dog2"
            }, {
                "place": "3",
                "greyhound": "dog3"
            }, {
                "place": "4",
                "greyhound": "dog4"
            }, {
                "place": "5",
                "greyhound": "dog5"
            }, {
                "place": "6",
                "greyhound": "dog6"
            }, {
                "place": "7",
                "greyhound": "dog7"
            }, {
                "place": "8",
                "greyhound": "dog8"
            }]
        }, {
            "name": "Race 2",
            "date": new Date().toDateString,
            "group": "Group 2",
            "raceLength": "500",
            "isNoRace": "false",
            "placings": [{
                "place": "1",
                "greyhound": "dog1"
            }, {
                "place": "2",
                "greyhound": "dog2"
            }, {
                "place": "3",
                "greyhound": "dog3"
            }, {
                "place": "4",
                "greyhound": "dog4"
            }, {
                "place": "5",
                "greyhound": "dog5"
            }, {
                "place": "6",
                "greyhound": "dog6"
            }, {
                "place": "7",
                "greyhound": "dog7"
            }, {
                "place": "8",
                "greyhound": "dog8"
            }]
        }, {
            "name": "Race 3",
            "date": new Date().toDateString,
            "group": "Group 3",
            "raceLength": "715",
            "isNoRace": "false",
            "placings": [{
                "place": "1",
                "greyhound": "dog1"
            }, {
                "place": "2",
                "greyhound": "dog2"
            }, {
                "place": "3",
                "greyhound": "dog3"
            }, {
                "place": "4",
                "greyhound": "dog4"
            }, {
                "place": "5",
                "greyhound": "dog5"
            }, {
                "place": "6",
                "greyhound": "dog6"
            }, {
                "place": "7",
                "greyhound": "dog7"
            }, {
                "place": "8",
                "greyhound": "dog8"
            }]
        }]
    });
});

app.get('/rule', function(req, res) {
    res.render('rule', {
        title: 'AGRA Ranker'
    });
});

app.get('/api/rankings', function(req, res) {
    res.send({
        "rankings": [{
            "rank": "1",
            "greyhound": "dog1",
            "points": "80"
        }, {
            "rank": "2",
            "greyhound": "dog2",
            "points": "50"
        }, {
            "rank": "3",
            "greyhound": "dog3",
            "points": "30"
        }]
    });
});

app.get('/todo', function(req, res) {
    res.render('todo', {
        title: 'AGRA Ranker'
    });
});

http.createServer(app).listen(app.get('port'), function() {
    console.log("Node server started at " + new Date() + " and listening on port " + app.get('port'));
});