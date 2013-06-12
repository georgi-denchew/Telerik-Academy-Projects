$(document).ready(function () {
    $('#generator').click(function (ev) {

        ev.preventDefault();
        ev.stopPropagation();
        var newContent = $(document.createElement('p'));
        newContent.text($("#content").val());
        var positionContent = $("#position_related").val();
        var position = $("input[name=position]:checked").val();
        var paragraphs = $("p");

        for (var i = 0; i < paragraphs.length; i++) {
            if (positionContent === $(paragraphs[i]).text()) {

                if (position === 'before') {
                    $(paragraphs[i]).before(newContent);
                }
                else {
                    $(paragraphs[i]).after(newContent);
                }
            }
        }
    });
});