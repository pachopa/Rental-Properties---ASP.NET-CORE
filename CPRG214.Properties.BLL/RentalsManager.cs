using CPRG214.Properties.Data;
using CPRG214.Properties.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CPRG214.Properties.BLL
{
    public class RentalsManager
    {
        // method to pull list of rental properties from RentalContext DB (in Data project)
        public static List<RentalProperty> GetAll()
        {
            var context = new RentalsContext();
            var rentals = context.RentalProperties.Include(r => r.Owner).
                Include(rp => rp.PropertyType).ToList();
            return rentals;
        }

        // method to add new row of data (rental) into RentalProperty Table 
        // (RentalProperty class object)
        public static void Add(RentalProperty rental)
        {
            var context = new RentalsContext();
            context.RentalProperties.Add(rental);
            context.SaveChanges();
        }
    }
}
