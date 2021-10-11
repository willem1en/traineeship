function add() {
    var a = Number.parseInt(document.getElementById("number1").value);
    var b = Number.parseInt(document.getElementById("number2").value);
    if (check()) {
        var result = a + b;
    } else {
        var result = "Please check the box."
    }
    
    document.getElementById("result").innerText = result;
}

function subtract() {
    var a = Number.parseInt(document.getElementById("number1").value);
    var b = Number.parseInt(document.getElementById("number2").value);
    var result = a - b;
    document.getElementById("result").innerText = result;
}

function multiply() {
    var a = Number.parseInt(document.getElementById("number1").value);
    var b = Number.parseInt(document.getElementById("number2").value);
    var result = a * b;
    document.getElementById("result").innerText = result;
}

function divide() {
    var a = Number.parseInt(document.getElementById("number1").value);
    var b = Number.parseInt(document.getElementById("number2").value);
    if (b == 0) {
        var result = "You are not allowed to divide by zero."
    } else {
        var result = a / b;
    }
    document.getElementById("result").innerText = result;
}

function check() {
    return document.getElementById("check").checked
}