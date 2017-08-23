module VendingMachine.Web.DTO {

    export interface IVendDTO extends ng.resource.IResource<IVendDTO> {
        payment: IPaymentDTO;
        flavour: Enums.Flavour;
    }
}

