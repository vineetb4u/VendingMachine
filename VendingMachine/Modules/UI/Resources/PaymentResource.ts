module VendingMachine.Web.Resources {
    "use strict";


    export interface IPaymentResourceDef extends ng.resource.IResource<DTO.IPaymentDTO> {
    }

    export interface IPaymentResource extends ng.resource.IResourceClass<IPaymentResourceDef> {

    }

    export class PaymentResource {

        public static $inject: any[] = ["$resource", "ApiBaseService"];

        public static getResource(
            $resource: ng.resource.IResourceService,
            apiBaseService: Services.ApiBaseService): IPaymentResource {
            return <IPaymentResource>$resource(apiBaseService.apiBase + "/Payments/Payment");
        }
    }
}   