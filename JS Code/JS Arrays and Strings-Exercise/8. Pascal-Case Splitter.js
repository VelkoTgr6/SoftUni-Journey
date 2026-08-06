function split(text) {
    let regex=/[A-Z][a-z]*/g
    let wordsArray = text.match(regex);

    let result = wordsArray.join(', ');

    console.log(result);
    
    
}
split('SplitMeIfYouCanHaHaYouCantOrYouCan')