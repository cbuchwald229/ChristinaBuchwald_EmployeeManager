function searchEmployee() {
    var search = $("#searchString").val();

    $.ajax({
        url: "Search",
        data: { searchString: search }
    }).done(function (data) {
        $("#employeeId").val(data.EmployeeId);
        $("#firstName").val(data.FirstName);
        $("#middleName").val(data.MiddleName);
        $("#lastName").val(data.LastName);
        $("#birthDate").val(JsonDateToIsoDate(data.BirthDate));
        $("#hireDate").val(JsonDateToIsoDate(data.HireDate));
        $("#department").val(data.Department);
        $("#jobTitle").val(data.JobTitle);
        $("#salary").val(data.Salary);
        $("#salaryType").dropdown(data.SalaryType);
        $("#availableHours").val(data.AvailableHours);
    });
}

function updateEmployee() {
    var employeeId = $("#employeeId").val();
    var firstName = $("#firstName").val();
    var middleName = $("#middleName").val();
    var lastName = $("#lastName").val();
    var birthDate = $("#birthDate").val();
    var hireDate = $("#hireDate").val();
    var department = $("#department").val();
    var jobTitle = $("#jobTitle").val();
    var salary = $("#salary").val();
    var salaryType = $("#salaryType").val();
    var availableHours = $("#availableHours").val();

    $.ajax({
        url: "UpdateEmployee",
        dataType: "json",
        data: {
            EmployeeId: employeeId,
            FirstName: firstName,
            MiddleName: middleName,
            LastName: lastName,
            BirthDate: birthDate,
            HireDate: hireDate,
            Department: department,
            JobTitle: jobTitle,
            Salary: salary,
            SalaryType: salaryType,
            AvailableHours: availableHours
        }
    }).done(function (data) {
        if (data) {
            $("#successMessage").removeClass("hidden")
                .addClass("visible");
        } else {
            $("#errorMessage").removeClass("hidden")
                .addClass("visible");
        }
    });
}

function JsonDateToIsoDate(date) {
    return new Date(parseInt(date.replace('/Date(', ''))).toISOString().substr(0, 10);
}