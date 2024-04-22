using System.Data.SqlClient;
using System.Security.Cryptography;
using APBD_5.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace APBD_5.Repositories;

public class AnimalRepository : IAnimalsRepository
{

    private IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // public IEnumerable<Animal> GetAnimals()
    // {
    //     using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
    //     con.Open();
    //
    //     using var cmd = new SqlCommand();
    //     cmd.Connection = con;
    //     cmd.CommandText = "SELECT * FROM Animals";
    //
    //     var dr = cmd.ExecuteReader();
    //     
    //     var animals = new List<Animal>();
    //     while (dr.Read())
    //     {
    //         var animal = new Animal();
    //
    //         animal.Id = (int)dr["Id"];
    //         animal.Name = dr["Name"].ToString();
    //         animal.Description = dr["Description"].ToString();
    //         animal.Category = dr["Category"].ToString();
    //         animal.Area = dr["Area"].ToString();
    //         
    //         animals.Add(animal);
    //     }
    //     return animals;
    // }

    public IEnumerable<Animal> GetAnimalsOrderBy(string orderBy)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        
        switch (orderBy.ToLower())
        {
            case "name":
                cmd.CommandText = "SELECT * FROM Animals Order By Name";
                break;
            case "description":
                cmd.CommandText = "SELECT * FROM Animals Order By Description";
                break;
            case "category":
                cmd.CommandText = "SELECT * FROM Animals Order By Category";
                break;
            case "area":
                cmd.CommandText = "SELECT * FROM Animals Order By Area";
                break;
        }

        var dr = cmd.ExecuteReader();
        var animals = new List<Animal>();
        while (dr.Read())
        {
            var animal = new Animal();

            animal.Id = (int)dr["Id"];
            animal.Name = dr["Name"].ToString();
            animal.Description = dr["Description"].ToString();
            animal.Category = dr["Category"].ToString();
            animal.Area = dr["Area"].ToString();
            
            animals.Add(animal);
        }
        return animals;
    }
    
    public int CreateAnimal(Animal animal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText =
            "INSERT INTO Animals(Name, Description, Category, Area) VALUES(@Name, @Description, @Category, @Area)";
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int DeleteAnimal(int id)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM Animals WHERE Id = @Id";
        cmd.Parameters.AddWithValue("@Id", id);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int UpdateAnimal(Animal animal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE Animals SET Name=@Name, Description=@Description, Category=@Category, Area=@Area2";
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);

        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
}