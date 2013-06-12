(function () {
    var removeButton = document.getElementById("remove_button"),
           addButton = document.getElementById("add_button"),
           textInput = document.getElementById("text_input"),
           todoList = document.getElementById("todo_list"),
           appendElement,
           removeElement,
           allElements,
           i,
           displayButton = document.getElementById("display"),
           hideButton = document.getElementById("hide"),
           listContainer = document.getElementById("list_container");

    var displayList = function () {
        listContainer.style.display = "block";
    }

    var hideList = function () {
        listContainer.style.display = "none";
    }

    var addListItem = function () {
        if (textInput.value !== null && textInput.value !== "" && textInput.value !== undefined) {
            appendElement = "<li>" + textInput.value + "</li>";
            todoList.innerHTML += appendElement;
        }
    }

    var removeListItem = function () {
        removeElement = textInput.value;
        allElements = todoList.children;

        for (i = 0; i < allElements.length; i++) {
            if (allElements[i].innerHTML === removeElement) {
                todoList.removeChild(allElements[i]);
                break;
            }
        }
    }

    removeButton.addEventListener("click", removeListItem, false);
    addButton.addEventListener("click", addListItem, false);
    displayButton.addEventListener("click", displayList, false);
    hideButton.addEventListener("click", hideList, false);

})();