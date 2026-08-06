function getPhoneBook(arr) {
    const meetings = {}

    for (const element of arr) {
        const [day, name] = element.split(" ")
        if(!meetings.hasOwnProperty(day)){
            meetings[day] = name
            console.log(`Scheduled for ${day}`)
        }
        else{
            console.log(`Conflict on ${day}!`)
        }
        
    }
    for (const key in meetings) {
        console.log(`${key} -> ${meetings[key]}`);
    }
}
getPhoneBook(['Wednesday Bill',
    'Monday Tim',
    'Friday Tim']
)