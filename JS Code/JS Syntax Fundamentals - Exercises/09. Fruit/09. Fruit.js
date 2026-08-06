function solve(fruit,weight,money) {
    let result=(weight*money)/1000
    console.log(`I need $${result.toFixed(2)} to buy ${(weight/1000).toFixed(2)} kilograms ${fruit}.`)
}
solve('orange', 2500, 1.80)