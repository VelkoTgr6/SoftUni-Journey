document.getElementById('generateBtn').addEventListener('click', generate);
document.getElementById('buyBtn').addEventListener('click', buy);

function generate() {
    const furnitureData = document.getElementById('furnitureData').value.trim();
    const furniture = JSON.parse(furnitureData);

    const tableBody = document.querySelector('#furnitureTable tbody');
    tableBody.innerHTML = ''; // Clear previous rows

    furniture.forEach(item => {
        const row = tableBody.insertRow();
        const imgCell = row.insertCell();
        const nameCell = row.insertCell();
        const priceCell = row.insertCell();
        const decFactorCell = row.insertCell();
        const buyCell = row.insertCell();

        const img = document.createElement('img');
        img.src = item.img;
        imgCell.appendChild(img);

        nameCell.textContent = item.name;
        priceCell.textContent = item.price;
        decFactorCell.textContent = item.decFactor;

        const checkbox = document.createElement('input');
        checkbox.type = 'checkbox';
        buyCell.appendChild(checkbox);
    });
}

function buy() {
    const checkboxes = document.querySelectorAll('#furnitureTable tbody input[type="checkbox"]:checked');
    const resultTextarea = document.getElementById('result');
    let totalPrice = 0;
    let totalDecFactor = 0;
    const boughtItems = [];

    checkboxes.forEach(checkbox => {
        const row = checkbox.parentElement.parentElement;
        const name = row.cells[1].textContent;
        const price = parseFloat(row.cells[2].textContent);
        const decFactor = parseFloat(row.cells[3].textContent);

        boughtItems.push(name);
        totalPrice += price;
        totalDecFactor += decFactor;
    });

    resultTextarea.textContent = `Bought furniture: ${boughtItems.join(', ')}`;
    resultTextarea.textContent += `\nTotal price: ${totalPrice.toFixed(2)}`;
    resultTextarea.textContent += `\nAverage decoration factor: ${(totalDecFactor / boughtItems.length).toFixed(2)}`;
}