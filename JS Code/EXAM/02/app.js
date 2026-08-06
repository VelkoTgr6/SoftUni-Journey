window.addEventListener("load", solve);

function solve() {
  const nameInputElement = document.getElementById('name');
  const phoneNumberElement = document.getElementById('phone');
  const categoryInputElement = document.getElementById('category');
  const checkList = document.getElementById('check-list');
  const contactList = document.getElementById('contact-list');
  const addBtn = document.getElementById('add-btn');

  addBtn.addEventListener('click', addContact);

  function addContact() {
    const name = nameInputElement.value;
    const phone = phoneNumberElement.value;
    const category = categoryInputElement.value;

    if (!name || !phone || !category) {
      
      return;
    }

    const editBtn = createButton('edit-btn');
    const saveBtn = createButton('save-btn');

    const buttonsDiv = document.createElement('div');
    buttonsDiv.classList.add('buttons');
    buttonsDiv.appendChild(editBtn);
    buttonsDiv.appendChild(saveBtn);

    const categoryP = createParagraph(`category:${category}`);
    const phoneP = createParagraph(`phone:${phone}`);
    const nameP = createParagraph(`name:${name}`);

    const articleElement = document.createElement('article');
    articleElement.appendChild(nameP);
    articleElement.appendChild(phoneP);
    articleElement.appendChild(categoryP);

    const liElement = document.createElement('li');
    liElement.appendChild(articleElement);
    liElement.appendChild(buttonsDiv);

    checkList.appendChild(liElement);

    clearInputFields();

    editBtn.addEventListener('click', () => {
      editContact(nameInputElement, phoneNumberElement, categoryInputElement, liElement);
    });

    saveBtn.addEventListener('click', () => {
      saveContact(liElement, contactList);
    });
  }

  function createButton(className, text) {
    const button = document.createElement('button');
    button.classList.add(className);
    button.textContent = text;
    return button;
  }

  function createParagraph(text) {
    const p = document.createElement('p');
    p.textContent = text;
    return p;
  }

  function editContact(nameInput, phoneInput, categoryInput, listItem) {
    const nameArr = listItem.querySelector('p:nth-child(1)').textContent.split(':');
    const phoneArr = listItem.querySelector('p:nth-child(2)').textContent.split(':');
    const categoryArr = listItem.querySelector('p:nth-child(3)').textContent.split(':');

    nameInput.value = nameArr[1];
    phoneInput.value = phoneArr[1];
    categoryInput.value = categoryArr[1];
    
    listItem.remove();
  }

  function saveContact(listItem, destinationList) {
    const deleteBtn = createButton('del-btn');
    const buttonsDiv = listItem.querySelector('.buttons');
    buttonsDiv.innerHTML = '';
    buttonsDiv.appendChild(deleteBtn);

    destinationList.appendChild(listItem);

    deleteBtn.addEventListener('click', () => {
      deleteContact(listItem);
    });
  }

  function deleteContact(listItem) {
    listItem.remove();
  }

  function clearInputFields() {
    nameInputElement.value = '';
    phoneNumberElement.value = '';
    categoryInputElement.value = '';
  }
}