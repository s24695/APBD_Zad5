using APBD_5.DTOs;
using APBD_5.Models;

namespace APBD_5.Repositories;

public interface IAnimalsRepository
{
    IEnumerable<Animal> GetAnimals();

    Animal GetAnimalById(int id);

    public int CreateAnimal(Animal animal);
    
    public int DeleteAnimal(int id);
    
    public int UpdateAnimal(Animal animal);
}