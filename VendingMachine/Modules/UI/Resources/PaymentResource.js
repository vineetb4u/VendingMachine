var VendingMachine;
(function (VendingMachine) {
    var Web;
    (function (Web) {
        var Resources;
        (function (Resources) {
            "use strict";
            var PaymentResource = (function () {
                function PaymentResource() {
                }
                PaymentResource.getResource = function ($resource, apiBaseService) {
                    return $resource(apiBaseService.apiBase + "/Payments/Payment");
                };
                PaymentResource.$inject = ["$resource", "ApiBaseService"];
                return PaymentResource;
            }());
            Resources.PaymentResource = PaymentResource;
        })(Resources = Web.Resources || (Web.Resources = {}));
    })(Web = VendingMachine.Web || (VendingMachine.Web = {}));
})(VendingMachine || (VendingMachine = {}));
//# sourceMappingURL=PaymentResource.js.map