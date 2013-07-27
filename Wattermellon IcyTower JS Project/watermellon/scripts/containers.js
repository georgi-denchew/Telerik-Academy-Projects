var containerConstructor =
{
    constructMainMenu: function (canvas)
    {
        var container = new Container(550, 500, ctx, 0);

        var img = new Image();
        img.onload = function () {
            container.img = img;
            container.redraw();
        };
        img.src = "images/UnityPlayer.png";

        var newGameButton = new Button(200, 100, 200, 50, ctx, "New Game", 1);
        container.addUiElement(newGameButton);
        var SettingsButton = new Button(200, 200, 200, 50, ctx, "Settings", 2);
        container.addUiElement(SettingsButton);
        var AboutButton = new Button(200, 300, 200, 50, ctx, "About", 3);
        container.addUiElement(AboutButton);

        return container;
    },

    constructSettingsMenu: function (canvas)
    {
        var container = new Container(550, 500, ctx, 0);

        var img = new Image();
        img.onload = function () {
            container.img = img;
            container.redraw();
        };
        img.src = "images/icon_small_settings1.png";

        var backButton = new Button(50, 30, 100, 25, ctx, "< Back", 4);

        var mexicanCheckButton = new Button(30, 150, 100, 30, ctx, "Mexican", 11);

        var japaneseCheckButton = new Button(160, 150, 100, 30, ctx, "Japanese", 12);

        var ninjaCheckButton = new Button(290, 150, 100, 30, ctx, "Ninja", 13);


        var whiteCheckButton = new Button(30, 250, 100, 30, ctx, "White", 21);

        var greenCheckButton = new Button(160, 250, 100, 30, ctx, "Green", 22);

        var grayCheckButton = new Button(290, 250, 100, 30, ctx, "Gray", 23);

        var playerLabel = new Label(150, 80, 100, 30, ctx, 1);

        var floorLabel = new Label(150, 200, 100, 30, ctx, 2);

        container.addUiElement(backButton);
        container.addUiElement(mexicanCheckButton);
        container.addUiElement(japaneseCheckButton);
        container.addUiElement(ninjaCheckButton);

        container.addUiElement(whiteCheckButton);
        container.addUiElement(greenCheckButton);
        container.addUiElement(grayCheckButton);

        container.addUiElement(playerLabel);
        container.addUiElement(floorLabel);

        return container;
    },

    constructAboutPage: function (canvas)
    {
        var container = new Container(550, 500, ctx, 0);

        var img = new Image();
        img.onload = function () {
            container.img = img;
            container.redraw();
        };
        img.src = "images/About.png";

        var backButton = new Button(50, 30, 100, 25, ctx, "< Back", 4);
        container.addUiElement(backButton);

        return container;
    }
};
