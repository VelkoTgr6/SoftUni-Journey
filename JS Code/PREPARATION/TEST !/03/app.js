const loadBtn = document.getElementById('load-presents')
const addBtn = document.getElementById('add-present')
const changeBtn = document.getElementById('change-btn')
const edintBtn=document.getElementById('edit-present')

const baseURL = 'http://localhost:3030/jsonstore/gifts/'

let presentField = document.getElementById('gift')
let forField = document.getElementById('for')
let priceFiled = document.getElementById('price')

loadBtn.addEventListener('click', load)

addBtn.addEventListener('click', add)






function add() {
    let data = {
        gift: presentField.value,
        for: forField.value,
        price: priceFiled.value
    };

    fetch(baseURL, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    });

    presentField.value = ''
    forField.value = ''
    priceFiled.value = ''
}

function load() {
    fetch(baseURL)
        .then(res => res.json())
        .then(data => {
            Object.keys(data).forEach(key => {
                createElement(data[key]);
            });
        })
}

function createElement({ _id, gift, for: recipient, price }) {
    const divGiftSock = document.createElement('div')
    divGiftSock.setAttribute('class', 'gift-sock')

    const divContent = document.createElement('div')
    divContent.setAttribute('class', 'content')

    const giftP = document.createElement('p')
    giftP.textContent = gift

    const forP = document.createElement('p')
    forP.textContent = recipient

    const priceP = document.createElement('p')
    priceP.textContent = price

    divContent.appendChild(giftP)
    divContent.appendChild(forP)
    divContent.appendChild(priceP)

    const divButtonsContainer = document.createElement('div')
    divButtonsContainer.setAttribute('class', 'buttons-container')

    const changeBtn = document.createElement('button')
    changeBtn.textContent = 'Change'
    changeBtn.setAttribute('class', 'change-btn')

    const deleteBtn = document.createElement('button')
    deleteBtn.textContent = 'Delete'
    deleteBtn.setAttribute('class', 'delete-btn')

    divButtonsContainer.appendChild(changeBtn)
    divButtonsContainer.appendChild(deleteBtn)

    divGiftSock.appendChild(divContent)
    divGiftSock.appendChild(divButtonsContainer)

    const giftsContainer = document.getElementById('gift-list');
    giftsContainer.appendChild(divGiftSock);

    changeBtn.addEventListener('click', change)

    

    function change() {
        presentField.value = gift
        forField.value = recipient
        priceFiled.value = price

        addBtn.disabled=true
        edintBtn.disabled=false
    }

    edintBtn.addEventListener('click',edit)

    function edit() {
        let data = {
            gift: presentField.value,
            for: forField.value,
            price: priceFiled.value
        };
    
        fetch(`${baseURL}/${_id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });
    
        presentField.value = ''
        forField.value = ''
        priceFiled.value = ''
    }
    

}