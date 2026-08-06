function attachEventsListeners() {
    let daysField=document.getElementById('days')
    let daysBtn=document.getElementById('daysBtn')

    let hoursField=document.getElementById('hours')
    let hoursBtn=document.getElementById('hoursBtn')

    let minutesField=document.getElementById('minutes')
    let minutesBtn=document.getElementById('minutesBtn')

    let secondsField=document.getElementById('seconds')
    let secondsBtn=document.getElementById('secondsBtn')

    daysBtn.addEventListener('click',()=>{
        hoursField.value=daysField.value*24
        minutesField.value=hoursField.value*60
        secondsField.value=minutesField.value*60
    })

    hoursBtn.addEventListener('click',()=>{
        daysField.value=hoursField.value/24
        minutesField.value=hoursField.value*60
        secondsField.value=minutesField.value*60
    })

    minutesBtn.addEventListener('click',()=>{
        hoursField.value=minutesField.value/60
        daysField.value=hoursField.value/24
        secondsField.value=minutesField.value*60
    })

    secondsBtn.addEventListener('click',()=>{
        minutesField.value=secondsField.value/60
        hoursField.value=minutesField.value/60
        daysField.value=hoursField.value/24
    })
}