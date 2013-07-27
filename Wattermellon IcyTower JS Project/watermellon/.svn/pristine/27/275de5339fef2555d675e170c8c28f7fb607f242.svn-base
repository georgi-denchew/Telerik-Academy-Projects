var Container = Class.create(
    {
        init: function (width, height, canvas, img)
        {
            this.width = width;
            this.height = height;
            this._canvas = canvas;
            this._uiElements = new Array();
            this.img = img;
        },

        redraw: function ()
        {
            this._canvas.clearRect(0, 0, this.width, this.height);

            if (this.img)
            {
                this._canvas.drawImage(this.img, 0, 0, this.width, this.height);
            }
            
            for (var element in this._uiElements)
            {
                this._uiElements[element].draw(this._canvas);
            }
        },
        addUiElement: function (uiElelemnt)
        {
            this._uiElements.push(uiElelemnt);
        },

        handleClick: function (x, y) 
        {
            var clickResult = 0; // default is 0 - no acton required
            // this is not yet tested
            for (var element in this._uiElements)
            {
                
                //alert(x + " >= " + this._uiElements[element]._super.positionX);
                if (x >= this._uiElements[element]._super.positionX && y >= this._uiElements[element]._super.positionY &&
                    x <= this._uiElements[element]._super.positionX + this._uiElements[element]._super.width &&
                    y <= this._uiElements[element]._super.positionY + this._uiElements[element]._super.height
                    )
                {
                    //alert(JSON.stringify(this._uiElements[element]));
                    clickResult = this._uiElements[element].handleClick();
                }
            }

            return clickResult;
            //console.log(x + " " + y);
        },

        handleHover: function (x, y) 
        {
            for (var element in this._uiElements)
            {
                this._uiElements[element]._super.hovered = false;
                //alert(x + " >= " + this._uiElements[element]._super.positionX);
                if (x >= this._uiElements[element]._super.positionX && y >= this._uiElements[element]._super.positionY &&
                    x <= this._uiElements[element]._super.positionX + this._uiElements[element]._super.width &&
                    y <= this._uiElements[element]._super.positionY + this._uiElements[element]._super.height
                    )
                {
                    //alert("hover");
                    this._uiElements[element]._super.hovered = true;
                }
            }
            this.redraw();
            //console.log(x + " " + y);
        },

        handleKeyDown: function (e)
        {

        },

        handleKeyUp: function (e)
        {

        },

        handleKeyPress: function (e)
        {

        },
    });

var uiElement = Class.create(
    {
        init: function (positionX, positionY, width, height, canvas) {
            this.positionX = positionX;
            this.positionY = positionY;
            this.width = width;
            this.height = height;
            this._canvas = canvas;
            this.hovered = false;
        },
        draw: function ()
        {

        },

        handleClick: function ()
        {
            var clickResult = 0; // default is 0 - no acton required
            return clickResult;
        },
    });

var gameObject = Class.create(
    {
        init: function (positionX, positionY, width, height, canvas)
        {
            this._super.init(positionX, positionY, width, height, canvas);
        },
    });

gameObject.inherit(uiElement);


var playerDrawer = Class.create(
    {
        init: function () {
        },

        drawStill: function (x, y, ctx) {

        },

        drawRightStepOne: function (x, y, ctx) {

        },
        drawRightStepTwo: function (x, y, ctx) {

        },

        drawLeftStepOne: function (x, y, ctx) {

        },
        drawLeftStepTwo: function (x, y, ctx) {

        },

        drawJumpLeft: function (x, y, ctx) {

        },

        drawJumpRight: function (x, y, ctx)
        {

        }
    });
