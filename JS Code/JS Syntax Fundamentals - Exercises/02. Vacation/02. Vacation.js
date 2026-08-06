function solve(numOfPeople, type, day) {

    let price;
    let totalSum;

    switch (type) {
        case 'Students':
            if (day == 'Friday') {
                price = 8.45
            }
            else if (day == 'Saturday') {
                price = 9.80
            }
            else if (day == 'Sunday') {
                price = 10.46
            }
            break;
        case 'Business':
            if (day == 'Friday') {
                price = 10.90
            }
            else if (day == 'Saturday') {
                price = 15.60
            }
            else if (day == 'Sunday') {
                price = 16
            }
            break;
        case 'Regular':
            if (day == 'Friday') {
                price = 15
            }
            else if (day == 'Saturday') {
                price = 20
            }
            else if (day == 'Sunday') {
                price = 22.50
            }
            break;
    }
    if (numOfPeople >= 30 && type == 'Students') {
        price *= 0.85;
    }
    else if (numOfPeople >= 100 && type == 'Business') {
        numOfPeople -= 10
    }
    else if (numOfPeople >= 10 && numOfPeople <= 20 && type=='Regular') {
        price *= 0.95
    }

    totalSum = numOfPeople * price
    console.log(`Total price: ${totalSum.toFixed(2)}`)
}
solve(30,
    "Students",
    "Sunday"
)
solve(40,
    "Regular",
    "Saturday"
)