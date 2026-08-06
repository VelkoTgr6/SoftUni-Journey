class Laptop {
    constructor(info, quality) {
        this.info = {
            producer: info.producer,
            age: Number(info.age),
            brand: info.brand
        }
        this.quality = quality;
        this.isOn = false;
    }
    get price() {
        let sum = Number(800 - (this.info.age * 2) + (this.quality * 0.5))
        return sum;
    }
    turnOn() {
        this.isOn = true;
        this.quality--
        return this
    }
    turnOff() {
        this.isOn = false;
        this.quality--
        return this
    }
    showInfo() {
        return JSON.stringify(this.info)
    }

}