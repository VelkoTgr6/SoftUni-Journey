function arrange(array) {
    let resultArray = [];
    const arrLenght = array.length;
    let soredArray = array.sort((a, b) => a - b)

    for (let i = 0; i < arrLenght / 2; i++) {
        let first = soredArray.shift();
        let last = soredArray.pop()
        resultArray.push(first)
        resultArray.push(last)

    }
    return resultArray
}
arrange([1, 65, 3, 52, 48, 63, 31, -3, 18, 56])