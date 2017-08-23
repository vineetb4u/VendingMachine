module VendingMachine.Web.Services {
    export class ApiBaseService {
        public static $inject: any[] = [];

        public apiBase: string;

        constructor() {
            this.apiBase = $("link[rel='apiBaseUrl']").attr("href");
        }
    }
} 