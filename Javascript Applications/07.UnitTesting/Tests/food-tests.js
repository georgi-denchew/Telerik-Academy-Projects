(function () {

    module("Food tests");

    test("Constructor Test", function () {

        var position = {
            x: 10,
            y: 20
        }, size = 5;

        var food = new snakeGame.Food(position, size);

        equal(food.position.x, position.x, "Checking food horizontal positioning");
        equal(food.position.y, position.y, "Checking food vertical positioning");
        equal(food.size, size, "Checking food size");
    });
})();