using DSLabW03CRRUD.Models.Entities;
using DSLabW03CRRUD.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSLabW03CRRUD.Controllers;

public class PersonController : Controller
{
    private readonly IPersonRepository _personRepo;
    
    public PersonController(IPersonRepository personRepo)
    {
        _personRepo = personRepo;
    }

    public IActionResult Index()
    {
        var model = _personRepo.ReadAll();
        return View(model);
    }

    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Person newPerson)
    {
        if (ModelState.IsValid)
        {
            _personRepo.Create(newPerson);
            return RedirectToAction("Index");
        }
        return View(newPerson);
    }

    public IActionResult Details(int id)
    {
        var person = _personRepo.Read(id);
        if (person == null)
        {
            return RedirectToAction("Index");
        }
        return View(person);
    }

    public IActionResult Edit(int id)
    {
        var person = _personRepo.Read(id);
        if (person == null)
        {
            return RedirectToAction("Index");
        }
        return View(person);
    }
    
    [HttpPost]
    public IActionResult Edit(Person person)
    {
        if (ModelState.IsValid)
        {
            _personRepo.Update(person.Id, person);
            return RedirectToAction("Index");
        }
        return View(person);
    }

    public IActionResult Delete(int id)
    {
        var person = _personRepo.Read(id);
        if (person == null)
        {
            return RedirectToAction("Index");
        }
        return View(person);
    }
    
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _personRepo.Delete(id);
        return RedirectToAction("Index");
    }
}
