function personInfo(name,lastName,hairColor) {
    let person = {
        name,
        lastName,
        hairColor
    }
    let jsonConverted=JSON.stringify(person)
    console.log(jsonConverted)
}