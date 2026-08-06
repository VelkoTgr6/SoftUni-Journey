function find(word,text) {
    let textArr=text.split(' ')
    let bool=false;

    for (let wordToMatch of textArr) {
        if (wordToMatch.toLowerCase()==word.toLowerCase()) {
            console.log(word)
            bool=true
        }
    }
    if (bool==false) {
        console.log(`${word} not found!`)
    }
    
}
find('javascript',
'JavaScript is the best programming language'
)