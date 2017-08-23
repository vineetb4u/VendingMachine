var VendingMachine;
(function (VendingMachine) {
    var Web;
    (function (Web) {
        var Enums;
        (function (Enums) {
            (function (PaymentType) {
                PaymentType[PaymentType["Cash"] = 1] = "Cash";
                PaymentType[PaymentType["CreditCard"] = 2] = "CreditCard";
            })(Enums.PaymentType || (Enums.PaymentType = {}));
            var PaymentType = Enums.PaymentType;
            (function (Flavour) {
                Flavour[Flavour["Banana"] = 1] = "Banana";
                Flavour[Flavour["Fruity"] = 2] = "Fruity";
                Flavour[Flavour["Grape"] = 3] = "Grape";
                Flavour[Flavour["Orange"] = 4] = "Orange";
                Flavour[Flavour["Pear"] = 5] = "Pear";
                Flavour[Flavour["Pineapple"] = 6] = "Pineapple";
                Flavour[Flavour["Sugar"] = 7] = "Sugar";
                Flavour[Flavour["Vanilla"] = 8] = "Vanilla";
                Flavour[Flavour["Wintergreen"] = 9] = "Wintergreen";
                Flavour[Flavour["Apple"] = 10] = "Apple";
            })(Enums.Flavour || (Enums.Flavour = {}));
            var Flavour = Enums.Flavour;
        })(Enums = Web.Enums || (Web.Enums = {}));
    })(Web = VendingMachine.Web || (VendingMachine.Web = {}));
})(VendingMachine || (VendingMachine = {}));
//# sourceMappingURL=Enums.js.map