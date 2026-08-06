function attachEvents() {
    let locationElement = document.getElementById('location')
    let btn = document.getElementById('submit')
    const baseURL = 'http://localhost:3030/jsonstore/forecaster'
    let forcastElement = document.getElementById('forecast')

    const symbols = {
        Sunny: "☀",
        PartlySunny: "⛅",
        Overcast: "☁",
        Rain: "☂",
        Degrees: "°"
    }

    btn.addEventListener('click', () => {
        fetch(`${baseURL}/locations`)
            .then(res => res.json())
            .then(locationData => {
                const { code } = locationData.find(location => location.name === locationElement.value)

                return Promise.all(
                    [
                        fetch(`${baseURL}/today/${code}`),
                        fetch(`${baseURL}/upcoming/${code}`)

                    ]
                )
            })
            .then(responses => Promise.all(responses.map(res => res.json())))
            .then(([todayData, upcomingData]) => {
                

                forcastElement.style.display = 'block'

                let todayDiv = document.createElement('div')
                todayDiv.classList.add('forecasts')
                document.querySelector('#current').appendChild(todayDiv)

                let conditionSymbol = document.createElement('span')
                conditionSymbol.classList.add('condition')
                conditionSymbol.classList.add('symbol')
                if (todayData.forecast.condition !== 'Partly Sunny') {
                    conditionSymbol.textContent = symbols[todayData.forecast.condition]
                } else if (todayData.forecast.condition == 'Partly Sunny') {
                    conditionSymbol.textContent = symbols.PartlySunny
                }
                todayDiv.appendChild(conditionSymbol)

                let conditionSpan = document.createElement('span')
                conditionSpan.classList.add('condition')
                todayDiv.appendChild(conditionSpan)

                let forecastCity = document.createElement('span')
                forecastCity.classList.add('forecast-data')
                forecastCity.textContent = todayData.name
                conditionSpan.appendChild(forecastCity)

                let forecastTemp = document.createElement('span')
                forecastTemp.classList.add('forecast-data')
                forecastTemp.textContent = `${todayData.forecast.low}${symbols.Degrees}/${todayData.forecast.high}${symbols.Degrees}`
                conditionSpan.appendChild(forecastTemp)

                let forecastCondition = document.createElement('span')
                forecastCondition.classList.add('forecast-data')
                forecastCondition.textContent = todayData.forecast.condition
                conditionSpan.appendChild(forecastCondition)

                let upcomingDiv = document.createElement('div')
                upcomingDiv.classList.add('forecast-info')
                document.getElementById('upcoming').appendChild(upcomingDiv)

                let upcomingSpan = document.createElement('span')
                upcomingSpan.classList.add('upcoming')
                upcomingDiv.appendChild(upcomingSpan)

                let upcomingSpanSymbol = document.createElement('span')
                upcomingSpanSymbol.classList.add('symbol')
                if (upcomingData.forecast[0].condition !== 'Partly sunny') {
                    upcomingSpanSymbol3.textContent = symbols[upcomingData.forecast[0].condition]
                } else if (upcomingData.forecast[0].condition == 'Partly sunny') {
                    upcomingSpanSymbol.textContent = symbols.PartlySunny
                }
                upcomingSpan.appendChild(upcomingSpanSymbol)

                let upcomingSpanDegrees=document.createElement('span')
                upcomingSpanDegrees.classList.add('forecast-data')
                upcomingSpanDegrees.textContent=`${upcomingData.forecast[0].low}${symbols.Degrees}/${upcomingData.forecast[0].high}${symbols.Degrees}`
                upcomingSpan.appendChild(upcomingSpanDegrees)

                let upcomingSpanCondition=document.createElement('span')
                upcomingSpanCondition.classList.add('forecast-data')
                upcomingSpanCondition.textContent=`${upcomingData.forecast[0].condition}`
                upcomingSpan.appendChild(upcomingSpanCondition)

                ////////////////////////////////

                let upcomingSpan2 = document.createElement('span')
                upcomingSpan2.classList.add('upcoming')
                upcomingDiv.appendChild(upcomingSpan2)

                let upcomingSpanSymbol2 = document.createElement('span')
                upcomingSpanSymbol2.classList.add('symbol')
                if (upcomingData.forecast[1].condition !== 'Partly sunny') {
                    upcomingSpanSymbol2.textContent = symbols[upcomingData.forecast[1].condition]
                } else if (upcomingData.forecast[1].condition == 'Partly sunny') {
                    upcomingSpanSymbol.textContent = symbols.PartlySunny
                }
                upcomingSpan2.appendChild(upcomingSpanSymbol2)

                let upcomingSpanDegrees2=document.createElement('span')
                upcomingSpanDegrees2.classList.add('forecast-data')
                upcomingSpanDegrees2.textContent=`${upcomingData.forecast[1].low}${symbols.Degrees}/${upcomingData.forecast[1].high}${symbols.Degrees}`
                upcomingSpan2.appendChild(upcomingSpanDegrees2)

                let upcomingSpanCondition2=document.createElement('span')
                upcomingSpanCondition2.classList.add('forecast-data')
                upcomingSpanCondition2.textContent=`${upcomingData.forecast[1].condition}`
                upcomingSpan2.appendChild(upcomingSpanCondition2)

                ///////////////////////////////////////////////////

                let upcomingSpan3 = document.createElement('span')
                upcomingSpan3.classList.add('upcoming')
                upcomingDiv.appendChild(upcomingSpan3)

                let upcomingSpanSymbol3 = document.createElement('span')
                upcomingSpanSymbol3.classList.add('symbol')
                if (upcomingData.forecast[2].condition !== 'Partly sunny') {
                    upcomingSpanSymbol3.textContent = symbols[upcomingData.forecast[2].condition]
                } else if (upcomingData.forecast[2].condition == 'Partly sunny') {
                    upcomingSpanSymbol.textContent = symbols.PartlySunny
                }
                upcomingSpan3.appendChild(upcomingSpanSymbol3)

                let upcomingSpanDegrees3=document.createElement('span')
                upcomingSpanDegrees3.classList.add('forecast-data')
                upcomingSpanDegrees3.textContent=`${upcomingData.forecast[2].low}${symbols.Degrees}/${upcomingData.forecast[2].high}${symbols.Degrees}`
                upcomingSpan3.appendChild(upcomingSpanDegrees3)

                let upcomingSpanCondition3=document.createElement('span')
                upcomingSpanCondition3.classList.add('forecast-data')
                upcomingSpanCondition3.textContent=`${upcomingData.forecast[2].condition}`
                upcomingSpan3.appendChild(upcomingSpanCondition3)

                
            })
    })
}

attachEvents();