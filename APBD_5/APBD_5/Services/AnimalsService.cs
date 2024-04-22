using APBD_5.Models;
using APBD_5.Repositories;

namespace APBD_5.Services;

public class AnimalsService : IAnimalsService
{
    private IAnimalsRepository _animalsRepository;

    public AnimalsService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }
    
    // public IEnumerable<Animal> GetAnimals()
    // {
    //     //Business logic
    //     return _animalsRepository.GetAnimals();
    // }

    public IEnumerable<Animal> GetAnimalsOrderBy(string orderBy)
    {
        return _animalsRepository.GetAnimalsOrderBy(orderBy);
    }
    
    public int CreateAnimal(Animal animal)
    {
        return _animalsRepository.CreateAnimal(animal);
    }

    public int DeleteAnimal(int id)
    {
        return _animalsRepository.DeleteAnimal(id);
    }

    public int UpdateAnimal(Animal animal)
    {
        return _animalsRepository.UpdateAnimal(animal);
    }
}