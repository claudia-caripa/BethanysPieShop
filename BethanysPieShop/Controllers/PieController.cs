using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        //Create an action method, List, that is going to go to the repository and ask for all the pies to be returned 

        //First create a readonly instance of IPieRepository and ICategoryRepository
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        //Initialize them through the use of the constructor
        //Here we are using constructor injection because we registered the IPieRepository and ICategoryRepository in the Program, so an instance of MockPieRepository and MockCategoryRepository will be injected
        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        
        //Create the first action method
        //The return type is IActionResult, that is the overarching interface type that all results will implement 
        public IActionResult List()
        {
            /*
            //ViewBag is dynamic, you can add any property onto it
            // ViewBag is shared between the controller and the view
            //The view will be able to access the properties inside of the ViewBag
            ViewBag.CurrentCategory = "Cheese cakes";

            //For now this will return a View passing in he _pieRepository.AllPies
            return View(_pieRepository.AllPies);*/

            //Now instead of passing the date in two ways, I can now use the constructor of PieListViewModel and pass in the AllPies and the CurrentCategory and then return that to the view
            PieListViewModel pieListViewModel = new PieListViewModel(_pieRepository.AllPies, "All Pies");

            return View(pieListViewModel);
        }


        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);

            if(pie == null)
                return NotFound();
            return View(pie);
        }


    }
}
