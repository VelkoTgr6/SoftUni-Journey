function getPhoneBook(arr) {
    const addressBook={}

    for (const element of arr) {
        const[name,address] = element.split(":")
        addressBook[name]=address
    }
    const sorted=Object.entries(addressBook).sort()
    for (const key of sorted) {
        console.log(`${key[0]} -> ${key[1]}`);
    }
}
getPhoneBook(['Tim:Doe Crossing',
'Bill:Nelson Place',
'Peter:Carlyle Ave',
'Bill:Ornery Rd']
)