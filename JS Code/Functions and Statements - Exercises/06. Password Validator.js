function validator(inputPassword) {

    function isValidLenght(text) {
        return text.length >= 6 && text.length <= 10;
    }

    function isAlphanumeric(text) {
        const regex = /^[a-zA-Z0-9]+$/;
        let isCorrect = regex.test(text);

        return isCorrect;
    }

    function checkDigits(text) {
        let digitsCounter = 0;

        for (let digit of text) {
            if (!isNaN(digit)) {
                digitsCounter++;
            }
        }
        return digitsCounter >= 2
    }

    let validLenght = isValidLenght(inputPassword);
    let validNumeric = isAlphanumeric(inputPassword);
    let validDigitsCount = checkDigits(inputPassword);

    if (!validLenght) {
        console.log("Password must be between 6 and 10 characters")
    }
    if (!validNumeric) {
        console.log("Password must consist only of letters and digits");
    }
    if (!validDigitsCount) {
        console.log("Password must have at least 2 digits")
    }

    if (validLenght && validNumeric && validDigitsCount) {
        console.log("Password is valid")
    }

}