module("Snake.init");

test("When snake is initialized, should set the correct values", function() {
  var position = {
    x: 150,
    y: 150
  };
  var speed = 15;
  var direction = 0;
  var snake = new snakeGame.Snake(position, speed, direction);

  equal(position, snake.position, "Position is set");
  equal(speed, snake.speed, "Speed is set");
  equal(direction, snake.direction, "Direction is set");
});

test("When snake is initialized, should contain 5 SnakePieces", function() {
  var position = {
    x: 150,
    y: 150
  };
  var speed = 15;
  var direction = 0;
  var snake = new snakeGame.Snake(position, speed, direction);

  ok(snake.pieces,"SnakePieces are created");
  equal(snake.pieces.length, 5,"Five SnakePieces are created");
  ok(snake.head, "HeadSnakePiece is created");
});


module("Snake.Consume");
test("When object is Food, should grow", function() {
  var snake = new snakeGame.Snake({
    x: 150,
    y: 150
  }, 15, 0);
  var size = snake.size;
  snake.consume(new snakeGame.Food());
  var actual = snake.size;
  var expected = size + 1;
  equal(actual, expected);
});

test("When object is SnakePiece, should die", function() {
  var snake = new snakeGame.Snake({
    x: 150,
    y: 150
  }, 15, 0);

  var isDead = false;

  snake.addDieHandler(function() {
    isDead = true;
  });

  snake.consume(new snakeGame.SnakePiece());
  ok(isDead, "The snake is dead");
});

test("When object is Obstacle, should die", function() {
  var snake = new snakeGame.Snake({
    x: 150,
    y: 150
  }, 15, 0);

  var isDead = false;

  snake.addDieHandler(function() {
    isDead = true;
  });

  snake.consume(new snakeGame.Obstacle());
  ok(isDead, "The snake is dead");
});


(function () {

    module("Snake.changeDirection");

    QUnit.testStart(function () {
        snake = new snakeGame.Snake({
            x: 150,
            y: 150
        }, 1, 0);
    });

    var snake;

    test("Switch from direction 0 to 1 (checking the head direction change)", function () {
        var head = snake.pieces[0];
        var newDirection = 1;
        snake.changeDirection(newDirection);

        equal(head.direction, newDirection);
    });

    test("Switch from direction 0 to 2 - no change expected (checking the head direction change)", function () {
        var head = snake.pieces[0];
        var oldDirection = snake.direction;
        var newDirection = 2;
        snake.changeDirection(newDirection);

        equal(head.direction, oldDirection);
    });

    test("Switch from direction 0 to 3 (checking the head direction change)", function () {
        var head = snake.pieces[0];
        var newDirection = 3;
        snake.changeDirection(newDirection);

        equal(head.direction, newDirection);
    });

    test("Switch from direction 0 to 0 - no change expected (checking the head direction change)", function () {
        var head = snake.pieces[0];
        var oldDirection = snake.direction;
        var newDirection = 0;
        snake.changeDirection(newDirection);

        equal(head.direction, oldDirection);
    });

    module("Snake.move");
    test("Move the snake - pieces positioning check", function () {

        var currentSpeed = snake.speed;

        var expectedPositionX;
        var expectedPositionY;
        
        for (var i = snake.pieces.length - 1; i >= 0; i-=1) {

            expectedPositionX = snake.pieces[i].position.x - currentSpeed;
            expectedPositionY = snake.pieces[i].position.y;

            snake.move();

            equal(snake.pieces[i].position.x, expectedPositionX, "Snake piece at expected horizontal position");
            equal(snake.pieces[i].position.y, expectedPositionY, "Snake piece at expected vertical position");
        }
    });

    module("Snake.grow");
    test("Increasing snake length", function () {

        var oldLength = snake.pieces.length;

        snake.grow();

        var expected = oldLength + 1;
        var actual = snake.pieces.length;

        equal(expected, actual);
    });

    module("Snake.checkSelf-eating");
    test("Check if snake is self-eating/self-hitting", function () {

        var X = snake.pieces[3].position.x;
        var Y = snake.pieces[3].position.y;

        snake.pieces[0].position = {
            x: X,
            y: Y
        };

        snake.checkSelfEating();

        equal(snake.selfEating, true);
    });
})();