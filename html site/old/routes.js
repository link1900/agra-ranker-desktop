var passport = require('passport');

var greyhoundController = require('./controllers/GreyhoundController.js');
var raceController = require('./controllers/RaceController.js');
var userController = require('./controllers/UserController.js');

function ensureAuthenticated(req, res, next) {
	if (req.isAuthenticated()) {
		return next();
	}
	res.redirect('/login');
}

module.exports = function(app) {

	app.get('/', function(req, res) {
		res.render('index', {
			title : 'AGRA Ranker'
		});
	});

	app.get('/greyhound', function(req, res) {
		res.render('greyhound', {
			title : 'AGRA Ranker'
		});
	});

	app.get('/api/greyhounds', function(req, res) {
		res.send({
			"greyhounds" : [{
				"name" : "dog1",
				"sire" : "dog1Father",
				"dam" : "dog1Mother"
			}, {
				"name" : "dog2",
				"sire" : "dog1Father",
				"dam" : "dog1Mother"
			}, {
				"name" : "dog3",
				"sire" : "dog1Father",
				"dam" : "dog1Mother"
			}]
		});
	});

	app.get('/race', function(req, res) {
		res.render('race', {
			title : 'AGRA Ranker'
		});
	});

	app.get('/api/races', function(req, res) {
		res.send({
			"races" : [{
				"name" : "Race 1",
				"date" : new Date().toDateString,
				"group" : "Group 1",
				"raceLength" : "500",
				"isNoRace" : "false",
				"placings" : [{
					"place" : "1",
					"greyhound" : "dog1"
				}, {
					"place" : "2",
					"greyhound" : "dog2"
				}, {
					"place" : "3",
					"greyhound" : "dog3"
				}, {
					"place" : "4",
					"greyhound" : "dog4"
				}, {
					"place" : "5",
					"greyhound" : "dog5"
				}, {
					"place" : "6",
					"greyhound" : "dog6"
				}, {
					"place" : "7",
					"greyhound" : "dog7"
				}, {
					"place" : "8",
					"greyhound" : "dog8"
				}]
			}, {
				"name" : "Race 2",
				"date" : new Date().toDateString,
				"group" : "Group 2",
				"raceLength" : "500",
				"isNoRace" : "false",
				"placings" : [{
					"place" : "1",
					"greyhound" : "dog1"
				}, {
					"place" : "2",
					"greyhound" : "dog2"
				}, {
					"place" : "3",
					"greyhound" : "dog3"
				}, {
					"place" : "4",
					"greyhound" : "dog4"
				}, {
					"place" : "5",
					"greyhound" : "dog5"
				}, {
					"place" : "6",
					"greyhound" : "dog6"
				}, {
					"place" : "7",
					"greyhound" : "dog7"
				}, {
					"place" : "8",
					"greyhound" : "dog8"
				}]
			}, {
				"name" : "Race 3",
				"date" : new Date().toDateString,
				"group" : "Group 3",
				"raceLength" : "715",
				"isNoRace" : "false",
				"placings" : [{
					"place" : "1",
					"greyhound" : "dog1"
				}, {
					"place" : "2",
					"greyhound" : "dog2"
				}, {
					"place" : "3",
					"greyhound" : "dog3"
				}, {
					"place" : "4",
					"greyhound" : "dog4"
				}, {
					"place" : "5",
					"greyhound" : "dog5"
				}, {
					"place" : "6",
					"greyhound" : "dog6"
				}, {
					"place" : "7",
					"greyhound" : "dog7"
				}, {
					"place" : "8",
					"greyhound" : "dog8"
				}]
			}]
		});
	});

	app.get('/rule', function(req, res) {
		res.render('rule', {
			title : 'AGRA Ranker'
		});
	});

	app.get('/api/rankings', function(req, res) {
		res.send({
			"rankings" : [{
				"rank" : "1",
				"greyhound" : "dog1",
				"points" : "80"
			}, {
				"rank" : "2",
				"greyhound" : "dog2",
				"points" : "50"
			}, {
				"rank" : "3",
				"greyhound" : "dog3",
				"points" : "30"
			}]
		});
	});

	app.get('/todo', function(req, res) {
		res.render('todo', {
			title : 'AGRA Ranker'
		});
	});

	// app.get('/register', start.getRegister);
	// app.post('/register', start.postRegister);
	//
	// app.get('/about', start.about);
	//
	// app.get('/login', start.login);
	// app.post('/login', passport.authenticate('local',
	// {
	// successRedirect: '/account',
	// failureRedirect: '/login'
	// })
	// );
	//
	// app.get('/account', ensureAuthenticated, start.getAccount);
	//
	// app.get('/logout', start.logout);
	//
	// app.get('/reviewNotes', ensureAuthenticated, notes.reviewNotes);
	//
	// app.get('/newNote', ensureAuthenticated, notes.getNewNote);
	// app.post('/newNote', ensureAuthenticated, notes.postNewNote);
	//
	// app.get('/myNotes', ensureAuthenticated, notes.getMyNotes);
	//
	// app.get('/myEventNotes', ensureAuthenticated, notes.getMyEventNotes);
	//
	// app.get('/eventNotes', ensureAuthenticated, notes.getEventNotes);
	// app.post('/eventNotes', ensureAuthenticated, notes.postEventNotes);
	//
	// app.get('/userNotes', ensureAuthenticated, notes.getUserNotes);
	// app.post('/userNotes', ensureAuthenticated, notes.postUserNotes);
	//
	// app.get('/newEvent', ensureAuthenticated, events.getNewEvent);
	// app.post('/newEvent', ensureAuthenticated, events.postNewEvent);
	//
	// app.get('/setEvent', ensureAuthenticated, events.getSetEvent);
	// app.get('/setEvent/:id', ensureAuthenticated, events.setEventID);
	// app.get('/sortEvents/:operation', ensureAuthenticated, events.setEventSort);
	//
	// app.get('/clearEvent', ensureAuthenticated, events.clearEvent);
}