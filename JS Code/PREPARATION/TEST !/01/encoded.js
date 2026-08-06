function func(arrInput) {
    let message = arrInput[0]

    for (const command of arrInput) {

        let commandInfo = command.split('?')

        switch (commandInfo[0]) {
            case 'TakeEven':

                let newMsg = ''
                for (let index = 0; index < message.length; index += 2) {
                    if (index % 2 == 0) {
                        newMsg += message[index]
                    }

                }
                message = newMsg
                console.log(message)
                break;

            case 'ChangeAll':
                const substring = commandInfo[1]
                const replacement = commandInfo[2]

                
                if (message.includes(substring)) {
                    let messageArr=message.split('')
                    
                    for (let index = 0; index < messageArr.length; index++) {
                        if (messageArr[index] === substring) {
                            messageArr[index]=replacement

                        }

                    }
                    message=messageArr.join('')
                }
                console.log(message)
                break;

            case 'Reverse':

                if (message.includes(commandInfo[1])) {
                    let reversed = commandInfo[1]
                    message = message.replace(reversed, '')

                    const charArray = reversed.split('');

                    // Reverse the array
                    const reversedArray = charArray.reverse();

                    // Join the characters back into a string
                    const reversedString = reversedArray.join('');

                    message += reversedString
                    console.log(message)
                } else {
                    console.log('error')
                }
                break;

            case 'Buy':
                console.log(`The cryptocurrency is: ${message}`);
                break;

            default:
                break;
        }
    }
}
func((["z2tdsfndoctsB6z7tjc8ojzdngzhtjsyVjek!snfzsafhscs",
    "TakeEven",
    "Reverse?!nzahc",
    "ChangeAll?m?g",
    "Reverse?adshk",
    "ChangeAll?z?i",
    "Buy"])
)