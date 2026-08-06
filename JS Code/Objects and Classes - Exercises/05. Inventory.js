function solve(inputArr) {
    let heroes = [];
    inputArr.forEach(element => {
        let [name, level, items] = element.split(' / ')

        let heroInfo = {
            name,
            level: Number(level),
            items
        }
        heroes.push(heroInfo)
    });

    heroes.sort((a, b) => a.level - b.level);

    heroes.forEach(element => {
        console.log(`Hero: ${element.name}`)
        console.log(`level => ${element.level}`)
        console.log(`items => ${element.items}`)
    });
}
solve([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
]
)