/// <reference path="require.js" />
/// <reference path="jquery-2.0.2.js" />
define(["jquery" ,"jquery-ui"], function ($) {

    function buildLoginField() {
        return '<div id="forms">\
                <h1>Telerik Academy Battle Game</h1>\
            <ul>\
                <li><a href="#login">Log in</a></li>\
                <li><a href="#register">Register</a></li>\
                <li id="error-field"></li>\
            </ul>\
            <div id="login">\
                <label for="tb-login-username">Username: </label>\
                <input type="text" id="tb-login-username" />\
                <label for="tb-login-password">Password: </label>\
                <input type="text" id="tb-login-password" />\
                <a href="#/btn-login"><button>login</button></a>\
            </div>\
            <div id="register">\
                <label for="tb-register-username">Username: </label>\
                <input type="text" id="tb-register-username" />\
                <label for="tb-register-nickname">Nickname: </label>\
                <input type="text" id="tb-register-nickname" />\
                <label for="tb-register-password">Password: </label>\
                <input type="text" id="tb-register-password" />\
                <a href="#/btn-register"><button>Register</button></a>\
            </div>\
        </div>';
    };

    function buildGameContainer(nickname) {
        return '<span id="login-info"><span id="user-nickname">Hello, ' + $("<div />").html(nickname).text() + '!</span>\
                <button id="btn-logout">Logout</button></span>\
                <div id="create-game-holder">\
                <label for="tb-create-title">New game title:</label> <input type="text" id="tb-create-title"/>\
                <button id="btn-create-game">Create game</button></div>\
                <div id="error-field"></div>\
                <div id="open-games-wrapper"><h2>Open</h2>\
                <div id="open-games-container"></div></div>\
                <div id="active-games-wrapper"><h2>Active</h2>\
                <div id="active-games-container"></div></div>\
                <div id="game-field"></div>\
                <div id="game-holder">\
		        </div>\
                <div id="messages-wrapper"><h2>Messages</h2>\
                <div id="messages-holder">\
                </div></div>\
                <div id="scoreboard-wrapper"><h2>Scoreboard</h2>\
                <div id="scores-holder">\
                </div> </div>';
    }

    function buildOpenGames(games) {
        var list = '<ul>';

        for (var i = 0; i < games.length; i++) {
            var game = games[i];

            list += '<li data-game-id="' + $("<div />").html(game.id).text() + '">' + '<span>' + $("<div />").html(game.title).text() + '</span>' +
                "<span> created by " + $("<div />").html(game.creator).text() + '</span><button class="btn-join-game">Join game</button></li>';
        }

        list += "</ul>";

        return list;
    }

    function buildActiveGames(games, nickname) {
        var list = '<ul>';

        for (var i = 0; i < games.length; i++) {
            var game = games[i];

            list += '<li data-game-id="' + $("<div />").html(game.id).text()  + '">' + '<span>' + $("<div />").html(game.title).text() + '</span>' +
                "<span> created by " + $("<div />").html(game.creator).text() + '</span>';
            if (game.status == "in-progress") {
                list += '<button class="btn-expand-game">Expand game</button>';
            } else if (game.status == 'full' && game.creator == nickname) {
                list += '<button class="btn-start-game">Start game</button>';
            }

            list += '</li>';
        }

        list += "</ul>";
        return list;
    }

    function buildMessages(messages) {
        var list = '<ul class="messages">';

        for (var i = 0; i < messages.length; i++) {

            var message = messages[i];

            list += '<li class="' + $("<div />").html(message.type).text() + '">' + $("<div />").html(message.text).text() + '</li>';
        }

        list += '</ul>';
        return list;
    }

    function buildScoresField(scoresObjects) {
        var list = '<ul class="scores-list">';

        for (var i = 0; i < scoresObjects.length; i++) {
            var currentObject = scoresObjects[i];

            list += '<li>Nickname: ' +  $("<div />").html(currentObject.nickname).text() +
                ', Score: ' + $("<div />").html(currentObject.score).text() + ' points</li>';
        }
        list += '</ul>';
        return list;
    }

    function appendHeroes(owner) {

        for (var i = 0; i < owner.units.length; i++) {

            var unit = owner.units[i];

            var currentRow = unit.position.x;
            var currentColl = unit.position.y;

            var square = '<a href="#" class="hero" data-unit-id="' + $("<div />").html(unit.id).text() + '">';
            square += '<div class="characteristics">type: ' + $("<div />").html(unit.type).text() + '</div>';
            square += '<div class="characteristics">att: ' + $("<div />").html(unit.attack).text()  + '</div>';
            square += '<div class="characteristics">def: ' + $("<div />").html(unit.armor).text() + '</div>';
            square += '<div class="characteristics">health: ' + $("<div />").html(unit.hitPoints).text() + '</div>';
            suqare = "</a>";

            var element = $('#row' + currentColl + ' #coll' + currentRow);

            element.html(square);
            element.css("background", unit.owner);
            element.css('color', '#fff');
        }
    }

    function buildGameField(game) {
        var html = '<table border="1" cellspacing="5" cellpadding="5" data-game-id="'+ $("<div />").html(game.gameId).text() + '">\
        <tr>\
            <th id="game-title">' + $("<div />").html(game.title).text() + '</th>\
        </tr>\
        <tr>\
            <th class="player">' + $("<div />").html(game.red.nickname).text() + '</th>\
            <th class="player">' + $("<div />").html(game.blue.nickname).text() + '</th>\
        </tr>';
        
        for (var i = 0; i < 9; i++) {
            html += '<tr id="row' + i + '" data-row="'+i+'">';

            for (var j = 0; j < 9; j++) {
                html += '<td id="coll'+j+'" data-coll="'+j+'">';

                html += '</td>';
            }

            html += '</tr>';
        }
        
        return html;
    }

    function buildHeroButtons() {
        
    }

    return {
        getLoginField: buildLoginField,
        getGameContainer: buildGameContainer,
        getOpenGames: buildOpenGames,
        getActiveGames: buildActiveGames,
        getScores: buildScoresField,
        getGameField: buildGameField,
        getHeroes: appendHeroes,
        getMessages: buildMessages,
        getHeroButtons: buildHeroButtons
    }
});