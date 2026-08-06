function solve(arrayOfNumbers,rotations) {
    for (let i = 0; i < rotations; i++) {
        arrayOfNumbers.push(arrayOfNumbers[0])
        arrayOfNumbers.shift()
    }
    console.log(arrayOfNumbers.join(' '))
}
solve([51, 47, 32, 61, 21], 2)