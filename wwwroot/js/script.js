let isDefined = false;
let selectedTeam = 0;

let waitSecondsRemaining = 3;
let cronometerSecondsRemaining = 25;

let count = 0;

document.addEventListener("DOMContentLoaded", function () {
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

        document.onkeydown = function (e) {
            if (count == 0 && (e.key == 'a' || e.key == 'l')) {
                count++;
                if (isDefined == false) {
                    if (e.key == 'a' || e.key == 'l') {
                        console.log(e.key);
                        isDefined = true;

                        if (e.key == 'a') {
                            let image = document.getElementById("player-1").src = "/img/man-answer.png";
                            selectedTeam = 1;
                        }
                        else {
                            let image = document.getElementById("player-2").src = "/img/woman-answer.png";
                            selectedTeam = 2;
                        }
                        let options = document.getElementsByClassName("option");
                        for (let option of options) {
                            option.classList.add("interaction");
                        }
                    }
                }

                if (isDefined == true) {
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

                    document.querySelector("#a").addEventListener("click", function () {
                        let answer = 'a';
                        $.ajax({
                            type: "POST",
                            url: "/Game/Question",
                            data: { selectedTeam: selectedTeam, answer: answer }
                        });
                    });

                    document.querySelector("#b").addEventListener("click", function () {
                        let answer = 'b';
                        $.ajax({
                            type: "POST",
                            url: "",
                            data: { selectedTeam: selectedTeam, answer: answer }
                        });
                    });

                    document.querySelector("#c").addEventListener("click", function () {
                        let answer = 'c';
                        $.ajax({
                            type: "POST",
                            url: "",
                            data: { selectedTeam: selectedTeam, answer: answer }
                        });
                    });

                    document.querySelector("#d").addEventListener("click", function () {
                        let answer = 'd';
                        $.ajax({
                            type: "POST",
                            url: "",
                            data: { selectedTeam: selectedTeam, answer: answer }
                        });
                    });

                    document.querySelector("#e").addEventListener("click", function () {
                        let answer = 'e';
                        $.ajax({
                            type: "POST",
                            url: "",
                            data: { selectedTeam: selectedTeam, answer: answer }
                        });
                    });
                }
            }
        }

        if (isDefined == true) {
            console.log("OK");
        }
    }, 3000);
})