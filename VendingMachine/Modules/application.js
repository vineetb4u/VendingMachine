var VendingMachine;
(function (VendingMachine) {
    var Web;
    (function (Web) {
        "use strict";
        var app = angular.module("app", [
            "ngRoute",
            "ngResource"
        ]);
        for (var service in Web.Services) {
            if (Web.Services.hasOwnProperty(service) && Web.Services[service].hasOwnProperty("$inject")) {
                console.log("Binding Service: " + service);
                var serviceFn = Web.Services[service];
                app.service(service, serviceFn.$inject.concat(serviceFn));
            }
        }
        for (var resource in Web.Resources) {
            if (Web.Resources.hasOwnProperty(resource) && Web.Resources[resource].hasOwnProperty("$inject")) {
                console.log("Binding Resource: " + resource);
                var resourceFn = Web.Resources[resource];
                app.factory(resource, resourceFn.$inject.concat(resourceFn.getResource));
            }
        }
        for (var controller in Web.Controllers) {
            if (Web.Controllers.hasOwnProperty(controller) && Web.Controllers[controller].hasOwnProperty("$inject")) {
                console.log("Binding Controller: " + controller);
                var controllerFn = Web.Controllers[controller];
                app.controller(controller, controllerFn.$inject.concat(controllerFn));
            }
        }
        app.config(["$routeProvider",
            function routes($routeProvider) {
                $routeProvider
                    .when("/Home", {
                    templateUrl: "Home/Index"
                });
            }
        ]);
    })(Web = VendingMachine.Web || (VendingMachine.Web = {}));
})(VendingMachine || (VendingMachine = {}));
//# sourceMappingURL=application.js.map