window.addEventListener("load", solve);

function solve() {
    const placeField = document.getElementById('place')
    const actionField = document.getElementById('action')
    const personField = document.getElementById('person')

    const addBtn = document.getElementById('add-btn')

    addBtn.addEventListener('click', onAdd)

    function onAdd() {
        let tasksList = document.getElementById('task-list')
        let doneList = document.getElementById("done-list");

        let cleanTask = document.createElement('li')
        cleanTask.classList.add('clean-task')
        tasksList.appendChild(cleanTask)

        let article = document.createElement('article')
        cleanTask.appendChild(article)

        let task = document.createElement('p')
        task.textContent = `Place:${placeField.value}`
        let place = placeField.value

        let task2 = document.createElement('p')
        task2.textContent = `Action:${actionField.value}`
        let action = actionField.value

        let task3 = document.createElement('p')
        task3.textContent = `Person:${personField.value}`
        let person = personField.value

        article.appendChild(task)
        article.appendChild(task2)
        article.appendChild(task3)


        let buttons = document.createElement('div')
        buttons.classList.add('buttons')
        tasksList.appendChild(buttons)
        let editBtn = document.createElement('button')
        editBtn.classList.add('edit')
        editBtn.textContent = 'Edit'

        let doneBtn = document.createElement('button')
        doneBtn.classList.add('done')
        doneBtn.textContent = 'Done'

        buttons.appendChild(editBtn)
        buttons.appendChild(doneBtn)

        editBtn.addEventListener('click', edit)
        doneBtn.addEventListener('click', onDone)

        placeField.value = ''
        actionField.value = ''
        personField.value = ''

        function edit() {
            placeField.value = place
            actionField.value = action
            personField.value = person

            tasksList.removeChild(cleanTask)
        }

        function onDone() {
            let taskDoneLiElement = document.createElement("li");
            let deleteBtn = document.createElement("button");
            deleteBtn.setAttribute('class', 'delete')
            deleteBtn.textContent = "Delete";

            deleteBtn.addEventListener("click", onDelete);
            taskDoneLiElement.appendChild(cleanTask);
            taskDoneLiElement.appendChild(deleteBtn);
            doneList.appendChild(taskDoneLiElement);
            tasksList.removeChild(buttons);


            function onDelete() {
                doneList.removeChild(taskDoneLiElement);

            }
        }
    }

}
