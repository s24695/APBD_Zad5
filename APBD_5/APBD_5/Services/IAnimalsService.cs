using APBD_5.Models;

namespace APBD_5.Services;

public interface IAnimalsService
{ 
    IEnumerable<Animal> GetAnimals();

    Animal GetAnimalById(int id);

    int CreateAnimal(Animal animal);

    int DeleteAnimal(int id);

    int UpdateAnimal(Animal animal);
}