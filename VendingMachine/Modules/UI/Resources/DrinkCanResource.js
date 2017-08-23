var VendingMachine;
(function (VendingMachine) {
    var Web;
    (function (Web) {
        var Resources;
        (function (Resources) {
            "use strict";
            var DrinkCanResource = (function () {
                function DrinkCanResource() {
                }
                DrinkCanResource.getResource = function ($resource, apiBaseService) {
                    return $resource(apiBaseService.apiBase + "/DrinkCans/DrinkCan/");
                };
                DrinkCanResource.$inject = ["$resource", "ApiBaseService"];
                return DrinkCanResource;
            }());
            Resources.DrinkCanResource = DrinkCanResource;
        })(Resources = Web.Resources || (Web.Resources = {}));
    })(Web = VendingMachine.Web || (VendingMachine.Web = {}));
})(VendingMachine || (VendingMachine = {}));
//# sourceMappingURL=DrinkCanResource.js.map