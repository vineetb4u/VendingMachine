module VendingMachine.Web.Resources {
    "use strict";


    export interface IMachineResourceDef extends ng.resource.IResource<DTO.IVendDTO> {
    }

    export interface IMachineResource extends ng.resource.IResourceClass<IMachineResourceDef> {
        vend(order: Object): IMachineResourceDef;
        Restock(order: Object): IMachineResourceDef;
    }

    export class MachineResource {

        public static $inject: any[] = ["$resource", "ApiBaseService"];

        public static getResource(
            $resource: ng.resource.IResourceService,
            apiBaseService: Services.ApiBaseService): IMachineResource {
            return <IMachineResource>$resource(apiBaseService.apiBase + "/Machine/", {}, {
                vend: {
                    method: "POST",
                    url: apiBaseService.apiBase + "/Machine/Vend"
                },
                Restock: {
                    method: "POST",
                    url: apiBaseService.apiBase + "/Machine/Restock"
                }
            });
        }
    }
}   