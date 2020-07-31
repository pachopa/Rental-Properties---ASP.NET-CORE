using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG214.Properties.BLL;
using CPRG214.Properties.Domain;
using CPRG214.Properties.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CPRG214.Properties.Presentation.Controllers
{
    public class RentalsController : Controller
    {
        public IActionResult Index()
        {
            var rentals = RentalsManager.GetAll();
            var viewModels = rentals.Select(r => new RentalViewModel
            {
                Id = r.Id,
                Address = r.Address,
                City = r.City,
                Province = r.Province,
                Owner = r.Owner.Name,
                Rent = r.Rent.ToString(),
                PropertyType = r.PropertyType.Style
            }).ToList();
            //call a local service to get collection of rentals as the viewmodel
            return View(viewModels);
        }
        public IActionResult Create()
        {
            // call the owner manager to get the collection of key value objects
            var owners = OwnerManager.GetAsKeyValuePairs();
            //create a collection of SelectListItems (get list from Owners table). 
            //"Value" & "Text" should match those assigned in OwnersManager
            var list = new SelectList(owners, "Value", "Text");
            //assign the list to ViewBag (strongly typed placeholder)
            ViewBag.OwnerId = list;

            //create the collection of property types select list items 
            //"Value" & "Text" should match those assigned in PropertyTypeManager
            var types = PropertyTypeManager.GetAsKeyValuePairs();
            list = new SelectList(types, "Value", "Text");
            ViewBag.PropertyTypeId = list;

            return View();
        }
        [HttpPost]
        public IActionResult Create(RentalProperty rental)
        {
            try
            {
                RentalsManager.Add(rental);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}