using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
	public class ExperienceController : Controller
	{
		MyPortfolioContext portfolioContext = new MyPortfolioContext();
		public IActionResult ExperienceList()
		{
			var values = portfolioContext.Experiences.ToList();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateExperience()
		{
			return View();
		}

		[HttpPost]
		public IActionResult CreateExperience(Experience experience)
		{
			portfolioContext.Experiences.Add(experience);
			portfolioContext.SaveChanges();
			return RedirectToAction("ExperienceList");
		}

		public IActionResult DeleteExperience(int id)
		{
			var value = portfolioContext.Experiences.Find(id);
			if (value != null)
			{
				portfolioContext.Experiences.Remove(value);
				portfolioContext.SaveChanges();
			}

			return RedirectToAction("ExperienceList");

		}

		[HttpGet]
		public IActionResult UpdateExperience(int id)
		{
			var value = portfolioContext.Experiences.Find(id);

			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateExperience(Experience experience)
		{

			portfolioContext.Experiences.Update(experience);
			portfolioContext.SaveChanges();

			return RedirectToAction("ExperienceList");
		}


	}
}
