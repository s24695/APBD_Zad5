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

    [HttpGet]
    public ActionResult<IEnumerable<AnimalDTO>> GetAnimals()
    {
        var animals = _animalsService.GetAnimals();
        return Ok(animals);
    }

    [HttpGet("{id:int}")]
    public ActionResult<IEnumerable<Animal>> GetAnimalById(int id)
    {
        var animal = _animalsService.GetAnimalById(id);
        return Ok(animal);
    }

    [HttpPost]
    public IActionResult CreateAnimal(Animal animal)
    {
        var animals = _animalsService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created,animals);
    }
    
    [HttpDelete]
    public IActionResult DeleteAnimal(int id)
    {
        var animalToDelete = _animalsService.DeleteAnimal(id);
        return NoContent();
    }

    [HttpPut]
    public IActionResult UpdateAnimal(Animal animal)
    {
        var animalToUpdate = _animalsService.UpdateAnimal(animal);
        return Ok(animalToUpdate);
    }
}

