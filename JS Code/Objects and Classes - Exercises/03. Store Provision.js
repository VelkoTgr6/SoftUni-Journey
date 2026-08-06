function solve(currentStock, orderedStock) {
    let store = {};

    for (let i = 0; i < currentStock.length; i += 2) {
        let productName = currentStock[i]
        let quantity = Number(currentStock[i + 1])

        if (!store.hasOwnProperty(productName)) {
            store[productName] = quantity;
        } else {
            store[productName] += quantity
        }

    }
    for (let i = 0; i < orderedStock.length; i += 2) {
        let productName = orderedStock[i]
        let quantity = Number(orderedStock[i + 1])

        if (!store.hasOwnProperty(productName)) {
            store[productName] = quantity;
        } else {
            store[productName] += quantity
        }

    }
    for (const product in store) {
        console.log(`${product} -> ${store[product]}`)
    }
}
solve([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
],
    [
        'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
)