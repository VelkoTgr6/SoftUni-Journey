

function factorialDivision(a, b) {
    
    function factorial(n) {
        if (n === 0 || n === 1) {
            return 1;
        } else {
            return n * factorial(n - 1);
        }
    }
    const factorialA = factorial(a);
    const factorialB = factorial(b);
    const result = factorialA / factorialB;
    
    return result.toFixed(2);
}

