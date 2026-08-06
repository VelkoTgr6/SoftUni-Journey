function solve(percent) {
    let num=percent/10;
    let arr=[];
    for (let i = 1; i <=10; i++) {
        if (num>0) {
            arr.push('%')
            num--;
        }
        else if(num==0){
            arr.push('.')
        }
    }
    if (percent===100) {
        console.log('100% Complete!')
        console.log(`[${arr.join("")}]`)
    }
    
    else{
        console.log(`${percent}% [${arr.join("")}]`)
        console.log('Still loading...')
    }

}
solve(30)