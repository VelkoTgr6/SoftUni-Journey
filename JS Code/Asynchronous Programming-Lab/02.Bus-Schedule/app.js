function solve() {
    let baseURL = 'http://localhost:3030/jsonstore/bus/schedule'; // Define baseURL outside of the functions
    let nextStop = '';
    let count = 0

    function depart() {
        let initialURL = 'http://localhost:3030/jsonstore/bus/schedule/depot';

        if (count <= 0) {
            fetch(`${initialURL}/${nextStop}`)
                .then(res => res.json())
                .then(data => {
                    let info = document.querySelector('.info');
                    info.textContent = `Next stop ${data.name}`;
                    nextStop = data.next;

                    const departBtn = document.querySelector('#depart');
                    const arriveBtn = document.querySelector('#arrive');

                    departBtn.disabled = true;
                    arriveBtn.disabled = false;

                    initialURL = 'http://localhost:3030/jsonstore/bus/schedule'
                    count++
                });
        }else{
            fetch(`${baseURL}/${nextStop}`)
                .then(res => res.json())
                .then(data => {
                    let info = document.querySelector('.info');
                    info.textContent = `Next stop ${data.name}`;
                    nextStop = data.next;

                    const departBtn = document.querySelector('#depart');
                    const arriveBtn = document.querySelector('#arrive');

                    departBtn.disabled = true;
                    arriveBtn.disabled = false;

                    
                    count++
                });
        }
    }

    async function arrive() {
        await fetch(`${baseURL}/${nextStop}`)
            .then(res => res.json())
            .then(data => {
                let info = document.querySelector('.info');
                info.textContent = `Next stop ${data.name}`;
                nextStop = data.next;

                const departBtn = document.querySelector('#depart');
                const arriveBtn = document.querySelector('#arrive');

                departBtn.disabled = false;
                arriveBtn.disabled = true;
            });
    }

    return {
        depart,
        arrive
    };
}

let result = solve();