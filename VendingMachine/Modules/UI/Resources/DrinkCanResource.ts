module VendingMachine.Web.Resources {
    "use strict";


    export interface IDrinkCanResourceDef extends ng.resource.IResource<DTO.IDrinkCanDTO> {
    }

    export interface IDrinkCanResource extends ng.resource.IResourceClass<IDrinkCanResourceDef> {
      
    }

    export class DrinkCanResource {

        public static $inject: any[] = ["$resource", "ApiBaseService"];

        public static getResource(
            $resource: ng.resource.IResourceService,
            apiBaseService: Services.ApiBaseService): IDrinkCanResource {
            return <IDrinkCanResource>$resource(apiBaseService.apiBase + "/DrinkCans/DrinkCan/");
        }
    }
}   