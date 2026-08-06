function solve(product, numbOfProducts) {
    let sum = 0;
    switch (product) {
        case 'coffee':
            sum += 1.50 * numbOfProducts
            break;
        case 'water':
            sum += 1 * numbOfProducts
            break;
        case 'coke':
            sum += 1.40 * numbOfProducts
            break;
        case 'snacks':
            sum += 2 * numbOfProducts
            break;
    }
    console.log(sum.toFixed(2))
}
solve("water", 5)