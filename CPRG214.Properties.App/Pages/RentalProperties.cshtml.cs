using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG214.Properties.BLL;
using CPRG214.Properties.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CPRG214.Properties.App.Pages
{
    public class RentalPropertiesModel : PageModel
    {
        public IList<RentalProperty> Rentals { get; set; }
        public void OnGet()
        {
            Rentals = RentalsManager.GetAll();
        }
    }
}