function getInfo() {
    let stopIDField = document.querySelector('#stopId');

    let baseURL = 'http://localhost:3030/jsonstore/bus/businfo'


    fetch(`${baseURL}/${stopIDField.value}`)
        .then(res => res.json())
        .then(data => {

            document.querySelector('#stopName').textContent = data.name

            let buses = document.querySelector('#buses')
            buses.innerHTML=''

            for (const key in data.buses) {
                let busesInfo = document.createElement('li')
                busesInfo.textContent = `Bus ${key} arrives in ${data.buses[key]} minutes`
                buses.appendChild(busesInfo)
            }


        })
        .catch(err=>  {
            buses.innerHTML=''
            document.querySelector('#stopName').textContent = 'Error'
        })
}