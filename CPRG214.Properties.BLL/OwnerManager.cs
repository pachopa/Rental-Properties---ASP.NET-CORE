using CPRG214.Properties.Data;
using System.Collections;
using System.Linq;

namespace CPRG214.Properties.BLL
{
    public class OwnerManager
    {
        public static IList GetAsKeyValuePairs()
        {
            var context = new RentalsContext();
            var owners = context.Owners.Select(o => new
            {
                Value = o.Id,
                Text = o.Name
            }).ToList();
            return owners;
        }
    }
}
