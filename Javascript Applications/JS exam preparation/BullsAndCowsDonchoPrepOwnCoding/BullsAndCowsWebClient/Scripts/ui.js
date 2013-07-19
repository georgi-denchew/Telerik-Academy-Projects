var ui = (function () {

    function buildGuessTable(guesses) {
        var tableHTML = '<table border="1" cellspacing="0" cellpadding="5">\
<tr><th>Number</th><th>Cows</th><th>Bulls</th></tr>';

        for (var i = 0; i < guesses.length; i++) {
            var guess = guesses[i];

            tableHTML += '<tr><td>' + guess.number +'</td><td>' + guess.cows + '</td><td>' +
                guess.bulls + '</td></tr>';
        }

        tableHTML += '</table>';
        return tableHTML;
    }


    return {
        gameUI: function (nickname) {
            return '<span id="user-nickname">Hello, ' + nickname + '!</span>\
                <button id="btn-logout">Logout</button>\
                <div id="create-game-holder">\
                Title: <input type="text" id="tb-create-title"/>\
                Password: <input type="text" id="tb-create-password"/>\
                Number: <input type="text" id="tb-create-number"/>\
                <button id="btn-create-game">Create</button></div>\
                <h2>Open</h2>\
                <div id="open-games-container"></div>\
                <h2>Active</h2>\
                <div id="active-games-container"></div>\
                <div id="game-holder">\
		        </div>\
                <h2>Messages</h2>\
                <div id="messages-holder">\
                </div>';
        },

        generateOpenGames: function (games) {
            var list = '<ul>';

            for (var i = 0; i < games.length; i++) {
                var game = games[i];

                list += '<li data-game-id="' + game.id + '">' + '<a href="#" class="game"> ' + $("<div />").html(game.title).text() + " </a>" +
                    "<span>" + game.creatorNickname + "</span></li>";
            }

            list += "</ul>";

            return list;
        },

        generateActiveGames: function (games) {
            var gamesList = Array.prototype.slice.call(games, 0);
            gamesList.sort(function (g1, g2) {
                if (g1.status == g2.status) {
                    return g1.title > g2.title;
                }
                else {
                    if (g1.status == "in-progress") {
                        return -1;
                    }
                }
                return 1;
            });
            var list = '<ul class="game-list active-games">';

            for (var i = 0; i < gamesList.length; i++) {
                var game = gamesList[i];

                list += '<li data-game-id="' + game.id + '">' + '<a href="#" class="' + game.status + '"> ' + $("<div />").html(game.title).text() + " </a>" +
                    "<span>" + game.creatorNickname + "</span></li>";
            }

            list += "</ul>";
            return list;
        },

        generateLoginForms: function () {
            return '<div id="forms">\
            <ul>\
                <li><a href="#login">Log in</a></li>\
                <li><a href="#register">Register</a></li>\
            </ul>\
            <div id="login">\
                <label for="tb-login-username">Username: </label>\
                <input type="text" id="tb-login-username" />\
                <label for="tb-login-password">Password: </label>\
                <input type="text" id="tb-login-password" />\
                <button id="btn-login">login</button>\
            </div>\
            <div id="register">\
                <label for="tb-register-username">Username: </label>\
                <input type="text" id="tb-register-username" />\
                <label for="tb-register-nickname">Nickname: </label>\
                <input type="text" id="tb-register-nickname" />\
                <label for="tb-register-password">Password: </label>\
                <input type="text" id="tb-register-password" />\
                <button id="btn-register">Register</button>\
            </div>\
        </div>';
        },

        buildGameState: function (gameState) {
            var html = '<div id="game-state" data-game-id"' + gameState.id + '">\
<h2>' + gameState.title + '</h2>\
<div id="blue-guesses" class="guess-holder"><h3>' +
gameState.blue + '\'s guesses</h3>' + buildGuessTable(gameState.blueGuesses) + '</div>\
<div id="red-guesses" class="guess-holder"><h3>' + gameState.red + '</h3>' + buildGuessTable(gameState.redGuesses) +
'</div></div><label for="tb-make-guess">Enter guess:</label><input type="text" id="tb-make-guess" />\
<button id="make-guess">Make guess</button>';
            return html;
        },

        buildMessages: function (messages) {
            var list = '<ul class="messages">';

            for (var i = 0; i < messages.length; i++) {

                var message = messages[i];

                list += '<li class="' + message.type + '">' + message.text + '</li>';
            }

            list += '</ul>';
            return list;
        }

    }
})();