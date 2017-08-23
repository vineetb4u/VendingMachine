var VendingMachine;
(function (VendingMachine) {
    var Web;
    (function (Web) {
        var Resources;
        (function (Resources) {
            "use strict";
            var MachineResource = (function () {
                function MachineResource() {
                }
                MachineResource.getResource = function ($resource, apiBaseService) {
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
                MachineResource.$inject = ["$resource", "ApiBaseService"];
                return MachineResource;
            }());
            Resources.MachineResource = MachineResource;
        })(Resources = Web.Resources || (Web.Resources = {}));
    })(Web = VendingMachine.Web || (VendingMachine.Web = {}));
})(VendingMachine || (VendingMachine = {}));
//# sourceMappingURL=MachineResource.js.map