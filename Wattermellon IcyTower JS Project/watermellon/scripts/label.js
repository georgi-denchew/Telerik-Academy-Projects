var Label = Class.create(
    {
        init: function (positionX, positionY, width, height, canvas, binding)
        {

            this._super.init(positionX, positionY, width, height, canvas);
            this._binding = binding;

        },

        draw: function ()
        {
            var content = "";
            this._super._canvas.font = this._super.height / 2 + "px Arial";
            if (this._binding==1)
            {
                content = "Player: ";
                var playerType = localStorageManager.getPlayerType();
                switch (playerType)
                {
                    case '1': content += "Mexican"; break;
                    case '2': content += "Japanese"; break;
                    case '3': content += "Ninja"; break;
                    default: content += "Unknown"; break;
                }

                this._super._canvas.strokeText(content,
                this._super.positionX + this._super.height / 2,
                this._super.positionY + this._super.height / 2 + 5);
            }

            else if (this._binding == 2)
            {
                content = "Floor Color";
                var floorColor = localStorageManager.getFloorColor();
                this._super._canvas.fillStyle = floorColor;
                this._super._canvas.font = "bold "+this._super._canvas.font

                this._super._canvas.fillText(content,
                this._super.positionX + this._super.height / 2,
                this._super.positionY + this._super.height / 2 + 5);
            }            
        },
    });

Label.inherit(uiElement);