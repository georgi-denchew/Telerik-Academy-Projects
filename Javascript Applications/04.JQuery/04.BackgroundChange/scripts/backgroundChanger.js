$(document).ready(function () {

    var colorPicker = $('input[type=text]').ColorPicker({
        onSubmit: function (hsb, hex, rgb, el) {
            $(el).val(hex);
            $(el).ColorPickerHide();
        }
    });

    var colorChanger = $("#color_changer");

    colorChanger.click(function () {
        var body = $('body');
        body.css('background-color', '#' + colorPicker.val());
    });
});