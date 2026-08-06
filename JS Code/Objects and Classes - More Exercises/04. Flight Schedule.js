function solve(input) {
    let flights = {};
    let cancelledFlights = [];
    let counter = 0;

    input.forEach(sectors => {
        counter += 1;

        sectors.forEach(flight => {
            if (counter <= 2) {
                const match = flight.match(/^([A-Z\d]+)(.*)$/i);
                const Name = match[1];
                const Destination = match[2].trim();

                if (Destination !== 'Cancelled' && Destination !== 'Ready to fly') {
                    flights[Name] = { Destination };
                } else if (Destination === 'Cancelled') {
                    if (flights[Name]) {
                        let clone = { ...flights[Name], Status: 'Cancelled' };
                        cancelledFlights.push(clone);
                        delete flights[Name];
                    }
                }
            } else {
                if (flight === 'Ready to fly') {
                    Object.values(flights).forEach(flight => {
                        flight.Status = 'Ready to fly';
                        console.log(flight);
                    });
                } else if (flight === 'Cancelled') {
                    cancelledFlights.sort((a, b) => a.Destination.localeCompare(b.Destination));
                    cancelledFlights.forEach(flight => {
                        console.log({ Destination: flight.Destination, Status: 'Cancelled' });
                    });
                }
            }
        });
    });
}
solve([
    ['WN269 Delaware',
        'FL2269 Oregon',
        'WN498 Las Vegas',
        'WN3145 Ohio',
        'WN612 Alabama',
        'WN4010 New York',
        'WN1173 California',
        'DL2120 Texas',
        'KL5744 Illinois',
        'WN678 Pennsylvania'],
    ['DL2120 Cancelled',
        'WN612 Cancelled',
        'WN1173 Cancelled',
        'SK430 Cancelled'],
    ['Cancelled']
]
)
solve([
    ['WN269 Delaware',
        'FL2269 Oregon',
        'WN498 Las Vegas',
        'WN3145 Ohio',
        'WN612 Alabama',
        'WN4010 New York',
        'WN1173 California',
        'DL2120 Texas',
        'KL5744 Illinois',
        'WN678 Pennsylvania'],
    ['DL2120 Cancelled',
        'WN612 Cancelled',
        'WN1173 Cancelled',
        'SK330 Cancelled'],
    ['Ready to fly']
]
)