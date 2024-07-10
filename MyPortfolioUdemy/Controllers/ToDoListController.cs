using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
	public class ToDoListController : Controller
	{
		MyPortfolioContext portfolioContext = new MyPortfolioContext();

		public IActionResult Index()
		{
			var values = portfolioContext.ToDoLists.ToList();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateToDoList()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateToDoList(ToDoList toDoList)
		{
			toDoList.Status = false;
			portfolioContext.ToDoLists.Add(toDoList);
			portfolioContext.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult DeleteToDoList(int id)
		{
			var values = portfolioContext.ToDoLists.Find(id);
			portfolioContext.ToDoLists.Remove(values);
			portfolioContext.SaveChanges();
			return RedirectToAction("Index");

		}

		[HttpGet]
		public IActionResult UpdateToDoList(int id)
		{
			var value = portfolioContext.ToDoLists.Find(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateToDoList(ToDoList toDoList)
		{
			portfolioContext.ToDoLists.Update(toDoList);
			portfolioContext.SaveChanges();
			return RedirectToAction("Index");

		}

	
		public IActionResult ChangeToDoListStatusTrue(int id)
		{
			var value = portfolioContext.ToDoLists.Find(id);
			value.Status = true;
			portfolioContext.SaveChanges();

			return RedirectToAction("Index");
		}
		public IActionResult ChangeToDoListStatusFalse(int id)
		{
			var value = portfolioContext.ToDoLists.Find(id);
			value.Status = false;
			portfolioContext.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}
