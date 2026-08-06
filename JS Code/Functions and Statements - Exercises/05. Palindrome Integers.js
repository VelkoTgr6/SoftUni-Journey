function solve(numbers) {
    const numStr = numbers.toString().split(',');

    for (let i = 0; i < numStr.length; i++) {
        let reversedStr = numStr[i].split('').reverse().join('');
        if (numStr[i]===reversedStr) {
            console.log(true)
        }
        else{
            console.log(false)
        }
        
    }
    
}
solve([123,323,421,121])