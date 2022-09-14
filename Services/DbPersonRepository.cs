using DSLabW03CRRUD.Models.Entities;
using System.Security.Cryptography;

namespace DSLabW03CRRUD.Services;

public class DbPersonRepository : IPersonRepository
{
    private readonly ApplicationDbContext _db;
    
    public DbPersonRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public Person Create(Person newPerson)
    {
        _db.People.Add(newPerson);
        _db.SaveChanges();
        return newPerson;
    }
    
    public void Delete(int id)
    {
        Person? personToDelete = Read(id);
        if (personToDelete != null)
        {
            _db.People.Remove(personToDelete);
            _db.SaveChanges();
        }
    }
    
    public Person? Read(int id)
    {
        return _db.People.Find(id);
    }

    public ICollection<Person> ReadAll()
    {
        return _db.People.ToList();
    }

    public void Update(int oldId, Person person)
    {
        Person? personToUpdate = Read(oldId);
        if (personToUpdate != null)
        {
            personToUpdate.FirstName = person.FirstName;
            personToUpdate.MiddleName = person.MiddleName;
            personToUpdate.LastName = person.LastName;
            personToUpdate.DateOfBirth = person.DateOfBirth;
            _db.SaveChanges();
        }
    }
}
