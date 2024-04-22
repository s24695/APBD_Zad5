using System.Data.SqlClient;
using System.Net.Http.Headers;
using APBD_5.DTOs;
using APBD_5.Models;
using APBD_5.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_5.Controllers;

[Route("/api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{

    private IAnimalsService _animalsService;

    public AnimalsController(IAnimalsService animalsService)
    {
        _animalsService = animalsService;
    }

    // [HttpGet]
    // public ActionResult<IEnumerable<Animal>> GetAnimals()
    // {
    //     var animals = _animalsService.GetAnimals();
    //     return Ok(animals);
    // }

    [HttpGet]
    public ActionResult<IEnumerable<Animal>> GetAnimalsOrderBy(string orderBy)
    {
        var animalsOrderby = _animalsService.GetAnimalsOrderBy(orderBy);
        return Ok(animalsOrderby);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        var animals = _animalsService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created,animals);
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animalToDelete = _animalsService.DeleteAnimal(id);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(Animal animal)
    {
        var animalToUpdate = _animalsService.UpdateAnimal(animal);
        return Ok(animalToUpdate);
    }
}

