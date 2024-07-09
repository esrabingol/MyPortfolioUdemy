using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;

namespace MyPortfolioUdemy.ViewComponents
{
	public class _ContactComponentPartial : ViewComponent
	{
		MyPortfolioContext portfolioUdemy = new MyPortfolioContext();

		public IViewComponentResult Invoke()
		{
			var values = portfolioUdemy.Contacts.ToList();
			return View(values);
		}
	}
}
