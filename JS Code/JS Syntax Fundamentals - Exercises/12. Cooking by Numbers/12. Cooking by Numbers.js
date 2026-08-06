function solve(stringNumber,oper1,oper2,oper3,oper4,oper5) {
    let number = parseInt(stringNumber)


    if ( oper1 == 'chop') {
        number /= 2
        console.log(number)
    }
    else if (oper1 == 'dice') {
        number = Math.sqrt(number)
        console.log(number)
    }
    else if (oper1 == 'spice') {
        number += 1
        console.log(number)
    }
    else if (oper1 == 'bake') {
        number *= 3
        console.log(number)
    }
    else if (oper1 == 'fillet') {
        number *= 0.80
        console.log(number.toFixed(1))
    }

    if ( oper2 == 'chop') {
        number /= 2
        console.log(number)
    }
    else if (oper2 == 'dice') {
        number = Math.sqrt(number)
        console.log(number)
    }
    else if (oper2 == 'spice') {
        number += 1
        console.log(number)
    }
    else if (oper2 == 'bake') {
        number *= 3
        console.log(number)
    }
    else if (oper2 == 'fillet') {
        number *= 0.80
        console.log(number.toFixed(1))
    }

    if ( oper3 == 'chop') {
        number /= 2
        console.log(number)
    }
    else if (oper3 == 'dice') {
        number = Math.sqrt(number)
        console.log(number)
    }
    else if (oper3 == 'spice') {
        number += 1
        console.log(number)
    }
    else if (oper3 == 'bake') {
        number *= 3
        console.log(number)
    }
    else if (oper3 == 'fillet') {
        number *= 0.80
        console.log(number.toFixed(1))
    }

    if ( oper4 == 'chop') {
        number /= 2
        console.log(number)
    }
    else if (oper4 == 'dice') {
        number = Math.sqrt(number)
        console.log(number)
    }
    else if (oper4 == 'spice') {
        number += 1
        console.log(number)
    }
    else if (oper4 == 'bake') {
        number *= 3
        console.log(number)
    }
    else if (oper4 == 'fillet') {
        number *= 0.80
        console.log(number.toFixed(1))
    }

    if ( oper5 == 'chop') {
        number /= 2
        console.log(number)
    }
    else if (oper5 == 'dice') {
        number = Math.sqrt(number)
        console.log(number)
    }
    else if (oper5 == 'spice') {
        number += 1
        console.log(number)
    }
    else if (oper5 == 'bake') {
        number *= 3
        console.log(number)
    }
    else if (oper5 == 'fillet') {
        number *= 0.80
        console.log(number.toFixed(1))
    }
    

}

solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet')
// function solve(items) {
//     let number = parseInt(items[0])
//     for (let i = 1; i <= items.length; i++) {

//         if (items[i] == 'chop') {
//             number /= 2
//         }
//         else if (items[i] == 'dice') {
//             number = Math.sqrt(number)
//         }
//         else if (items[i] == 'spice') {
//             number += 1
//         }
//         else if (items[i] == 'bake') {
//             number *= 3
//         }
//         else if (items[i] == 'fillet') {
//             number *= 0.80
//         }

//         console.log(number)
//     }
// }
