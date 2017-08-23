module VendingMachine.Web.DTO {

    export interface IPaymentDTO extends ng.resource.IResource<IPaymentDTO> {
        paymentID: number;
        type: Enums.PaymentType;
        amount: number;
    }
}

