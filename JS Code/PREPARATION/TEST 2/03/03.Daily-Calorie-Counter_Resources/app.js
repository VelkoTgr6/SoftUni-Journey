const loadBtn = document.getElementById('load-meals')
const addBtn = document.getElementById('add-meal')
const editBtn = document.getElementById('edit-meal')

const foodInputElement = document.getElementById('food')
const timeInputElement = document.getElementById('time')
const caloriesInputElement = document.getElementById('calories')

const mealList = document.getElementById('list')

const baseURL = 'http://localhost:3030/jsonstore/tasks/'

let currentMealId = null

const loadMeals = async () => {
    //fetch all meals
    const response = await fetch(baseURL)
    const data = await response.json()

    //clear meal list element
    mealList.innerHTML = ''

    //create meal element for each
    for (const meal of Object.values(data)) {
        const changeBtnElement = document.createElement('button')
        changeBtnElement.classList.add('change-meal')
        changeBtnElement.textContent = 'Change'

        const deleteBtnElement = document.createElement('button')
        deleteBtnElement.classList.add('delete-meal')
        deleteBtnElement.textContent = 'Delete'

        const buttonContainerElement = document.createElement('div')
        buttonContainerElement.id = 'meal-buttons';
        buttonContainerElement.appendChild(changeBtnElement)
        buttonContainerElement.appendChild(deleteBtnElement);

        const foodH2Element = document.createElement('h2')
        foodH2Element.textContent = meal.food

        const timeH3Element = document.createElement('h3')
        timeH3Element.textContent = meal.time

        const calorieH3Element = document.createElement('h3')
        calorieH3Element.textContent = meal.calories

        const mealElement = document.createElement('div')
        mealElement.classList.add('meal')
        mealElement.appendChild(foodH2Element)
        mealElement.appendChild(timeH3Element)
        mealElement.appendChild(calorieH3Element)
        mealElement.appendChild(buttonContainerElement)

        //attach meal element to dom
        mealList.appendChild(mealElement)

        //attach on change
        changeBtnElement.addEventListener('click', () => {
            //save current meal id
            currentMealId = meal._id

            //populate input
            foodInputElement.value = meal.food
            timeInputElement.value = meal.time
            caloriesInputElement.value = meal.calories

            //activate editBtn
            editBtn.removeAttribute('disabled')

            //deactivate addBtn
            addBtn.setAttribute('disabled', 'disabled')

            //remove from list
            mealElement.remove()
        })

        deleteBtnElement.addEventListener('click', async () => {
            //delete http request
            const response = await fetch(`${baseURL}/${meal._id}`, {
                method: 'DELETE'
            });

            //remove from list
            mealElement.remove()
        })
    }

}

loadBtn.addEventListener('click', loadMeals)

editBtn.addEventListener('click', async () => {
    //get data from inputs
    const { food, calories, time } = getInputData();

    //make put request
    const response = await fetch(`${baseURL}/${currentMealId}`, {
        method: 'PUT',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify({
            _id: currentMealId,
            food,
            calories,
            time,
        })
    })

    if (!response.ok) {
        return;
    }

    //load meals
    loadMeals()
    //deactivate editBtn
    editBtn.setAttribute('disabled', 'disabled')
    //activate addBtn
    editBtn.removeAttribute('disabled')
    //clear currentMealId
    currentMealId = null;

    foodInputElement.value = ''
    timeInputElement.value = ''
    caloriesInputElement.value = ''
})

addBtn.addEventListener('click', async () => {
    //get input data
    const newMeal = getInputData()
    // create post request 
    const responese = await fetch(baseURL, {
        method: 'POST',
        headers: {
            'content-type': 'application/json',
        },
        body: JSON.stringify(newMeal),
    })

    if (!responese.ok) {
        return;
    }

    //load all meals !await!
    await loadMeals

    //clear input fields
    foodInputElement.value = ''
    timeInputElement.value = ''
    caloriesInputElement.value = ''
})

function getInputData() {
    const food = foodInputElement.value
    const time = timeInputElement.value
    const calories = caloriesInputElement.value

    return { food, time, calories }
}

