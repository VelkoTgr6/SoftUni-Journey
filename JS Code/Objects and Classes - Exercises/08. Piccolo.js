function solve(inputArr) {
    let carNumbers = [];

    for (let i = 0; i < inputArr.length; i++) {
        let [action, carNumber] = inputArr[i].split(', ');

        if (action === 'IN') {
            if (!carNumbers.includes(carNumber)) {
                carNumbers.push(carNumber);
            }
        } else if (action === 'OUT') {
            if (carNumbers.includes(carNumber)) {
                let carIndex = carNumbers.indexOf(carNumber);
                carNumbers.splice(carIndex, 1);
            }
        }
    }
    if (carNumbers.length > 0) {
        carNumbers.sort()
        carNumbers.forEach(element => {
            console.log(element)
        });
    }else{
        console.log('Parking Lot Empty')
    }


}
solve(['IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'IN, CA9999TT',
    'IN, CA2866HI',
    'OUT, CA1234TA',
    'IN, CA2844AA',
    'OUT, CA2866HI',
    'IN, CA9876HH',
    'IN, CA2822UU']
)