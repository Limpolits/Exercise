using MySql.Data.MySqlClient;

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

string connectionString =
    builder.Configuration.GetConnectionString("MySql");

app.MapGet("/employees", () =>
{
    var employees = new List<Employee>();

    using var conn = new MySqlConnection(connectionString);
    conn.Open();

    var cmd = new MySqlCommand(
        "SELECT idemployees, name, surname, type FROM employees",
        conn);

    using var reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        employees.Add(new Employee
        {
            Id = reader.GetInt32("idemployees"),
            Name = reader.GetString("name"),
            Surname = reader.GetString("surname"),
            Type = reader.GetString("type")
        });
    }

    return Results.Ok(employees);
});


app.MapPost("/employees", (Employee employee) =>
{
    using var conn = new MySqlConnection(connectionString);
    conn.Open();

    var cmd = new MySqlCommand(
        @"INSERT INTO employees (name, surname, type)
          VALUES (@name, @surname, @type)", conn);

    cmd.Parameters.AddWithValue("@name", employee.Name);
    cmd.Parameters.AddWithValue("@surname", employee.Surname);
    cmd.Parameters.AddWithValue("@type", employee.Type);

    cmd.ExecuteNonQuery();

    return Results.Created("/employees", employee);
});


app.MapDelete("/employees/{surname}", (string surname) =>
{
    using var conn = new MySqlConnection(connectionString);
    conn.Open();

    var cmd = new MySqlCommand(
        "DELETE FROM employees WHERE surname = @surname", conn);

    cmd.Parameters.AddWithValue("@surname", surname);

    int rows = cmd.ExecuteNonQuery();

    return rows == 0
        ? Results.NotFound()
        : Results.Ok();
});

app.Run();