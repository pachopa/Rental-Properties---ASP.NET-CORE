using CPRG214.Properties.Data;
using System.Collections;
using System.Linq;

namespace CPRG214.Properties.BLL
{
    public class RenterManager
    {
        public static IList GetAsKeyValuePairs()
        {
            var context = new RentalsContext();
            var types = context.Renters.Select(r => new
            {
                Value = r.Id,
                Text = r.FirstName + "" + r.LastName
            }).ToList();
            return types;
        }
    }
}
