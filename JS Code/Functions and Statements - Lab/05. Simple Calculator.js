function solve(numb1, numb2, operator) {
    sum = 0;
    switch (operator) {
        case 'multiply':
            sum += numb1 * numb2
            break;
        case 'divide':
            sum += numb1 / numb2
            break;
        case 'add':
            sum += numb1 + numb2
            break;
        case 'subtract':
            sum += numb1 - numb2
            break;
    }
    console.log(sum)
}
solve(50,
    13,
    'subtract'    
    )