function addItem() {
    const inputElement=document.querySelector('#newItemText')

    if (inputElement.value.length===0) {
        return;
    }

    let newListItem=document.createElement('li')
    newListItem.textContent=inputElement.value

    let deleteLink=document.createElement('a')
    deleteLink.textContent='[Delete]'
    deleteLink.href='#'
    
    deleteLink.addEventListener('click',deleteItem)

    newListItem.appendChild(deleteLink)

    const ulList=document.querySelector('#items')
    ulList.appendChild(newListItem)

    inputElement.value=''

    function deleteItem(e) {
        const row=e.currentTarget.parentNode
        row.remove()
    }

}