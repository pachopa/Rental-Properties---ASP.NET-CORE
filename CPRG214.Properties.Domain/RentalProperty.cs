﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CPRG214.Properties.Domain
{
    [Table("RentalProperty")]
    public class RentalProperty
    {
        public int Id { get; set; }
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string PostalCode { get; set; }
        // value types are not-null by default
        public decimal Rent { get; set; }
        public int PropertyTypeId { get; set; }
        public int OwnerId { get; set; }
        //nullable int required if FK is nullable
        public int? RenterId { get; set; }
        //navigation properties
        public PropertyType PropertyType { get; set; }
        public Owner Owner { get; set; }
        public Renter Renter { get; set; }
    }
}
