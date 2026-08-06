function solve(num) {
    let sum=0;
    let numberString=num.toString()

    for (let i = 0; i < numberString.length; i++) {
        sum+=parseInt(numberString[i]);
        
    }
    console.log(sum)
}
solve(245678)