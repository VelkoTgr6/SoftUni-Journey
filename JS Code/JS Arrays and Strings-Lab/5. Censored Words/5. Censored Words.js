function solve(text, word) {
    const regex = new RegExp(word, 'g');
    const replacement = '*'.repeat(word.length); // Corrected typo
    console.log(text.replace(regex, replacement));
}
solve('A small sentence with some words', 'small')