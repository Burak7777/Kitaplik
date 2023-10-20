using Kitaplik.Models;
using Kitaplik.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Kitaplik.Controllers;

public class BookController : Controller
{

    private readonly RepositoryBaglantisi _repository;

    public BookController(RepositoryBaglantisi repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Creat() 
    { 
    return View();
    }

    [HttpPost]
    public IActionResult Creat(Book book)
    {
        _repository.Add(book);
        _repository.SaveChanges();

        return RedirectToAction("Index","Home");
    }

    public IActionResult GetList()
    {
        List<Book> books= _repository.Books.ToList();
        return View(books);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        Book book = _repository.Books.Find(id);
        return View(book);
    }
}
