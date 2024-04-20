using System.Data.SqlClient;
using APBD_5.DTOs;
using APBD_5.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD_5.Controllers;

[Route("/api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<AnimalDTO>> GetAnimals()
    {
        using SqlConnection connection = new SqlConnection("Data Source=db-mssql;Initial Catalog=s24695;Integrated Security=True"); // Nuget package System.Data.SqlClient

        using SqlCommand command = new SqlCommand();

        command.Connection = connection;
        command.CommandText = "SELECT * FROM Animals";
        
        connection.Open();

        SqlDataReader reader = command.ExecuteReader();

        List<AnimalDTO> animals = new List<AnimalDTO>();

        while (reader.Read())
        {
            AnimalDTO animal = new AnimalDTO();
            animal.Id = (int)reader["Id"];
            animal.Name = (string)reader["Name"];
            animal.Description = (string)reader["Description"];
            animal.Category = (string)reader["Category"];
            animal.Area = (string)reader["Area"];
        }
        
        return Ok();
    }
}

//com.Parameters.AddWith
//Select scope identity - zwraca id affected po operacji
//Dto - w komunikacji wewnątrz aplikacji, zwykły obiekt (animal) wtedy kiedy komunikujemy sie z DB czyli w Repository
// controller -> service -> repo -> Db   (injections)
//zamiana typu animal na animalDTO w service

