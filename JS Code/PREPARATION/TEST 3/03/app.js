const loadBtn = document.getElementById('load-history')
const addBtn = document.getElementById('add-weather')
const editBtn = document.getElementById('edit-weather')

const locationInputElement = document.getElementById('location')
const temperatureInputElement = document.getElementById('temperature')
const dateInputElement = document.getElementById('date')

const baseURL = 'http://localhost:3030/jsonstore/tasks/'

const listHistory = document.getElementById('list')

let currentLocationId = null;

const loadHistory = async () => {
    const response = await fetch(baseURL)
    const data = await response.json()

    listHistory.innerHTML = ''

    for (const weather of Object.values(data)) {
        const changeBtnElement = document.createElement('button')
        changeBtnElement.classList.add('change-btn')
        changeBtnElement.textContent = 'Change'

        const deleteBtnElement = document.createElement('button')
        deleteBtnElement.classList.add('delete-button')
        deleteBtnElement.textContent = 'Delete'

        const buttonsContainer = document.createElement('div')
        buttonsContainer.classList.add('buttons-container')
        buttonsContainer.appendChild(changeBtnElement)
        buttonsContainer.appendChild(deleteBtnElement)

        const celsiusH3Element = document.createElement('h3')
        celsiusH3Element.id = 'celsius'
        celsiusH3Element.textContent = weather.temperature

        const dateH3Element = document.createElement('h3')
        dateH3Element.textContent = weather.date

        const locationH2Element = document.createElement('h2')
        locationH2Element.textContent = weather.location

        const weatherContainer = document.createElement('div')
        weatherContainer.classList.add('container')
        weatherContainer.appendChild(locationH2Element)
        weatherContainer.appendChild(dateH3Element)
        weatherContainer.appendChild(celsiusH3Element)
        weatherContainer.appendChild(buttonsContainer)

        listHistory.appendChild(weatherContainer)

        changeBtnElement.addEventListener('click', () => {
            currentLocationId = weather._id

            locationInputElement.value = weather.location
            temperatureInputElement.value = weather.temperature
            dateInputElement.value = weather.date

            editBtn.removeAttribute('disabled')

            addBtn.setAttribute('disabled', 'disabled')

            weatherContainer.remove()
        })

        deleteBtnElement.addEventListener('click', async () => {
            const response=await fetch(`${baseURL}/${weather._id}`,{
                method:'DELETE'
            })

            weatherContainer.remove()
        })
    }
}

loadBtn.addEventListener('click', loadHistory)

addBtn.addEventListener('click', async () => {
    const newLocationWeather = getInputData()

    const response = await fetch(baseURL, {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify(newLocationWeather)
    })
    if (!response.ok) {
        return;
    }

    await loadHistory()

    clearInputFields()
})

editBtn.addEventListener('click',async () => {
    const {location,temperature,date}=getInputData()

    const response = await fetch(`${baseURL}/${currentLocationId}`,{
        method:'PUT',
        headers:{
            'content-type':'application/json'
        },
        body:JSON.stringify({
            _id:currentLocationId,
            location,
            temperature,
            date
        })
    })
    if (!response.ok) {
        return
    }

    loadHistory()

    editBtn.setAttribute('disabled','disabled')

    addBtn.removeAttribute('disabled')

    currentLocationId=null

    clearInputFields()

})

function getInputData() {
    const location = locationInputElement.value
    const temperature = temperatureInputElement.value
    const date = dateInputElement.value

    return ({ location, temperature, date })
}

function clearInputFields() {
    locationInputElement.value = ''
    temperatureInputElement.value = ''
    dateInputElement.value = ''
}