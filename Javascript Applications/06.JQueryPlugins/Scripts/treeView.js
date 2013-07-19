(function ($) {
    $.fn.treeView = function () {
        var parent = $(this);

        parent.on("mouseover", "li", function (ev) {
            ev.stopPropagation();
            var element = $(this);
            element.css({
                background: "#ddd"
            });
            element.children().css({
                background: "#ddd"
            });
        });

        parent.on("mouseout", "li", function (ev) {
            var element = $(this);
            element.css({
                background: "#fff"
            });
            element.children().css({
                background: "#fff"
            });
        });

        parent.on("click", "li", function (ev) {
            ev.stopPropagation();
            var element = $(this);
            console.log(element);
            element.children().children().slideToggle();
        });
    }
}(jQuery));