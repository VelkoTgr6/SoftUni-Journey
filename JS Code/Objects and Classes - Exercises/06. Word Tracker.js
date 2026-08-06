function solve(inputArr) {
    let stringList = inputArr.shift().split(' ')
    let occurrences = {}

    stringList.forEach(element => {
        occurrences[element] = 0

        inputArr.forEach(word => {
            if (element === word) {
                occurrences[element]++
            }
        });
    });
    let entries=Object.entries(occurrences).sort((a,b) => b[1] - a[1])
    for (const [key,value] of entries) {
        console.log(`${key} - ${value}`)
    }
}
solve([
    'this sentence',
    'In', 'this', 'sentence', 'you', 'have', 'to',
    'count', 'the', 'occurrences', 'of', 'the', 'words',
    'this', 'and', 'sentence', 'because', 'this', 'is',
    'your', 'task'
]
)