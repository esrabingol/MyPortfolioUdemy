using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.Controllers
{
	public class StatisticController : Controller
	{
		MyPortfolioContext portfolioContext = new MyPortfolioContext();
		public IActionResult Index()
		{
			ViewBag.v1 = portfolioContext.Skills.Count();
			ViewBag.v2 = portfolioContext.Messages.Count();

			ViewBag.v3 = portfolioContext.Messages.Where(x => x.IsRead == false).Count();
			ViewBag.v4 = portfolioContext.Messages.Where(x => x.IsRead == true).Count();
			ViewBag.v7 = portfolioContext.Experiences.Count();
			ViewBag.v8 = portfolioContext.Portfolios.Count();
			ViewBag.v9= portfolioContext.Features.Count();
			return View();
		}
	}
}
