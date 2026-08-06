function solve(input) {
    let armies = {}

    input.forEach(element => {
        const regex = /^[^\s]+(?:\s+[^\s]+)?/;
        const match = element.match(regex);
        let leaderName = match ? match[0] : null;
        if (leaderName.includes('arrives')) {
            let leaderSplited = leaderName.split(' ')
            leaderName = leaderSplited[0]
        }

        if (element.includes('arrives')) {
            armies[leaderName] = []
        } else if (element.includes(':')) {
            leaderName = leaderName.split(':')[0]
            if (armies[leaderName]) {
                let splited = element.split(':')
                let armyName = splited[1].split(',').map(item => item.trim());
                let armyObj = { armyName: armyName[0], armyNumber: armyName[1] };
                armies[leaderName].push(armyName)
            }

        }



    });
}
solve(['Rick Burr arrives',
    'Findlay arrives',
    'Rick Burr: Juard, 1500',
    'Wexamp arrives',
    'Findlay: Wexamp, 34540',
    'Wexamp + 340',
    'Wexamp: Britox, 1155',
    'Wexamp: Juard, 43423'])