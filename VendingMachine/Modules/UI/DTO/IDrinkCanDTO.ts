module VendingMachine.Web.DTO {

    export interface IDrinkCanDTO extends ng.resource.IResource<IDrinkCanDTO> {
        flavour: Enums.Flavour;
        price: number;
        isSold: boolean;
    }
}

