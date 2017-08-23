module VendingMachine.Web.Controllers {
    "use strict";


    export class VendingMachineController {

        public static $inject: any[] = ["$scope", "DrinkCanResource"];

        constructor(
            private $scope: ng.IScope,
            private drinkCanResource: Resources.IDrinkCanResource
        ) {

            drinkCanResource.query().$promise.then((cans) => {
                alert(cans.length);
            });
            console.log('my controllere');
            $scope["title"] = "VendingMachine PAGE";
        }
    }
}

