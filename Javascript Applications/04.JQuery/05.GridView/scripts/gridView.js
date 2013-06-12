
$(document).ready(function () {
    var headerButton;
    var rowButton;
    var gridButton;

    headerButton = $(".header_row_generator");
    rowButton = $(".new_row_generator");
    gridButton = $('.nested_grid_generator');

    function headerButtonEvent(button) {
        var parent = $(button).parent(".grid");
        var header = $(document.createElement("header"));
        var headerText = parent.children(".header_row_content").val();
        header.text(headerText);
        header.css('text-align', 'center');
        header.css('font-weight', 'bold');

        $(button).siblings(".header_row_content").remove();
        $(button).remove();
        parent.prepend(header);
    };

    function rowButtonEvent(button) {
        var parent = $(button).parent(".grid");
        var newRow = $(document.createElement('div'));
        var rowText = parent.children('.new_row_content').val();
        var gridGenerator = gridButton.clone();

        gridGenerator.click(function () {
            gridButtonEvent(gridGenerator);
        });

        newRow.addClass('row');
        newRow.text(rowText);
        newRow.append(gridGenerator);

        parent.append(newRow);
    };

    function gridButtonEvent(button) {
        var parent = $(button).parent('.row');
        var gridParent = $(button).parents('.grid').eq(0);

        // There can be a grid view in every row,
        // but there can only be one grid view in another grid view
        // If there is already another nested grid
        // We exit the loop
        var rows = gridParent.children('.row');
        for (var i = 0, len = rows.length; i < len; i++) {

            if (rows.eq(i).children('.grid').length > 0) {
                return;
            }
        }

        var newGrid = $(document.createElement('div'));
        newGrid.addClass('grid');

        var newHeaderField = $(document.createElement('input'));
        newHeaderField.attr('type', 'text');
        newHeaderField.attr('placeholder', 'Enter header text');
        newHeaderField.addClass('header_row_content');
        newGrid.append(newHeaderField);

        var newHeaderButton = headerButton.clone();
        newHeaderButton.click(function () {
            headerButtonEvent(newHeaderButton);
        });
        newGrid.append(newHeaderButton);

        var newRowField = $(document.createElement('input'));
        newRowField.attr('type', 'text');
        newRowField.attr('placeholder', 'Enter row text');
        newRowField.addClass('new_row_content');
        newGrid.append(newRowField);

        var newRowButton = rowButton.clone();
        newRowButton.click(function () {
            rowButtonEvent(newRowButton);
        });

        newGrid.append(newRowButton);
        parent.append(newGrid);
        $(button).remove();
    };

    headerButton.click(function () {
        headerButtonEvent(headerButton);
    });

    rowButton.click(function () {
        rowButtonEvent(rowButton);
    });

    gridButton.click(function () {
        gridButtonEvent(gridButton);
    });
});