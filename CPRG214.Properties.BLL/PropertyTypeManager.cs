﻿using CPRG214.Properties.Data;
using System.Collections;
using System.Linq;

namespace CPRG214.Properties.BLL
{
    public class PropertyTypeManager
    {
        public static IList GetAsKeyValuePairs()
        {
            var context = new RentalsContext();
            var types = context.PropertyTypes.Select(t => new
            {
                Value = t.Id,
                Text = t.Style
            }).ToList();
            return types;
        }
    }
}
