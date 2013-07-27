var Character = Class.create(
    {
        init: function (positionX, positionY, width, height, canvas, img) {
            this.positionX = positionX;
            this.positionY = positionY;
            this.width = width;
            this.height = height;
            this._canvas = canvas;
            this.img = img;
            this.speed = 5;
            this.jumpHeight = 90;
            this.state = "stable";
            this.orientation = "normal";

            this._keysDown = {};            
            var self = this;

            addEventListener("keydown", function (e) {
                self._keysDown[e.keyCode] = true;
            }, false);

            addEventListener("keyup", function (e) {
                delete self._keysDown[e.keyCode];
                this.orientation = "normal";
            }, false);		
        },

        update: function (modifier) {
            if (this.state === "falling") {
                this.positionY += this.speed;
            }
            if (this.state === "jumping") {                
                this.positionY -= this.speed;
                console.log(this.jumpPosition - this.jumpHeight);
                console.log(this.positionY);
                if (this.positionY < this.jumpPosition - this.jumpHeight) {
                    this.state = "falling";
                }
                console.log(this.positionY);
            }
            if (38 in this._keysDown) { // Player holding up
                this.jumpPosition = this.positionY;
                if (this.state === "stable") { 
                    this.state = "jumping";
                }
            }
            if (37 in this._keysDown) { // Player holding left
                this.positionX -= this.speed;
                this.orientation = "left";
            }
            if (39 in this._keysDown) { // Player holding right
                this.positionX += this.speed;
                this.orientation = "right";                
            }
        },

        checkCollision: function (){

        },
		
        draw: function ()
        {
            var characterImg = new Image();
            if (this.orientation === "normal") {
                if (this.state === "jumping") {
                    characterImg.src = "images/ninja-jump-up.png";
                }
                else {
                    characterImg.src = "images/ninja-normal.png";
                }
            }
            else if (this.orientation === "left") {
                if (this.state === "jumping") {
                    characterImg.src = "images/ninja-jump-left.png";
                }
                else if (this.state === "falling") {
                    characterImg.src = "images/ninja-walk-left-2.png";
                }
                else if (this.positionX % 4 == 0) {
                    characterImg.src = "images/ninja-walk-left-2.png";
                }
                else {
                    characterImg.src = "images/ninja-walk-left-1.png";
                }
            }
            else if (this.orientation === "right") {
                if (this.state === "jumping") {
                    characterImg.src = "images/ninja-jump-right.png";
                }
                else if (this.state === "falling") {
                    characterImg.src = "images/ninja-walk-right-2.png";
                }
                else if (this.positionX % 4 == 0) {
                    characterImg.src = "images/ninja-walk-right-2.png";
                }
                else {
                    characterImg.src = "images/ninja-walk-right-1.png";
                }
            }

            this.img = characterImg;
            this._canvas.drawImage(this.img, this.positionX, this.positionY, this.width, this.height);
        }
    });