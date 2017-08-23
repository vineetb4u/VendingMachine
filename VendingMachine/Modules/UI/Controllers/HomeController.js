var VendingMachine;
(function (VendingMachine) {
    var Web;
    (function (Web) {
        var Controllers;
        (function (Controllers) {
            "use strict";
            var HomeController = (function () {
                function HomeController($scope, $location) {
                    this.$scope = $scope;
                    this.$location = $location;
                    $scope["title"] = "HOME PAGE";
                    console.log('home contoler');
                    $location.path("/VendingMachine");
                }
                HomeController.$inject = ["$scope", "$location"];
                return HomeController;
            }());
            Controllers.HomeController = HomeController;
        })(Controllers = Web.Controllers || (Web.Controllers = {}));
    })(Web = VendingMachine.Web || (VendingMachine.Web = {}));
})(VendingMachine || (VendingMachine = {}));
