function attachEventsListeners() {
    let [inputDistanceField, convertBtn, outputDistanceField] =
        document.getElementsByTagName('input')

    let [inputUnits, outputUnits] = document.getElementsByTagName('select')

    let convertionRates = {
        'km': 1000,
        'm': 1,
        'cm': 0.01,
        'mm': 0.001,
        'mi': 1609.34,
        'yrd': 0.9144,
        'ft': 0.3048,
        'in': 0.0254
    }

    convertBtn.addEventListener('click', convert)

    function convert() {
        let inputDistance = inputDistanceField.value
        let inputUnit = inputUnits.value
        let outputUnit = outputUnits.value

        let result = inputDistance * convertionRates[inputUnit] / convertionRates[outputUnit]

        outputDistanceField.value = result

    }
}