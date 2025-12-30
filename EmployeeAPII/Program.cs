var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors();

app.UseHttpsRedirection();

var employees = new List<Employee>
{
    new Employee { Name = "Ilias", Surname = "Fytsilis", Type = "Employee" },
    new Employee { Name = "Nikos", Surname = "Papadopoulos", Type = "Manager" }
};

app.MapGet("/employees", () => employees);

app.MapPost("/employees", (Employee employee) =>
{
    employees.Add(employee);
        return Results.Created($"/employees/{employee.Surname}", employee);
});

app.MapDelete("/employees/{surname}", (string surname) =>
{
    var employee = employees.FirstOrDefault(e =>
        e.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase));

    if (employee == null)
        return Results.NotFound();

    employees.Remove(employee);
        return Results.Ok();
});

app.Run();
