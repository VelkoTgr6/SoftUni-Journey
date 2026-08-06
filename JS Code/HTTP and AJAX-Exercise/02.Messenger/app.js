function attachEvents() {
    const nameField = document.querySelector('input[name=author')
    const contentField = document.querySelector('input[name=content')
    let texteaMessages = document.querySelector('#messages')

    const baseURL='http://localhost:3030/jsonstore/messenger'

    let messages={}

    const sendBtn = document.getElementById('submit')
    const refreshBtn = document.getElementById('refresh')

    sendBtn.addEventListener('click', () => {
        const newMessage = {
            author: nameField.value,
            content: contentField.value,
        };

        // Stringify the newMessage object
        const requestBody = JSON.stringify(newMessage);

        // Define the options for the fetch request
        const options = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: requestBody
        };

        // Perform the fetch request
        fetch(baseURL, options)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                // Handle the response data here (if needed)
                console.log(data);
            })
            .catch(error => {
                // Handle errors here
                console.error('There was a problem with the fetch operation:', error);
            });
    });

    refreshBtn.addEventListener('click', () => {
        // Perform the fetch request to get the messages
        fetch(baseURL)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                // Update the messages object with the received data
                messages = data;
                // Display the messages in the text area
                displayMessages(texteaMessages);
            })
            .catch(error => {
                // Handle errors here
                console.error('There was a problem with the fetch operation:', error);
            });
    });

    // Helper function to display messages in the text area
    function displayMessages(textArea) {
        textArea.value = '';
        for (const message of Object.values(messages)) {
            textArea.value += `${message.author}: ${message.content}\n`;
        }
    }
}


attachEvents();