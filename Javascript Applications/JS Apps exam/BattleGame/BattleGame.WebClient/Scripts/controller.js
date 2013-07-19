/// <reference path="class.js" />
/// <reference path="persister.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="jquery-ui-1.10.3.js" />
/// <reference path="ui.js" />

var controllers = (function () {

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

            this.attachUIEventHandlers(selector);
        },

        loadGameUI: function (selector) {
            var html = ui.getGameContainer(this.persister.nickname());
            $(selector).html(html);

            this.persister.user.scores(function (scoresObjects) {
                var scoresField = ui.getScores(scoresObjects);
                $(selector + " #scores-holder").html(scoresField);

            }, function (errorObject) {
            });

            this.persister.game.open(function (games) {
                var list = ui.getOpenGames(games);
                $(selector + " #open-games-container").html(list);
            }, function (errorObject) {
            });

            var self = this;
            this.persister.game.myActive(function (games) {
                var list = ui.getActiveGames(games, self.persister.nickname());
                $(selector + " #active-games-container").html(list);

            }, function (errorrObject) {
            });

            this.persister.messages.all(function (messages) {
                var list = ui.getMessages(messages);
                $(selector + " #messages-holder").html(list);
            });
        },

        loadLoginFormsUI: function (selector) {
            var loginFormHtml = ui.getLoginField();
            $(selector).html(loginFormHtml);
            $("#forms").tabs();
        },

        loadGameField: function (selector, gameId) {
            this.persister.game.field(gameId, function (game) {
                self.currentGame = game;

                var html = ui.getGameField(game);
                $(selector + " #game-field").html(html);
                ui.getHeroes(game.red);
                ui.getHeroes(game.blue);


            }, function (error) {
                var errorObject = JSON.parse(error.responseText);
                $("#error-field").html(errorObject.Message);
            });
        },

        attachUIEventHandlers: function (selector) {
            var wrapper = $(selector);
            var self = this;

            wrapper.on("click", "#btn-login", function () {
                var user = {
                    username: $(selector + " #tb-login-username").val(),
                    password: $(selector + " #tb-login-password").val(),
                }

                self.persister.user.login(
                    user,
                    function () {
                        $("#forms").hide("highlight", {}, 1000);
                        self.loadGameUI(selector);
                    },
                        function (error) {
                            var errorObject = JSON.parse(error.responseText);
                            $("#error-field").html(errorObject.Message);
                        });

                return false;
            });

            wrapper.on("click", "#btn-register", function () {
                var user = {
                    username: $(selector + " #tb-register-username").val(),
                    nickname: $(selector + " #tb-register-nickname").val(),
                    password: $(selector + " #tb-register-password").val()
                };
                self.persister.user.register(
                    user,
                    function (data) {
                        $("#forms").hide("highlight", {}, 1000);
                        self.loadGameUI(selector);
                    },
                function (error) {
                    var errorObject = JSON.parse(error.responseText);
                    $("#error-field").html(errorObject.Message);
                });
                return false;
            });

            wrapper.on('click', '#btn-logout', function () {
                self.persister.user.logout(function () {
                    self.loadLoginFormsUI(selector);
                }, function (error) {
                    var errorObject = JSON.parse(error.responseText);
                    $("#error-field").html(errorObject.Message);
                })

            });

            wrapper.on('click', '#btn-create-game', function () {
                var game = {
                    title: $("#tb-create-title").val()
                }
                self.persister.game.create(game, function (successObject) {
                    $("#tb-create-title").val(null);
                }, function (errorObject) {
                    var responseText = JSON.parse(errorObject.responseText);
                    $("#error-field").html(responseText.Message);
                });

            });

            wrapper.on('click', '.btn-join-game', function () {
                debugger;
                var game = {
                    id: $(this).parents("li").first().data("game-id"),
                };
                self.persister.game.join(game);
            });

            wrapper.on('click', '.btn-start-game', function () {
                debugger;
                var gameId = $(this).parents("li").first().data("game-id");

                self.persister.game.start(gameId);
            });

            wrapper.on('click', '.btn-expand-game', function () {

                var gameId = $(this).parents("li").first().data("game-id");

                self.loadGameField(selector, gameId);

            });

            wrapper.on('click', '.hero', function (ev) {
                ev.stopPropagation();

                var selected = $("#selected");
                selected.attr("id", null);
                $(this).attr("id", "selected");
            });

            wrapper.on('click', "td", function () {
                debugger;
                var current = $(this);

                if (current.children("a").length == 0) {

                    var pos = {
                        x: current.data('coll'),
                        y: current.parent().data('row')
                    };

                    var currentUnitId = $("#selected").data("unit-id");

                    var data = {
                        unitId: currentUnitId,
                        position: pos
                    };

                    var gameId = $("table").data("game-id");
                    
                    if (currentUnitId) {
                        self.persister.battle.move(gameId, data, function () {
                            self.loadGameField(selector, gameId);
                        }, function (error) {
                            var errorObject = JSON.parse(error.responseText);
                            $("#error-field").html(errorObject.Message);
                        })
                    }
                }
            });
        }
    });

    return {
        get: function () {
            return new Controller();
        }
    }

})();

$(function () {
    var controller = controllers.get();
    controller.loadUI("#wrapper");
});