function encodeAndDecodeMessages() {
    let encodeTextArea = document.querySelector('textarea')
    let decodeTextArea = document.getElementsByTagName('textarea')[1]

    let encodeBtn = document.getElementsByTagName('button')[0]
    let decodeBtn = document.getElementsByTagName('button')[1]

    encodeBtn.addEventListener('click', encode)
    decodeBtn.addEventListener('click', decode)

    function encode() {
        let message = encodeTextArea.value
        let newText = '';

        for (let i = 0; i < message.length; i++) {
            let newMessage = String.fromCodePoint(message[i].charCodeAt(0) + 1)
            newText += newMessage
        }
        decodeTextArea.value = newText
        encodeTextArea.value = ''
        decodeBtn.disabled = false;
    }

    function decode() {
        let newText = '';
        let message=decodeTextArea.value
        for (let i = 0; i < message.length; i++) {
            let newMessage = String.fromCodePoint(message[i].charCodeAt(0) - 1)
            newText += newMessage
        }

        decodeTextArea.value = newText
        decodeBtn.disabled = true;
    }

}