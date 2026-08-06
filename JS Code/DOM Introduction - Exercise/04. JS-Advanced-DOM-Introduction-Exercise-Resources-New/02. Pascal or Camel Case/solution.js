function solve() {
  let input = document.getElementById('text').value;
  let transformText = document.getElementById('naming-convention').value
  let result = document.getElementById('result')

  if (transformText == 'Camel Case') {
    sentence = []
    input = input.toLowerCase().split(' ')
    sentence.push(input[0])
    for (let i = 1; i < input.length; i++) {
      sentence.push(input[i].charAt(0).toUpperCase() + input[i].slice(1))
    }
    result.textContent = sentence.join('')
  } else if (transformText == 'Pascal Case') {
    sentence = []
    input = input.toLowerCase().split(' ')
    for (let i = 0; i < input.length; i++) {
      sentence.push(input[i].charAt(0).toUpperCase() + input[i].slice(1))
    }
    result.textContent = sentence.join('')
  } else {
    result.textContent = 'Error!'
  }
}