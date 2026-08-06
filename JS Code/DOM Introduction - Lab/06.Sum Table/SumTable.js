function sumTable() {
    let list=document.querySelectorAll('table td:nth-child(2)')

    let sum=0

    for (const numb of list) {
        sum += Number(numb.textContent);
        console.log(Number(numb.textContent));
    }
    document.getElementById('sum').textContent=sum

}