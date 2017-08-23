module VendingMachine.Web.DTO {

    export interface IDrinkCanDTO extends ng.resource.IResource<IDrinkCanDTO> {
        drinkCanID: number;
        flavour: number;
        price: number;
    }
}

