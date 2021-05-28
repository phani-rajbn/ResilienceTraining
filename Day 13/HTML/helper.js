// JavaScript source code
function $(id) {
    return document.getElementById(id).value;
}


class Employee {
    constructor(id, name, address) {
        this.empId = id;
        this.empName = name;
        this.empAddress = address;
    }
}

function callObject() {
    var emp = new Employee(123, "Phaniraj", "Bangalore");
    alert(emp.empName);
}

//todo: Learn HTML, JS from w3schools.com
/*
 * How to create Web pages?
 * How to navigate using hyperlinks?
 * How to create a table in html: table, tr, th, td, thead, tfoot.
 * How to create HTML Controls and take inputs and display outputs.
 * How to create variables in JS.
 * How to create Arrays in JS
 * How to create classes and objects in JS using ES6.(ECMAScript) 
*/