var VendingMachine;
(function (VendingMachine) {
    var Web;
    (function (Web) {
        var Controllers;
        (function (Controllers) {
            "use strict";
            var HomeController = (function () {
                function HomeController($scope) {
                    this.$scope = $scope;
                    $scope["title"] = "HOME PAGE";
                }
                HomeController.$inject = ["$scope"];
                return HomeController;
            }());
            Controllers.HomeController = HomeController;
        })(Controllers = Web.Controllers || (Web.Controllers = {}));
    })(Web = VendingMachine.Web || (VendingMachine.Web = {}));
})(VendingMachine || (VendingMachine = {}));
//# sourceMappingURL=HomeController.js.map