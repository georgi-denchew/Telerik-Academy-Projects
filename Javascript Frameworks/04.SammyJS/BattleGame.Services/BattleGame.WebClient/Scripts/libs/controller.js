/// <reference path="class.js" />
/// <reference path="persister.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="jquery-ui-1.10.3.js" />
/// <reference path="ui.js" />
/// <reference path="require.js" />

define(["class", "persister", "ui"], function (Class, persister, ui) {

    var rootUrl = "http://localhost:22954/api/";


    var Controller = Class.create({
        init: function () {
            this.persister = persister.get(rootUrl);
        },

        loadUI: function (selector) {
            if (this.persister.isUserLoggedIn()) {

                this.loadGameUI(selector);
            }
            else {
                this.loadLoginFormsUI(selector);
            }
        },

        loadGameUI: function (selector) {
            var html = ui.getGameContainer(this.persister.nickname());
            $(selector).html(html);

            this.attachEvents();
        },

        loadOpenGames: function (selector) {
            this.persister.game.open(function (games) {
                var list = ui.getOpenGames(games);
                $(selector).hide("drop", { direction: "down" }, 500, function () {
                    $(selector).children().remove();
                    $(selector).append(list);
                    $(selector).show();
                });
            }, function (errorObject) {
            })
        },

        attachEvents: function () {
            var self = this;
            $(".navbar").on("click", "li", function (ev) {
                $(".active").removeClass("active");

                console.log(ev);

                $(ev.target).parent("li").addClass("active");
            });

            $(".navbar").on("click", "#logout", function () {
                self.logout("#wrapper");
            });
        },

        loadActiveGames: function (selector) {
            var self = this;
            this.persister.game.myActive(function (games) {
                var list = ui.getActiveGames(games, self.persister.nickname());
                $(selector).hide("drop", { direction: "down" }, 500, function () {
                    $(selector).children().remove();
                    $(selector).append(list);
                    $(selector).show();
                });
            }, function (errorrObject) {
            });
        },
        //    this.persister.messages.all(function (messages) {
        //        var list = ui.getMessages(messages);
        //        $(selector + " #messages-holder").append(list);
        //    });
        //},

        loadLoginFormsUI: function (selector) {
            var loginFormHtml = ui.getLoginField();
            $(selector).html(loginFormHtml);
            $("#forms").tabs();
        },

        loadGameField: function (selector, gameId) {
            var self = this;

            this.persister.game.field(gameId, function (game) {
                self.currentGame = game;

                var html = ui.getGameField(game);
                $(selector).html(html);

                ui.getHeroes(game.red);
                ui.getHeroes(game.blue);


            }, function (error) {
                var errorObject = JSON.parse(error.responseText);
                $("#error-field").html(errorObject.Message);
            });
        },

        login: function (selector) {
            var self = this;

            var user = {
                username: $("#tb-login-username").val(),
                password: $("#tb-login-password").val(),
            }

            self.persister.user.login(
                user,
                function () {
                    $("#forms").hide("drop", { direction: "down" }, 1000, self.loadGameUI(selector));

                },
                function (error) {
                    var errorObject = JSON.parse(error.responseText);
                    $("#error-field").html(errorObject.Message);
                });
        },


        register: function (selector) {
            var self = this;
            var user = {
                username: $("#tb-register-username").val(),
                nickname: $("#tb-register-nickname").val(),
                password: $("#tb-register-password").val()
            };
            this.persister.user.register(
                user,
                function (data) {
                    $("#forms").hide();
                    self.loadGameUI(selector);
                },
            function (error) {
                var errorObject = JSON.parse(error.responseText);
                $("#error-field").html(errorObject.Message);
            });
        },

        logout: function (selector) {
            this.persister.user.logout();
            this.loadLoginFormsUI(selector);
        },

        joinGame: function (gameId) {
            debugger;
            var game = {
                id: gameId,
            };
            this.persister.game.join(game);
            this.loadGameUI("#wrapper");
        },

        expandGame: function (selector ,gameId)
        {
                //var gameId = $(this).parents("li").first().data("game-id");

                this.loadGameField(selector, gameId);
        },

        //wrapper.on('click', '#btn-create-game', function () {
        //    var game = {
        //        title: $("#tb-create-title").val()
        //    }
        //    self.persister.game.create(game, function (successObject) {
        //        $("#tb-create-title").val(null);
        //    }, function (errorObject) {
        //        var responseText = JSON.parse(errorObject.responseText);
        //        $("#error-field").html(responseText.Message);
        //    });

        //});

        //wrapper.on('click', '.btn-start-game', function () {
        //    debugger;
        //    var gameId = $(this).parents("li").first().data("game-id");

        //    self.persister.game.start(gameId);
        //});


        //wrapper.on('click', '.btn-expand-game', function () {

        

        //});

        //wrapper.on('click', '.hero', function (ev) {
        //    ev.stopPropagation();

        //    var selected = $("#selected");
        //    selected.attr("id", null);
        //    $(this).attr("id", "selected");
        //});

        //wrapper.on('click', "td", function () {
        //    debugger;
        //    var current = $(this);

        //    if (current.children("a").length == 0) {

        //        var pos = {
        //            x: current.data('coll'),
        //            y: current.parent().data('row')
        //        };

        //        var currentUnitId = $("#selected").data("unit-id");

        //        var data = {
        //            unitId: currentUnitId,
        //            position: pos
        //        };

        //        var gameId = $("table").data("game-id");

        //        if (currentUnitId) {
        //            self.persister.battle.move(gameId, data, function () {
        //                self.loadGameField(selector, gameId);
        //            }, function (error) {
        //                var errorObject = JSON.parse(error.responseText);
        //                $("#error-field").html(errorObject.Message);
        //            })
        //        }
        //    }
        //});
        //}
    });

    return {
        get: function () {
            return new Controller();
        }
    }

});