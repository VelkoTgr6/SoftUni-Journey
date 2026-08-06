function solve(number) {

    let stringNumb=number.toString()
    let same=true;
    let sum=0;
    const firstDigit = stringNumb[0];


    for (let i = 0; i < stringNumb.length; i++) {
        const currentDigit = stringNumb[i];
        sum += parseInt(currentDigit);

        if (currentDigit !== firstDigit) {
            same = false;
        }
    }
    console.log(same)
    console.log(sum)
}
solve(2222222)