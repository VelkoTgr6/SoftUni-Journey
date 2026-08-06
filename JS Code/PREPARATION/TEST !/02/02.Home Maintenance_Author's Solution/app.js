window.addEventListener("load", solve);

function solve() {
  let formElement = document.querySelector("form");
  let placeElement = document.getElementById("place");
  let actionElement = document.getElementById("action");
  let personElement = document.getElementById("person");

  let addButton = document.getElementById("add-btn");
  addButton.addEventListener("click", onAdd);

  function onAdd() {
    if (
      placeElement.value == "" ||
      actionElement.value == "" ||
      personElement.value == ""
    ) {
      return;
    }
    let taskList = document.getElementById("task-list");
    let doneList = document.getElementById("done-list");

    let taskLiElement = document.createElement("li");
    taskLiElement.setAttribute("class", "clean-task");
    let buttonDiv = document.createElement("div");
    buttonDiv.setAttribute("class", "buttons");
    let taskArticleElement = document.createElement("article");

    let placeP = document.createElement("p");
    placeP.textContent = `Place:${placeElement.value}`;
    let place = placeElement.value;


    let actionP = document.createElement("p");
    actionP.textContent = `Action:${actionElement.value}`;
    let action = actionElement.value;

    let personP = document.createElement("p");
    personP.textContent = `Person:${personElement.value}`;
    let person = personElement.value;


    taskArticleElement.appendChild(placeP);
    taskArticleElement.appendChild(actionP);
    taskArticleElement.appendChild(personP);

    let editBtn = document.createElement("button");
    editBtn.textContent = "Edit";
    editBtn.setAttribute("class", "edit")
    editBtn.addEventListener("click", edit);

    let doneBtn = document.createElement("button");
    doneBtn.textContent = "Done";
    doneBtn.setAttribute("class", "done")
    doneBtn.addEventListener("click", onDone);

    buttonDiv.appendChild(editBtn);
    buttonDiv.appendChild(doneBtn);

    taskLiElement.appendChild(taskArticleElement);
    taskLiElement.appendChild(buttonDiv);



    taskList.appendChild(taskLiElement);
    formElement.reset();

    function edit() {
      placeElement.value = place;
      actionElement.value = action;
      personElement.value = person;

      taskList.removeChild(taskLiElement);
    }
    function onDone() {
      let taskDoneLiElement = document.createElement("li");
      let deleteBtn = document.createElement("button");
      deleteBtn.setAttribute('class', 'delete')
      deleteBtn.textContent = "Delete";

      deleteBtn.addEventListener("click", onDelete);
      taskDoneLiElement.appendChild(taskArticleElement);
      taskDoneLiElement.appendChild(deleteBtn);
      doneList.appendChild(taskDoneLiElement);
      taskList.removeChild(taskLiElement);


      function onDelete() {
        doneList.removeChild(taskDoneLiElement);

      }
    }

  }
}