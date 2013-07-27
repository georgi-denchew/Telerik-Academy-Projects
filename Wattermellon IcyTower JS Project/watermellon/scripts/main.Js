function doKeyDown(e)
{

    container.handleKeyDown(e);

}

function doKeyUp(e) {

    container.handleKeyUp(e);

}

function doKeyPress(e) {
    container.handleKeyPress(e);

}



var canvas = document.getElementById("gameContainer");
canvas.addEventListener("keydown", doKeyDown, true);
canvas.addEventListener("keypress", doKeyPress, true);
canvas.addEventListener("keyup", doKeyUp, true);
var ctx = canvas.getContext("2d");
var container = containerConstructor.constructMainMenu(ctx);

if (localStorageManager.getPlayerType() == null)
{
    localStorageManager.setPlayerType(1);
}

if (localStorageManager.getFloorColor() == null) {
    localStorageManager.setFloorColor('rgb(255,255,255)');
}

$("#gameContainer").click(function (e)
{
    var x = Math.floor(e.pageX - $("#gameContainer").offset().left);
    var y = Math.floor(e.pageY - $("#gameContainer").offset().top);
    var result = container.handleClick(x, y);
    if (result!=0)
    {
        if (result==1)
        {
            var playerType = localStorageManager.getPlayerType();
            var floorColor = localStorageManager.getFloorColor();
            var img = new Image();
            img.onload = function ()
            {
                container = new gameContainer(550, 500, ctx, img, playerType, floorColor);
            };
            img.src = "images/bricks.jpg";
            //call gameContainer
            
        }
        else if (result == 2)
        {
            container = containerConstructor.constructSettingsMenu(ctx);
        }
        else if (result == 3)
        {
            container = containerConstructor.constructAboutPage(ctx);
        }
        else if (result == 4)
        {
            container = containerConstructor.constructMainMenu(ctx);
        }
        else if (result > 10 && result<20)
        {
            localStorageManager.setPlayerType(result%10);
        }
        else if (result > 20) 
        {
            if (result == 21)
            {
                localStorageManager.setFloorColor('rgb(255,255,255)');
            }
            if (result == 22) {
                localStorageManager.setFloorColor('rgb(0,255,0)');
            }
            if (result == 23) {
                localStorageManager.setFloorColor('rgb(100,100,100)');
            }
        }
        container.redraw();
    }
});

function getMousePos(canvas, evt)
{
    var rect = canvas.getBoundingClientRect();
    return {
        x: evt.clientX - rect.left,
        y: evt.clientY - rect.top
    };
}

canvas.addEventListener('mousemove', function (evt)
{
    var mousePos = getMousePos(canvas, evt);
    var message = 'Mouse position: ' + mousePos.x + ',' + mousePos.y;
    container.handleHover(mousePos.x, mousePos.y);
}, false);

container.redraw();