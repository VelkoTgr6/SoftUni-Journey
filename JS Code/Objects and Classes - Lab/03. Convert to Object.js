function solve(jsonStr) {
    let person=JSON.parse(jsonStr);

    for (const entry of Object.entries(person)) {
        const[key,value] = entry;
        console.log(`${key}: ${value}`);
    }
}