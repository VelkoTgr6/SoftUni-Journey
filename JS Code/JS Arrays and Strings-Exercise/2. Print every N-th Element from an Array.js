function solve(arrayInput, n) {
    const array = [];
    for (let i = 0; i < arrayInput.length; i += n) {
        array.push(arrayInput[i])

    }
    return array;
}
solve(['5', '20', '31', '4', '20'], 2);
solve(['dsa',
    'asd',
    'test',
    'tset'],
    2
)
solve(['1',
    '2',
    '3',
    '4',
    '5'],
    6
)