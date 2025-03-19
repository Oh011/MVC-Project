

// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.




let DepartmentSearch = document.getElementById("DepartmentSearch")
let EmployeeSearch = document.getElementById("EmployeeSearch")


console.log(EmployeeSearch)


if (DepartmentSearch != null) {
    DepartmentSearch.onkeyup = async function () {


        var Request = await fetch(`/Department/SearchByName?Name=${DepartmentSearch.value}`,

            {


                method: "GET",

                headers: {

                    "Source": "JS"
                }
            }


        

        );


        var Data = await Request.text();



        document.getElementById("Department_rows").innerHTML = Data;

    }


}

if (EmployeeSearch != null) {

    EmployeeSearch.onkeyup = async function () {



        var Request = await fetch(`/Employee/SearchByName?Name=${EmployeeSearch.value}`,
            {


                method: "GET",

                headers: {

                    "Source": "JS"
                }
            });


        var Data = await Request.text();

        document.getElementById("Employee_Rows").innerHTML = Data;

    }

}
