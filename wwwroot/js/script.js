document.addEventListener("DOMContentLoaded", function () {

    let waitSecondsRemaining = 3;
    let waitTimer = document.getElementById("wait-timer");

    function updateWaitTimer() {
        waitSecondsRemaining--;
        if (waitSecondsRemaining < 1) {
            clearInterval(waitTimerInterval);
            waitTimer.style.display = "none";
        }
        waitTimer.innerHTML = waitSecondsRemaining;
    }

    let waitTimerInterval = setInterval(updateWaitTimer, 1000);

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

            if (isDefined == true) {
                let cronometerSecondsRemaining = 25;
                let cronometerTimer = document.getElementById("cronometer");
                cronometerTimer.style.display = "block";

                function updateCronometerTimer() {
                    cronometerSecondsRemaining--;
                    if (cronometerSecondsRemaining < 1) {
                        clearInterval(cronometerTimerInterval);
                    }
                    if (cronometerSecondsRemaining < 10) {
                        cronometerTimer.querySelector(".seconds").style.color = "red";
                    }
                    cronometerTimer.querySelector(".seconds").innerHTML = cronometerSecondsRemaining;
                }

                let cronometerTimerInterval = setInterval(updateCronometerTimer, 1000);
            }
        }
    }, 3000);
})

