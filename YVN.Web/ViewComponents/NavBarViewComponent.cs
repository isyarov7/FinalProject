using Microsoft.AspNetCore.Mvc;
using YVN.Web.Services;
using YVN.Web.Views.NavBarView;

namespace YVN.Web.ViewComponents
{
    [ViewComponent(Name = "NavBar")]
    public class NavBarViewComponent : ViewComponent
    {

        private readonly IYearsService yearsSercive;

        public NavBarViewComponent(IYearsService yearsSercive)
        {
            this.yearsSercive = yearsSercive;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new NavBarViewModel();
            viewModel.Years = this.yearsSercive.GetLastYears(5);
            return this.View();
        }
    }
}