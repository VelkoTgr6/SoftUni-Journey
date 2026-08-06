function solve(inputArr) {
    const baristasCount = inputArr[0]
    let baristasMakers = {}

    for (let index = 1; index <= baristasCount; index++) {
        const [name, shift, drinksType] = inputArr[index].split(' ')
        const drinks=drinksType.split(',')
        const barista = { name, shift, drinks }
        baristasMakers[name] = barista
    }

    for (let index = baristasCount; index < inputArr.length; index++) {
        const commands=inputArr[index].split(' / ')

        const command=commands[0]
        const name=commands[1]
        const shift=commands[2]
        const drink=commands[3]

        switch (command) {
            case 'Prepare':
                if (baristasMakers[name].shift===shift && baristasMakers[name].drinks.includes(drink)) {
                    console.log(`${name} has prepared a ${drink} for you!`)
                }
                else{
                    console.log(`${name} is not available to prepare a ${drink}.`)
                }
                break;
            case'Change Shift':
                baristasMakers[name].shift=shift
                console.log(`${name} has updated his shift to: ${shift}`);
                break;
                case'Learn':
                if (baristasMakers[name].drinks.includes(shift)) {
                    console.log(`${name} knows how to make ${shift}.`);
                }else{
                    baristasMakers[name].drinks.push(shift)
                    console.log(`${name} has learned a new coffee type: ${shift}.`);
                }
                break;
                case'Closed':
                for (const baristaKey in baristasMakers) {
                    const barista = baristasMakers[baristaKey];
                    console.log(`Barista: ${barista.name}, Shift: ${barista.shift}, Drinks: ${barista.drinks.join(', ')}`);
                }
            default:
                break;
        }
    }

}
solve([
    '3',
    'Alice day Espresso,Cappuccino',
    'Bob night Latte,Mocha',
    'Carol day Americano,Mocha',
    'Prepare / Alice / day / Espresso',
    'Change Shift / Bob / night',
    'Learn / Carol / Latte',
    'Learn / Bob / Latte',
    'Prepare / Bob / night / Latte',
    'Closed']
)