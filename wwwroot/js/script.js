document.addEventListener("DOMContentLoaded", function () {

    let secondsRemaining = 3;
    let timer = document.getElementById("start-timer");

    function updateTimer() {
        secondsRemaining--;
        if (secondsRemaining < 1) {
            clearInterval(timerInterval);
            timer.style.display = "none";
        }
        timer.innerHTML = secondsRemaining;
    }

    let timerInterval = setInterval(updateTimer, 1000);

    setTimeout(function () {
        let content = document.getElementById("question-info");
        content.style.display = "block";

        let isDefined = false;
        document.onkeydown = function (e) {
            if (isDefined == false) {
                if (e.key == 'a' || e.key == 'l') {
                    console.log(e.key);
                    isDefined = true;

                    if (e.key == 'a') {
                        let image = document.getElementById("player-1").src = "/img/man-answer.png";
                    }
                    else {
                        let image = document.getElementById("player-2").src = "/img/woman-answer.png";
                    }
                }
            }
        }
    }, 3000);
})

