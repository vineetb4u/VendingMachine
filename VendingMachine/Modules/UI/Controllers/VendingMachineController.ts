module VendingMachine.Web.Controllers {
    "use strict";

    export interface IVendingMachineControllerScope extends ng.IScope {
        drinkCans: any[];
        flavours: any;
        
       
        transaction: {
            selectedFlavour: DTO.IDrinkCanDTO;
            payment: DTO.IPaymentDTO;
            change?: number;
        };

        stock: {
            drinks: {
                sold: number;
                unsold: number;
            },
            payments: {
                cash: number,
                creditCard: number;
            }
        };

        selectDrink(flavour: Enums.Flavour);
        payCash(value);
        payCreditCard();
        restock();
    }


    export class VendingMachineController {

        public static $inject: any[] = [
            "$scope",
            "$q",
            "DrinkCanResource",
            "PaymentResource",
            "MachineResource"
        ];

        constructor(
            private $scope: IVendingMachineControllerScope,
            private $q: ng.IQService,
            private drinkCanResource: Resources.IDrinkCanResource,
            private paymentResource: Resources.IPaymentResource,
            private machineResource: Resources.IMachineResource
        ) {
            
            this.pageLoad();
            this.getDrinkCans();
        }

        private pageLoad() {
            var that = this;

            that.$scope.flavours = Enums.Flavour;
            that.$scope.selectDrink = (flavour) => that.selectDrink(flavour);
            that.$scope.payCash = (value) => that.payCash(value);
            that.$scope.payCreditCard = () => that.payCreditCard();
            that.$scope.restock = () => that.restock();
            that.$scope["maintenance"] = () => that.maintenance();
        }


        private getDrinkCans() {
            var that = this;
            var deferred = that.$q.defer();

            that.drinkCanResource
                .query({ isSold: false})
                .$promise
                .then((result) => {

                    that.$scope.drinkCans = _.uniq(result, false, (item: DTO.IDrinkCanDTO, key, flavour) => {
                        return item.flavour;
                    });

                    that.$scope.drinkCans.forEach((drinkCan) => {
                        drinkCan.count = _.where(result, { flavour: drinkCan.flavour }).length;
                    });
            });

        }

        private selectDrink(flavour: Enums.Flavour) {
            var that = this;

            that.$scope.transaction = {
                selectedFlavour: _.findWhere(that.$scope.drinkCans, { flavour: flavour }),
                payment: <any>{ paymentID: 0, type: Enums.PaymentType.Cash, amount: 0 }
            };
        }

        private payCash(value: number) {
            var that = this;

            that.$scope.transaction.payment.amount = Math.round((that.$scope.transaction.payment.amount + value) * 1e12) / 1e12;

            if (that.$scope.transaction.payment.amount > that.$scope.transaction.selectedFlavour.price)
            {
                that.$scope.transaction.change = Math.round((that.$scope.transaction.payment.amount - that.$scope.transaction.selectedFlavour.price) * 1e12) / 1e12;
                that.$scope.transaction.payment.paymentID = Math.floor(100000000 + Math.random() * 900000000);
                that.$scope.transaction.payment.amount = Math.round((that.$scope.transaction.payment.amount - that.$scope.transaction.change) * 1e12) / 1e12;

                that.processOrder();
            }
        }

        private payCreditCard() {
            var that = this;

            that.$scope.transaction.payment = <any>{
                paymentID: Math.floor(100000000 + Math.random() * 900000000),
                type: Enums.PaymentType.CreditCard,
                amount: that.$scope.transaction.selectedFlavour.price
            };

            that.processOrder();
        }

        private processOrder() {
            var that = this;

            var vend = { payment: that.$scope.transaction.payment, flavour: that.$scope.transaction.selectedFlavour.flavour };
            that.machineResource
                .vend(vend)
                .$promise
                .then(() => {
                    that.getDrinkCans();
                    alert("Please collect your drink");
                })
                .catch(() => {
                    var msg = "Error processing the Order. Please try again.";

                    if (that.$scope.transaction.payment.type === Enums.PaymentType.Cash) {
                        msg = "Error processing the Order. Please collect your cash and try again."
                    }
                    else if (that.$scope.transaction.payment.type === Enums.PaymentType.CreditCard) {
                        msg = "Error processing the Order. Credit Card transaction will be reversed. Please try again."
                    }

                    alert(msg);
                })
                .finally(() => {
                    that.$scope.transaction = undefined;
                });
        }

        private restock() {
            var that = this;

            that.drinkCanResource
                .query()
                .$promise
                .then((drinkCans) => {

                    drinkCans.forEach((drinkCan: DTO.IDrinkCanDTO) => {
                        drinkCan.isSold = false;
                    });

                    that.machineResource
                        .Restock(drinkCans)
                        .$promise
                        .then(() => {
                            alert("Restocking completed");

                            that.$scope.stock = {
                                drinks: {
                                    sold: 0,
                                    unsold: drinkCans.length
                                },
                                payments: {
                                    cash: 0,
                                    creditCard: 0
                                }
                            };

                            that.getDrinkCans();
                        })
                        .catch(() => {
                            alert("Restocking error");
                        });
                });
        }

        private maintenance() {
            var that = this;

            var promises: { [id: string]: ng.IPromise<any>; } = {
                "drinkCans": that.drinkCanResource.query().$promise,
                "payments": that.paymentResource.query().$promise
            };

            
            that.$q.all(promises).then((result: any) => {
                var totalCash: number = 0, totalCreditCard: number = 0;

                _.chain(_.where(result.payments, { type: Enums.PaymentType.Cash }))
                    .pluck("amount").forEach((amount) => { totalCash = Math.round((totalCash + amount) * 1e12) / 1e12 }).value();

                _.chain(_.where(result.payments, { type: Enums.PaymentType.CreditCard }))
                    .pluck("amount").forEach((amount) => { totalCreditCard = Math.round((totalCreditCard + amount) * 1e12) / 1e12 }).value();


                that.$scope.stock = {
                    drinks: {
                        sold: _.where(result.drinkCans, { isSold: true }).length,
                        unsold: _.where(result.drinkCans, { isSold: false }).length
                    },
                    payments: {
                        cash: totalCash,
                        creditCard: totalCreditCard
                    }
                };

            });
        }
    }
}

