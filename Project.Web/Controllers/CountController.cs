using System.Web.Mvc;
using Project.BusinessObject;
using Project.Service;
using Project.Web.Models;
using System.Linq;

namespace Project.Web.Controllers
{
    public class CountController : Controller
    {
        private readonly ICountService CountService;

        public CountController()
        {
            CountService = new CountService();
        }

        public ActionResult Index()
        {
            var count = CountService.GetAll().FirstOrDefault();

            if (count == null)
            {
                count = new Count {CountNumber = 1};
                CountService.Insert(count);
            }

            return View(ConvertToViewModel(count));
        }

        [HttpPost]
        public ActionResult Index(CountViewModel viewModel)
        {
            ModelState.Clear();

            if (viewModel.CountNumber < 10)
            {
                viewModel.CountNumber++;
                CountService.Update(ConvertToEntity(viewModel));
            }
            else
            {
                ModelState.AddModelError("", "You have reached the maximum number.");
            }

            return View(viewModel);
        }

        #region "Mapping functions"
        private CountViewModel ConvertToViewModel(Count count)
        {
            CountViewModel countViewModel = new CountViewModel();
            countViewModel.Id = count.Id;
            countViewModel.CountNumber = count.CountNumber;

            return countViewModel;
        }

        private Count ConvertToEntity(CountViewModel viewModel)
        {
            Count count = new Count();
            count.Id = viewModel.Id;
            count.CountNumber = viewModel.CountNumber;

            return count;
        }
        #endregion
    }
}