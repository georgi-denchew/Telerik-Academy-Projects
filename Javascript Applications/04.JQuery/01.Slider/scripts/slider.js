$(document).ready(function () {

    var rightButton = $("#right_button");
    var leftButton = $("#left_button");

    // gets the list-item width (including it's paddings and margins)
    var listItemWidth = $("#slider_list li").outerWidth(true);
    var list = $("#slider_list");

    rightButton.click(function () {
        list.animate({
            // substracts the list-item width from the left position
            // so that the unordered list can move "to the right"
            left: parseInt(list.css('left')) - listItemWidth + 'px',
        }, 500, function () {
            $("#slider_list li:last").after($("#slider_list li:first"));
            list.css('left', '-666px');
        });
    });

    leftButton.click(function () {
        list.animate({
            // adds the list-item width to the left position
            // so that the unordered list can move "to the left"
            left: parseInt(list.css('left')) + listItemWidth + 'px',
        }, 500, function () {
            $("#slider_list li:first").before($("#slider_list li:last"));
            list.css('left', '-666px');
        });
    });

    setInterval(function () {
        rightButton.click();
    }, 5000);
});