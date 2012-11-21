var core = angular.module('core', []).config(function($routeProvider) {
	$routeProvider.when('/', {
		controller : RankingsCtrl,
		templateUrl : 'rankings.html'
	}).when('/greyhound', {
		controller : GreyhoundCtrl,
		templateUrl : 'greyhound.html'
	}).otherwise({
		redirectTo : '/'
	});
});


core.directive('myTable', function() {
        return function(scope, element, attrs) {

            // apply DataTable options, use defaults if none specified by user
            var options = {};
            if (attrs.myTable.length > 0) {
                options = scope.$eval(attrs.myTable);
            } else {
                options = {
                    "bStateSave": true,
                    "iCookieDuration": 2419200, /* 1 month */
                    "bJQueryUI": true,
                    "bPaginate": false,
                    "bLengthChange": false,
                    "bFilter": false,
                    "bInfo": false,
                    "bDestroy": true
                };
            }

            // Tell the dataTables plugin what columns to use
            // We can either derive them from the dom, or use setup from the controller           
            var explicitColumns = [];
            element.find('th').each(function(index, elem) {
                explicitColumns.push($(elem).text());
            });
            if (explicitColumns.length > 0) {
                options["aoColumns"] = explicitColumns;
            } else if (attrs.aoColumns) {
                options["aoColumns"] = scope.$eval(attrs.aoColumns);
            }

            // aoColumnDefs is dataTables way of providing fine control over column config
            if (attrs.aoColumnDefs) {
                options["aoColumnDefs"] = scope.$eval(attrs.aoColumnDefs);
            }

            // apply the plugin
            var dataTable = element.dataTable(options);

            // watch for any changes to our data, rebuild the DataTable
            scope.$watch(attrs.aaData, function(value) {
                var val = value || null;
                if (val) {
                    dataTable.fnClearTable();
                    dataTable.fnAddData(scope.$eval(attrs.aaData));
                }
            });
        };
    });

function RankingsCtrl($scope){
	$scope.rankings = [];
	
	
}

function GreyhoundCtrl($scope, Project) {
	$scope.greyhounds = [];
	
	$scope.tblData = [
            ["Webber", "Adam"]
        ];

        // not mandatory, here as an example
        $scope.tblColumns = [
            { "sTitle": "Surname" },
            { "sTitle": "First Name" }
        ];

        // not mandatory, here as an example
        $scope.columnDefs = [{ "bSortable": false, "aTargets": [1] }];
    
        // not mandatory, you can use defaults in directive        
        $scope.overrideOptions = {
            "bStateSave": true,
            "iCookieDuration": 2419200, /* 1 month */
            "bJQueryUI": true,
            "bPaginate": false,
            "bLengthChange": false,
            "bFilter": false,
            "bInfo": false,
            "bDestroy": true
        };
        
                // we pretend that we have received new data from somewhere (eg a search)        
        $scope.addData = function(){
            //$scope.tblData.push(["jones", "henry"]); // BUG? Angular doesn't pick this up
            $scope.counter = $scope.counter+1;
            var existing = $scope.tblData.slice();
            existing.push([$scope.counter, $scope.counter*2]);
            $scope.tblData = existing;
        }
        $scope.counter = 0
}