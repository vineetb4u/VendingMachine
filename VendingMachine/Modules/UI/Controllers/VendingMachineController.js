var VendingMachine;
(function (VendingMachine) {
    var Web;
    (function (Web) {
        var Controllers;
        (function (Controllers) {
            "use strict";
            var VendingMachineController = (function () {
                function VendingMachineController($scope, $q, drinkCanResource, paymentResource, machineResource) {
                    this.$scope = $scope;
                    this.$q = $q;
                    this.drinkCanResource = drinkCanResource;
                    this.paymentResource = paymentResource;
                    this.machineResource = machineResource;
                    this.pageLoad();
                    this.getDrinkCans();
                }
                VendingMachineController.prototype.pageLoad = function () {
                    var that = this;
                    that.$scope.flavours = Web.Enums.Flavour;
                    that.$scope.selectDrink = function (flavour) { return that.selectDrink(flavour); };
                    that.$scope.payCash = function (value) { return that.payCash(value); };
                    that.$scope.payCreditCard = function () { return that.payCreditCard(); };
                    that.$scope.restock = function () { return that.restock(); };
                    that.$scope["maintenance"] = function () { return that.maintenance(); };
                };
                VendingMachineController.prototype.getDrinkCans = function () {
                    var that = this;
                    var deferred = that.$q.defer();
                    that.drinkCanResource
                        .query({ isSold: false })
                        .$promise
                        .then(function (result) {
                        that.$scope.drinkCans = _.uniq(result, false, function (item, key, flavour) {
                            return item.flavour;
                        });
                        that.$scope.drinkCans.forEach(function (drinkCan) {
                            drinkCan.count = _.where(result, { flavour: drinkCan.flavour }).length;
                        });
                    });
                };
                VendingMachineController.prototype.selectDrink = function (flavour) {
                    var that = this;
                    that.$scope.transaction = {
                        selectedFlavour: _.findWhere(that.$scope.drinkCans, { flavour: flavour }),
                        payment: { paymentID: 0, type: Web.Enums.PaymentType.Cash, amount: 0 }
                    };
                };
                VendingMachineController.prototype.payCash = function (value) {
                    var that = this;
                    that.$scope.transaction.payment.amount = Math.round((that.$scope.transaction.payment.amount + value) * 1e12) / 1e12;
                    if (that.$scope.transaction.payment.amount > that.$scope.transaction.selectedFlavour.price) {
                        that.$scope.transaction.change = Math.round((that.$scope.transaction.payment.amount - that.$scope.transaction.selectedFlavour.price) * 1e12) / 1e12;
                        that.$scope.transaction.payment.paymentID = Math.floor(100000000 + Math.random() * 900000000);
                        that.$scope.transaction.payment.amount = Math.round((that.$scope.transaction.payment.amount - that.$scope.transaction.change) * 1e12) / 1e12;
                        that.processOrder();
                    }
                };
                VendingMachineController.prototype.payCreditCard = function () {
                    var that = this;
                    that.$scope.transaction.payment = {
                        paymentID: Math.floor(100000000 + Math.random() * 900000000),
                        type: Web.Enums.PaymentType.CreditCard,
                        amount: that.$scope.transaction.selectedFlavour.price
                    };
                    that.processOrder();
                };
                VendingMachineController.prototype.processOrder = function () {
                    var that = this;
                    var vend = { payment: that.$scope.transaction.payment, flavour: that.$scope.transaction.selectedFlavour.flavour };
                    that.machineResource
                        .vend(vend)
                        .$promise
                        .then(function () {
                        that.getDrinkCans();
                        alert("Please collect your drink");
                    })
                        .catch(function () {
                        var msg = "Error processing the Order. Please try again.";
                        if (that.$scope.transaction.payment.type === Web.Enums.PaymentType.Cash) {
                            msg = "Error processing the Order. Please collect your cash and try again.";
                        }
                        else if (that.$scope.transaction.payment.type === Web.Enums.PaymentType.CreditCard) {
                            msg = "Error processing the Order. Credit Card transaction will be reversed. Please try again.";
                        }
                        alert(msg);
                    })
                        .finally(function () {
                        that.$scope.transaction = undefined;
                    });
                };
                VendingMachineController.prototype.restock = function () {
                    var that = this;
                    that.drinkCanResource
                        .query()
                        .$promise
                        .then(function (drinkCans) {
                        drinkCans.forEach(function (drinkCan) {
                            drinkCan.isSold = false;
                        });
                        that.machineResource
                            .Restock(drinkCans)
                            .$promise
                            .then(function () {
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
                            .catch(function () {
                            alert("Restocking error");
                        });
                    });
                };
                VendingMachineController.prototype.maintenance = function () {
                    var that = this;
                    var promises = {
                        "drinkCans": that.drinkCanResource.query().$promise,
                        "payments": that.paymentResource.query().$promise
                    };
                    that.$q.all(promises).then(function (result) {
                        var totalCash = 0, totalCreditCard = 0;
                        _.chain(_.where(result.payments, { type: Web.Enums.PaymentType.Cash }))
                            .pluck("amount").forEach(function (amount) { totalCash = Math.round((totalCash + amount) * 1e12) / 1e12; }).value();
                        _.chain(_.where(result.payments, { type: Web.Enums.PaymentType.CreditCard }))
                            .pluck("amount").forEach(function (amount) { totalCreditCard = Math.round((totalCreditCard + amount) * 1e12) / 1e12; }).value();
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
                };
                VendingMachineController.$inject = [
                    "$scope",
                    "$q",
                    "DrinkCanResource",
                    "PaymentResource",
                    "MachineResource"
                ];
                return VendingMachineController;
            }());
            Controllers.VendingMachineController = VendingMachineController;
        })(Controllers = Web.Controllers || (Web.Controllers = {}));
    })(Web = VendingMachine.Web || (VendingMachine.Web = {}));
})(VendingMachine || (VendingMachine = {}));
//# sourceMappingURL=VendingMachineController.js.map