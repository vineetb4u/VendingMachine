module VendingMachine.Web {
    "use strict";

    var app = angular.module("app", [
        "ngRoute",
        "ngResource"
    ]);

    for (var service in Services) {
        if (Services.hasOwnProperty(service) && Services[service].hasOwnProperty("$inject")) {
            console.log("Binding Service: " + service);
            var serviceFn = Services[service];
            app.service(service, serviceFn.$inject.concat(serviceFn));
        }
    }


    for (var resource in Resources) {
        if (Resources.hasOwnProperty(resource) && Resources[resource].hasOwnProperty("$inject")) {
            console.log("Binding Resource: " + resource);
            var resourceFn = Resources[resource];
            app.factory(resource, resourceFn.$inject.concat(resourceFn.getResource));
        }
    }

   
    for (var controller in Controllers) {
        if (Controllers.hasOwnProperty(controller) && Controllers[controller].hasOwnProperty("$inject")) {
            console.log("Binding Controller: " + controller);
            var controllerFn = Controllers[controller];
            app.controller(controller, controllerFn.$inject.concat(controllerFn));
        }
    }


    app.config(["$routeProvider",
        function routes($routeProvider: ng.route.IRouteProvider) {
            $routeProvider
                .when("/Home", {
                    templateUrl: "Home/Index"
                });

        }
    ]);
}