function printSortedNames(names) {
    names.sort((a,b) => {
        return a.localeCompare(b)
    });
    // the comparison function (a, b) => a.localeCompare(b) 
    // compares two strings a and b using the localeCompare method.
    //  This method compares strings based on their Unicode values, 
    // ensuring correct alphabetical sorting, even with international characters.

    names.forEach((name, index) => {
        console.log(`${index + 1}.${name}`);
    });
}
sort(["John", "Bob", "Christina", "Ema"]);