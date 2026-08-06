function solve(inputArr) {
    const charactersCount = Number(inputArr[0])
    let characters = {}

    for (let index = 1; index <= charactersCount; index++) {
        let [name, hp, bullets] = inputArr[index].split(' ')
        hp = Number(hp)
        bullets = Number(bullets)
        const character = { name, hp, bullets }

        characters[name] = character
    }
    const startIndex = charactersCount + 1
    for (let index = startIndex; index < inputArr.length; index++) {
        const inputCommands = inputArr[index].split(' - ')

        const command = inputCommands[0]
        const name = inputCommands[1]

        switch (command) {
            case 'FireShot':
                const target = inputCommands[2]

                if (characters[name].bullets > 0) {
                    characters[name].bullets -= 1
                    console.log(`${name} has successfully hit ${target} and now has ${characters[name].bullets} bullets!`);
                } else {
                    console.log(`${name} doesn't have enough bullets to shoot at ${target}!`);
                }
                break;
            case 'TakeHit':
                const damage = inputCommands[2]
                const attacker = inputCommands[3]

                if (characters[name].hp - damage <= 0) {
                    console.log(`${name} was gunned down by ${attacker}!`);
                    delete characters[name]
                } else {
                    characters[name].hp -= damage
                    console.log(`${name} took a hit for ${damage} HP from ${attacker} and now has ${characters[name].hp} HP!`);
                }
                break;
            case 'Reload':
                if (characters[name].bullets < 6) {
                    const initialBullets = Number(characters[name].bullets)
                    characters[name].bullets = 6
                    console.log(`${name} reloaded ${6 - initialBullets} bullets!`);
                } else {
                    console.log(`${name}'s pistol is fully loaded!`);
                }
                break;
            case 'PatchUp':
                const amount = Number(inputCommands[2])
                if (characters[name].hp < 100) {
                    characters[name].hp += amount
                    if (characters[name].hp > 100) {
                        console.log(`${name} patched up and recovered ${characters[name].hp-100} HP!`)
                        characters[name].hp = 100
                        break;
                    }
                    console.log(`${name} patched up and recovered ${amount} HP!`)
                } else {
                    console.log(`${name} is in full health!"`);
                }
                break;
            case 'Ride Off Into Sunset':
                for (const characterKey in characters) {
                    const character=characters[characterKey]
                    console.log(character.name)
                    console.log(` HP: ${character.hp}`);
                    console.log(` Bullets: ${character.bullets}`);
                }
                break;
            default:
                break;
        }
    }
}

// solve((["2",
//     "Gus 100 0",
//     "Walt 100 6",
//     "FireShot - Gus - Bandit",
//     "TakeHit - Gus - 100 - Bandit",
//     "Reload - Walt",
//     "Ride Off Into Sunset"])
// )
solve((["2",
"Jesse 100 4",
"Walt 100 5",
"FireShot - Jesse - Bandit",
 "TakeHit - Walt - 30 - Bandit",
 "PatchUp - Walt - 20" ,
 "Reload - Jesse",
 "Ride Off Into Sunset"])
)
solve((["2",
"Gus 100 4",
"Walt 100 5",
"FireShot - Gus - Bandit",
"TakeHit - Walt - 100 - Bandit",
"Reload - Gus",
"Ride Off Into Sunset"])
)