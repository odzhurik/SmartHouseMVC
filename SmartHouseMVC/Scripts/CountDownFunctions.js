var counter = 1;
var intervalHandler;
var temp;

var element = document.getElementById('spanState');
var textBox = document.getElementById('temperatureTB');
var btn = document.getElementById('setButton2');
var setBut = document.getElementById('setButton');

setBut.onclick = function () {

    var temp = textBox.value;
    if (temp.length == 0)
    {
        alert("Fill the textbox");
        return false;
    }
    if (document.getElementById("spanOnOffcon").innerText == "False") {
        alert("Turn on Conditioner");
        return false;
    }
        function count() {
            element.innerText = counter;
            counter++;

        }

        intervalHandler = setInterval(count, 1000);

        var handler = setTimeout(function () {
            clearInterval(intervalHandler);
            alert('Stop. Your temperature now is ' + temp);
            $("#myForm").submit();

        }, 8000);
    }

    $("#reheatButton").click("on", function () {
        function countdown() {
            var element = document.getElementById('microTB');
            var seconds = parseInt(element.value) * 1;

            if (document.getElementById("checkbox").checked == false) {
                alert("Check the food");
                return false;
            }
            if (document.getElementById("spanOnOff").innerText == "False") {
                alert("Turn on Microwave");
                return false;
            }
            if (seconds > 0) {
                element.value = seconds - 1;
                setTimeout(countdown, 1000);

            }
            if (seconds == 0) {

                alert('Your meal is ready');
                element.value = ' ';

                $("#myForm2").submit();

            }

        }
        setTimeout(countdown, 1000);
    });

    var get = function (id) {
        return document.getElementById(id);
    }
