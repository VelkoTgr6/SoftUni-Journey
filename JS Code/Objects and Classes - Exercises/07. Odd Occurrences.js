function solve(stringInput) {
    stringInput = stringInput.toLowerCase()
    let arr = stringInput.split(' ');

    let map = new Map();

    arr.forEach(element => {
        if (map.has(element)) {
            let oldValue = map.get(element)
            let newValue = oldValue + 1;

            map.set(element, newValue)
        } else {
            map.set(element, 1)
        }
    });
    let resultArr = [];

    map.forEach((value, key) => {
        if (value % 2 !== 0) {
            resultArr.push(key)
        }
    })
    console.log(resultArr.join(' '))
}
solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#')