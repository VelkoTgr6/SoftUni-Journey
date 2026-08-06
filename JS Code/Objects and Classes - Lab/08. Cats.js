function getCats(arr) {
    let cats = []
    class Cat {
        constructor(name, age) {
            this.name = name
            this.age = age
        }
        meow(){
            console.log(`${this.name}, age ${this.age} says Meow`)
        }
    }

    for (let i = 0; i < arr.length; i++) {
        const catInfo=arr[i].split(' ')
        const[name,age]=catInfo;
        const newCat=new Cat(name,age)
        newCat.meow();
        cats.push(newCat)
        
    }
}

