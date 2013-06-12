var draggables = document.querySelectorAll(".draggable"),
draggablesLength = draggables.length,
i,
j,
startTime = new Date().getTime(),
endTime,
submitButton = document.getElementById("submit_score"),
label = document.getElementById("label"),
nickname = document.getElementById("nickname"),
scoreboard = document.getElementById("scoreboard");
scoreBoardLength = 5;
console.log(submitButton);

function drag(ev) {
    ev.dataTransfer.setData("dragged-id", ev.target.id);
}

function drop(ev) {
    ev.preventDefault();
    var data = ev.dataTransfer.getData("dragged-id");
    ev.target.appendChild(document.getElementById(data));
    ev.target.src = "imgs/closed_bucket.ico";

    //performing check to see if cleaning is done
    if (ev.target.childElementCount === draggablesLength) {
        endTime = Math.floor((new Date().getTime() - startTime) / 100);
        showInputMenu();
    }
}

function showInputMenu() {
    submitButton.style.display = "inline-block";
    nickname.style.display = "inline-block";
    label.style.display = "inline-block";
}

function allowDrop(ev) {
    ev.preventDefault();
    ev.target.src = "imgs/opened_bucket.ico";
}

function SubmitScore() {
    var nick = nickname.value;
    localStorage.setItem(nick, endTime);
}

function ShowScoreboard() {
    if (!localStorage.length || localStorage.length === 0) {
        scoreboard.innerHTML = "{key:empty, value=empty}";
        return;
    }
    var resultHTML = "Scoreboard: Top 5 <br>the lower the number - the higher the score\
        <br> (calculated in hundreds of a second) <br>\
        (not ordered) <ul>",
    maxValue = Number.MIN_VALUE,
    maxValueKey,
    key;

    if (localStorage.length > 5) {

        while (localStorage.length > 5) {

            for (i = 0; i < localStorage.length; i += 1) {

                key = localStorage.key(i);

                if (maxValue < localStorage.getItem(key)) {
                    maxValueKey = key;
                    maxValue = parseInt(localStorage.getItem(key));
                }
            }
            localStorage.removeItem(maxValueKey);
        }
    }

    for (i = 0; i < localStorage.length; i += 1) {
        key = localStorage.key(i);

        resultHTML += '<li>' + key + ":     " + localStorage.getItem(key) + "</li>";
    }
    resultHTML += "</ul>";
    scoreboard.innerHTML = resultHTML;
}

function restoreImg(ev) {
    ev.target.src = "imgs/closed_bucket.ico";
}

(function generatePositions() {

    for (i = 0; i < draggablesLength; i += 1) {
        draggables[i].style.position = "absolute";
        draggables[i].style.top = Math.floor((Math.random() * 300) + 100) + "px";
        draggables[i].style.left = Math.floor((Math.random() * 700) + 200) + "px";
    }
})();
