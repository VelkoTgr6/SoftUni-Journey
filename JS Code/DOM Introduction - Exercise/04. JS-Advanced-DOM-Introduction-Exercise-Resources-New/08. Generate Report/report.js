function generateReport() {
    let personObject = {}
    let personAllObjects = []
    let columnSetNumbers = []

    let columsAll = document.querySelectorAll('thead tr th input')

    for (let index = 0; index < columsAll.length; index++) {
        let checkedState = columsAll[index].checked;

        if (checkedState) {
            columnSetNumbers.push(index)
        }

    }

    let columnTitles = document.querySelectorAll('thead tr')[0].getElementsByTagName('th');
    let rowsCount = document.querySelectorAll('tbody tr').length

    for (let row = 0; row < rowsCount; row++) {
        columnSetNumbers.forEach((element) => {

            let key = columnTitles[element].textContent.trim().toLowerCase()
            let value = document.querySelectorAll('tbody tr')[row].getElementsByTagName('td')[element].textContent
            personObject[key] = value
        });
        personAllObjects.push(Object.assign(personObject))
        personObject = {}
    }

    document.getElementById('output').value = JSON.stringify(personAllObjects)

}