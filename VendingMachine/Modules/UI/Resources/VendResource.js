var VendingMachine;
(function (VendingMachine) {
    var Web;
    (function (Web) {
        var Resources;
        (function (Resources) {
            "use strict";
            var VendResource = (function () {
                function VendResource() {
                }
                VendResource.getResource = function ($resource, apiBaseService) {
                    return $resource(apiBaseService.apiBase + "/Machine/", {}, {
                        vend: {
                            method: "POST",
                            url: apiBaseService.apiBase + "/Machine/Vend"
                        },
                        Restock: {
                            method: "POST",
                            url: apiBaseService.apiBase + "/Machine/Restock"
                        }
                    });
                };
                VendResource.$inject = ["$resource", "ApiBaseService"];
                return VendResource;
            }());
            Resources.VendResource = VendResource;
        })(Resources = Web.Resources || (Web.Resources = {}));
    })(Web = VendingMachine.Web || (VendingMachine.Web = {}));
})(VendingMachine || (VendingMachine = {}));
