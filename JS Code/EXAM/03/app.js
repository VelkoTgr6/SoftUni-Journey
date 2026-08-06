const baseURL = 'http://localhost:3030/jsonstore/games/'

const nameInputElement=document.getElementById('g-name')
const typeInputElement=document.getElementById('type')
const playersInputElement=document.getElementById('players')

const loadBtn = document.getElementById('load-games')
const addBtn=document.getElementById('add-game')
const editBtn=document.getElementById('edit-game')

const gameListElement = document.getElementById('games-list')
const formElement=document.getElementById('form')

const loadGames = async () => {
    const response = await fetch(baseURL)
    const data = await response.json()

    if (!response.ok) {
        return;
    }

    gameListElement.innerHTML = '';

    for (const game of Object.values(data)) {
        const changeButtonElement = document.createElement('button');
        changeButtonElement.textContent = 'Change';
        changeButtonElement.classList.add('change-btn');

        const deleteButtonElement = document.createElement('button');
        deleteButtonElement.textContent = 'Delete';
        deleteButtonElement.classList.add('delete-btn');

        const buttonContainerElement = document.createElement('div');
        buttonContainerElement.classList.add('buttons-container')
        buttonContainerElement.appendChild(changeButtonElement);
        buttonContainerElement.appendChild(deleteButtonElement);

        const gameTypeElementP = document.createElement('p');
        gameTypeElementP.textContent = game.type;

        const playersElementP = document.createElement('p')
        playersElementP.textContent = game.players;

        const nameElementP = document.createElement('p')
        nameElementP.textContent = game.name;

        const gameContentElement = document.createElement('div')
        gameContentElement.classList.add('content')
        gameContentElement.appendChild(nameElementP)
        gameContentElement.appendChild(playersElementP)
        gameContentElement.appendChild(gameTypeElementP)

        const boardGameElement=document.createElement('div')
        boardGameElement.classList.add('board-game')
        boardGameElement.appendChild(gameContentElement)
        boardGameElement.appendChild(buttonContainerElement)

        gameListElement.appendChild(boardGameElement)

        changeButtonElement.addEventListener('click',() => {
            formElement.setAttribute('data-id',game._id);

            nameInputElement.value=game.name
            typeInputElement.value=game.type
            playersInputElement.value=game.players

            editBtn.removeAttribute('disabled')

            addBtn.setAttribute('disabled','disabled')

            boardGameElement.remove()
        })

        deleteButtonElement.addEventListener('click',async () => {
            await fetch(`${baseURL}/${game._id}`,{
                method:'DELETE'
            });

            if (!response.ok) {
                return
            }
            boardGameElement.remove()
        })
    }
}

loadBtn.addEventListener('click', loadGames)

editBtn.addEventListener('click',async () => {
    const {name,type,players} = getInputData();

    const gameId=formElement.getAttribute('data-id')

    const response = await fetch(`${baseURL}/${gameId}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
            _id: gameId,
            name,
            type,
            players,
        })
    });

    if (!response.ok) {
            return;
    }

    editBtn.setAttribute('disabled','disabled');

    addBtn.removeAttribute('disabled')

    clearInputData()

    loadGames()
})

addBtn.addEventListener('click',async () => {
    const newGame=getInputData();

    const response = await fetch (baseURL,{
        method: 'POST',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify(newGame),
    })
    if (!response.ok) {
        return;
    }

    clearInputData()

    await loadGames()
})

function getInputData() {
    const name = nameInputElement.value;
    const type = typeInputElement.value;
    const players = playersInputElement.value;

    return { name, type, players };
}


function clearInputData() {
    nameInputElement.value = '';
    typeInputElement.value = '';
    playersInputElement.value = '';
}