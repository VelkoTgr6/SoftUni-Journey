// function find(text) {
//     let textArr = text.split(' ')
//     let wordsArr = [];

//     for (let word of textArr) {
//         if (word.startsWith('#') && word.length > 1 && isNaN(word)) {
//             wordsArr.push(word.substring(1));
//         }
//     }
//     for (let word of wordsArr) {
//         console.log(word)
//     }
    
// }
// find('Nowadays everyone uses # to tag a #special word in #socialMedia')

function matches(text) {
    let regex=/#[A-Za-z]+/gm;

    let matches=text.match(regex)

    for (let word of matches) {
              console.log(word.substring(1))
        }
}
matches('Nowadays everyone uses # to tag a #special word in #socialMedia')