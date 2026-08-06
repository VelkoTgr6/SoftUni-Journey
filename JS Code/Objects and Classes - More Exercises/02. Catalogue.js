function solve(input) {
    const products = {};
    input.sort((a, b) => a.localeCompare(b))

    input.forEach(str => {
        const [productName, productPrice] = str.split(' : ');
        const initial = productName[0].toUpperCase();
        if (!products[initial]) {
            products[initial] = [];
        }
        products[initial].push({ name: productName, price: Number(productPrice) });
    });

    for (const group in products) {
        console.log(group);
        products[group].forEach(product => {
            console.log(`  ${product.name}: ${product.price}`);
        });
    }
}
solve([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10'
]
)