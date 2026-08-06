function chars(char1,char2) {

    let chars='';

    let charCode1=char1.charCodeAt(0)
    let charCode2=char2.charCodeAt(0)

    let firstChar=Math.min(charCode1,charCode2)
    let lastChar=Math.max(charCode1,charCode2)

    for (let i = firstChar+1; i < lastChar; i++) {
        chars+=String.fromCharCode(i) + ' ';
    }
    console.log(chars)
}