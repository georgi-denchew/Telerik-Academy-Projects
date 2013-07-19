module("MovingGameObject.init (constructor)");
test("Testing constructor correct initialization", function () {
    var position = { x: 5, y: 7 },
        size = 5,
        fcolor = "#000",
        scolor = "#000",
        speed = 42,
        direction = 0;

    var movingObject =
        new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    equal(movingObject.position, position, "Checking position");
    equal(movingObject.size, size, "Checking size");
    equal(movingObject.fcolor, fcolor, "Checking fillcolor");
    equal(movingObject.scolor, scolor, "Checking stroke color");
});


module("MovingGameObject.move");
test("Move negative X (direction 0)", function () {

    var position = { x: 0, y: 0 },
        size = 5,
        fcolor = "#000",
        scolor = "#000",
        speed = 1,
        direction = 0;

    var movingObject =
        new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    var expectedPosition = {x: position.x - speed, y: position.y};

    movingObject.move();
    
    equal(movingObject.position.x, expectedPosition.x);
    equal(movingObject.position.y, expectedPosition.y);
});

test("Move positive X (direction 2)", function () {

    var position = { x: 0, y: 0 },
        size = 1,
        fcolor = "#000",
        scolor = "#000",
        speed = 1,
        direction = 2;

    var movingObject =
        new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    var expectedPosition = { x: position.x + speed, y: position.y };

    movingObject.move();

    equal(movingObject.position.x, expectedPosition.x);
    equal(movingObject.position.y, expectedPosition.y);
});

test("Move negative Y (direction 1)", function () {

    var position = { x: 0, y: 0 },
        size = 1,
        fcolor = "#000",
        scolor = "#000",
        speed = 1,
        direction = 1;

    var movingObject =
        new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    var expectedPosition = { x: position.x, y: position.y - speed};

    movingObject.move();

    equal(movingObject.position.x, expectedPosition.x);
    equal(movingObject.position.y, expectedPosition.y);
});

test("Move positive Y (direction 3)", function () {

    var position = { x: 0, y: 0 },
        size = 1,
        fcolor = "#000",
        scolor = "#000",
        speed = 1,
        direction = 3;

    var movingObject =
        new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    var expectedPosition = { x: position.x, y: position.y + speed };

    movingObject.move();

    equal(movingObject.position.x, expectedPosition.x);
    equal(movingObject.position.y, expectedPosition.y);
});


test("Move positive Y speed 10", function () {

    var position = { x: 0, y: 0 },
        size = 1,
        fcolor = "#000",
        scolor = "#000",
        speed = 10,
        direction = 3;

    var movingObject =
        new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);

    var expectedPosition = { x: position.x, y: position.y + speed };

    movingObject.move();

    equal(movingObject.position.x, expectedPosition.x);
    equal(movingObject.position.y, expectedPosition.y);
});

(function () {

    module("MovingGameObject.changeDirection");

    QUnit.testStart(function () {
        var position = { x: 0, y: 0 }, size = 1, fcolor = "#000", scolor = "#000", speed = 10,
            direction = 0;

        objectForDirectionTests = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
    });

    var objectForDirectionTests;

    test("Direction 0 change to 1", function () {

        var movingObject = objectForDirectionTests;

        var newDirection = 1;

        movingObject.changeDirection(newDirection);

        equal(movingObject.direction, newDirection);
    });

    test("Direction 0 change to 3", function () {

        var movingObject = objectForDirectionTests;

        var newDirection = 3;

        movingObject.changeDirection(newDirection);

        equal(movingObject.direction, newDirection);
    });


    test("Direction 0 change to 0 (no change)", function () {

        var movingObject =
            objectForDirectionTests;
        var oldDirection = movingObject.direction;
        movingObject.direction = 0;

        var newDirection = 0;

        movingObject.changeDirection(newDirection);

        equal(movingObject.direction, oldDirection);
    });

    test("Direction 0 change to 2 (no change)", function () {

        var movingObject =
            objectForDirectionTests;
        var oldDirection = movingObject.direction;
        movingObject.direction = 0;

        var newDirection = 2;

        movingObject.changeDirection(newDirection);

        equal(movingObject.direction, oldDirection);
    });

    test("Direction 0 change to 2 (no change)", function () {

        var movingObject =
            objectForDirectionTests;
        var oldDirection = movingObject.direction;
        movingObject.direction = 0;

        var newDirection = 2;

        movingObject.changeDirection(newDirection);

        equal(movingObject.direction, oldDirection);
    });

    test("Direction 1 change to 0", function () {

        var movingObject =
            objectForDirectionTests;
        movingObject.direction = 1;

        var newDirection = 0;

        movingObject.changeDirection(newDirection);

        equal(movingObject.direction, newDirection);
    });

    test("Direction 1 change to 2", function () {

        var movingObject =
            objectForDirectionTests;
        movingObject.direction = 1;

        var newDirection = 2;

        movingObject.changeDirection(newDirection);

        equal(movingObject.direction, newDirection);
    });

    test("Direction 1 change to 3 (no change)", function () {

        var movingObject =
            objectForDirectionTests;
        movingObject.direction = 1;

        var oldDirection = movingObject.direction;

        var newDirection = 3;

        movingObject.changeDirection(newDirection);

        equal(movingObject.direction, oldDirection);
    });

    test("Direction 1 change to 1 (no change)", function () {

        var movingObject =
            objectForDirectionTests;
        movingObject.direction = 1;

        var oldDirection = movingObject.direction;

        var newDirection = 1;

        movingObject.changeDirection(newDirection);

        equal(movingObject.direction, oldDirection);
    });

    test("Direction 2 change to 0 (no change)", function () {

        var movingObject =
            objectForDirectionTests;
        movingObject.direction = 2;

        var oldDirection = movingObject.direction;

        var newDirection = 0;

        movingObject.changeDirection(newDirection);

        equal(movingObject.direction, oldDirection);
    });

    test("Direction 2 change to 1", function () {

        var movingObject =
            objectForDirectionTests;
        movingObject.direction = 2;

        var newDirection = 1;

        movingObject.changeDirection(newDirection);

        equal(movingObject.direction, newDirection);
    });

    test("Direction 2 change to 3", function () {

        var movingObject =
            objectForDirectionTests;
        movingObject.direction = 2;

        var newDirection = 3;

        movingObject.changeDirection(newDirection);

        equal(movingObject.direction, newDirection);
    });

    test("Direction 2 change to 2 (no change)", function () {

        var movingObject =
            objectForDirectionTests;
        movingObject.direction = 2;

        var oldDirection = movingObject.direction;

        var newDirection = 2;

        movingObject.changeDirection(newDirection);

        equal(movingObject.direction, oldDirection);
    });

    test("Direction 3 change to 0", function () {

        var movingObject =
            objectForDirectionTests;
        movingObject.direction = 3;

        var newDirection = 0;

        movingObject.changeDirection(newDirection);

        equal(movingObject.direction, newDirection);
    });

    test("Direction 3 change to 1 (no change)", function () {

        var movingObject =
            objectForDirectionTests;
        movingObject.direction = 3;

        var oldDirection = movingObject.direction;

        var newDirection = 1;

        movingObject.changeDirection(newDirection);

        equal(movingObject.direction, oldDirection);
    });

    test("Direction 3 change to 2", function () {

        var movingObject =
            objectForDirectionTests;
        movingObject.direction = 3;

        var newDirection = 2;

        movingObject.changeDirection(newDirection);

        equal(movingObject.direction, newDirection);
    });

    test("Direction 3 change to 3 (no change)", function () {

        var movingObject =
            objectForDirectionTests;
        movingObject.direction = 3;

        var oldDirection = movingObject.direction;

        var newDirection = 3;

        movingObject.changeDirection(newDirection);

        equal(movingObject.direction, oldDirection);
    });

    QUnit.testStart(function () { });
})();