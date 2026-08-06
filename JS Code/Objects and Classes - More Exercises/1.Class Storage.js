class Storage {
    constructor(capacity) {
        this.capacity = capacity;
        this.storage = [];
    }

    get totalCost() {
        let sum = 0;
        for (const product of this.storage) {
            sum += product.price * product.quantity;
        }
        return sum;
    }

    addProduct(product) {
        if (this.capacity - product.quantity >= 0) {
            this.storage.push(product);
            this.capacity -= product.quantity;
        } else {
            console.log(`Cannot add ${product.name} - not enough space in storage.`);
        }
    }

    getProducts() {
        return this.storage.map(product => JSON.stringify(product)).join('\n');
    }
}

let productOne = {name: 'Cucamber', price: 1.50, quantity: 15};
let productTwo = {name: 'Tomato', price: 0.90, quantity: 25};
let productThree = {name: 'Bread', price: 1.10, quantity: 8};
let storage = new Storage(50);
storage.addProduct(productOne);
storage.addProduct(productTwo);
storage.addProduct(productThree);
console.log(storage.getProducts());
console.log(storage.capacity);
console.log(storage.totalCost);

