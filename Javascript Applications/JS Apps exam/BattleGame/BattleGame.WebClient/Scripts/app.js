/// <reference path="libs/require.js" />
/// <reference path="libs/sammy-0.7.4.js" />
/// <reference path="libs/controller.js" />
/// <reference path="libs/mustache.js" />
/// <reference path="libs/http-requester.js" />
/// <reference path="libs/jquery-2.0.2.js" />


(function () {

    require.config({
        paths: {
            jquery: "libs/jquery-2.0.2",
            "sammy": "libs/sammy-0.7.4",
            mustache: "libs/mustache",
            controllers: "libs/controller",
            "http-requester": "libs/http-requester",
            "class": "libs/class",
            ui: "libs/ui",
            "sha1": "libs/sha1",
            underscore: "libs/underscore",
            "persister": "libs/persister",
            "jquery-ui": "libs/jquery-ui-1.10.3",
            
        }
    })

    require(["jquery", "sammy", "controllers"],
        function ($, sammy, controllers) {

            var controller = controllers.get();

            var app = sammy("#wrapper", function () {

                this.get("#/", function () {
                    controller.loadUI("#wrapper");
                });

                this.get("#/btn-login", function () {
                    //alert("login");
                    controller.login();
                });

                this.get("#/btn-register", function () {
                    //alert("register");
                    controller.register();
                });

            });

            $( function () {
            app.run("#/");
            });

        })
})();