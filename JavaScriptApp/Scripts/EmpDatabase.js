//Create an Employee Class
class employee {
    constructor(id, name, salary) {
        this.empId = id;
        this.empName = name;
        this.empSalary = salary;
    }
    //Not required to create fields of UR class, internally all fields are like dictionary, it stores the data as key-value pair..
}


//Create Repository class with CRUD operations

class EmpDatabase {
    empList = [];//blank array...

    addEmp(emp) {
        this.empList.push(emp);
    }

    getAll() {
        return this.empList;
    }

    deleteEmp = function (id) {
        let found = empList.find((emp) => emp.empId == id);
        let index = empList.indexOf(found);
        empList.splice(index, 1);
    }

    updateEmp(emp) {
        let found = empList.find((e) => e.empId == emp.empId);
        found = new employee(emp.empId, emp.empName, emp.empSalary);
    }
}
/////////////////To test the code before U call it in the user interface...
//function test() {
//    let db = new EmpDatabase();
//    db.addEmp(new employee(123, "Phaniraj", 34000));
//    db.addEmp(new employee(124, "Ramesh", 34000));
//    db.addEmp(new employee(125, "Cheran", 34000));
//    db.addEmp(new employee(126, "Kasturi", 34000));
//    console.log(db.getAll());
//}

//test();