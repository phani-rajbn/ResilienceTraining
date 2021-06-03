function testFunc(v1, v2, v3) {
    if (v1 != undefined)
        console.log(v1);
    if (v2 != undefined)
        console.log(v2);
    if (v3 != undefined)
        console.log(v3);
}

//JS funtions will automatically have optional arguements, if the caller dont pass the arg, the function must have a logic to evade it. 
//testFunc();

function addFunc(first, second) {
    return first + second;
}

function mulFunc(first, second) {
    return first * second;
}

