function addItem() {
    const inputElement=document.querySelector('#newItemText')

    let newListItem=document.createElement('li')
    newListItem.textContent=inputElement.value

    const ulList=document.querySelector('#items')
    ulList.appendChild(newListItem)
    inputElement.value=''
}