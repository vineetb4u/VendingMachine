var VendingMachine;
(function (VendingMachine) {
    var Web;
    (function (Web) {
        var Services;
        (function (Services) {
            var ApiBaseService = (function () {
                function ApiBaseService() {
                    this.apiBase = $("link[rel='apiBaseUrl']").attr("href");
                }
                ApiBaseService.$inject = [];
                return ApiBaseService;
            }());
            Services.ApiBaseService = ApiBaseService;
        })(Services = Web.Services || (Web.Services = {}));
    })(Web = VendingMachine.Web || (VendingMachine.Web = {}));
})(VendingMachine || (VendingMachine = {}));
//# sourceMappingURL=ApiBaseService.js.map