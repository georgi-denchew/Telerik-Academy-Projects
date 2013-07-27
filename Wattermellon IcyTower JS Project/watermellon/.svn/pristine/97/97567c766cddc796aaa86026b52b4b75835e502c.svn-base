var Floor = Class.create(
    {
        init: function (positionX, positionY, width, height, canvas, color) {

            this._super.init(positionX, positionY, width, height, canvas);
            this._color = color

        },

        draw: function ()
        {

            var canvas = this._super._super._canvas;
            var positionX = this._super._super.positionX;
            var positionY = this._super._super.positionY;
            var height = this._super._super.height;
            var width = this._super._super.width;

            canvas.fillStyle = this._color;
            canvas.fillRect(positionX, positionY + height / 3, width, height - height / 3);


            canvas.strokeStyle = 'rgb(0,0,0)';
            canvas.beginPath();
            canvas.moveTo(positionX, positionY + height);
            canvas.lineTo(positionX + width, positionY + height);

            canvas.moveTo(positionX, positionY + height / 3);
            canvas.lineTo(positionX, positionY + height);

            canvas.moveTo(positionX + width, positionY + height / 3);
            canvas.lineTo(positionX + width, positionY + height);

            canvas.lineWidth = 2;
            canvas.stroke();
            canvas.closePath();

            canvas.beginPath();
            canvas.moveTo(positionX, positionY + height / 3);

            canvas.lineTo(positionX + width, positionY + height / 3);
            canvas.lineTo(positionX + width - 6, positionY);
            canvas.lineTo(positionX + 6, positionY);
            canvas.lineTo(positionX,positionY + height / 3);

            canvas.lineWidth = 2;
            canvas.stroke();
            canvas.fill();



        }

    });

Floor.inherit(gameObject);