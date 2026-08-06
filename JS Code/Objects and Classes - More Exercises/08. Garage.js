function solve(input) {
    let garages = {};

    input.forEach(str => {
        const [garageNumber, carInfo] = str.split(' - ');
        const garageKey = `Garage № ${garageNumber}`;

        if (!garages[garageKey]) {
            garages[garageKey] = [];
        }

        const carDetails = carInfo.split(', ')
            .map(detail => detail.split(': '))
            .map(([key, value]) => `${key} - ${value}`)
            .join(', ');

        garages[garageKey].push(carDetails);
    });

    for (const garageKey in garages) {
        console.log(garageKey);
        garages[garageKey].forEach(car => console.log(`--- ${car}`));
    }
}
solve(['1 - color: blue, fuel type: diesel',
    '1 - color: red, manufacture: Audi',
    '2 - fuel type: petrol',
    '4 - color: dark blue, fuel type: diesel, manufacture: Fiat'])