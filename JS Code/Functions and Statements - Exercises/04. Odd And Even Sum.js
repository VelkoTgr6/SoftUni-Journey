function solve(number) {
    let splittedNumb = number.toString().split("");
    let evens = 0;
    let odds = 0;

    for (let number of splittedNumb) {
        let n = parseInt(number);
        if (n % 2 === 0) {
            evens += n;
        } else {
            odds += n;
        }
    }
    console.log(`Odd sum = ${odds}, Even sum = ${evens}`)
}
solve(1000435)