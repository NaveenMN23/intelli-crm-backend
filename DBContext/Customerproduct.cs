// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace IntelliCRMAPIService
{
    public partial class Customerproduct
    {
        public int Customerproductid { get; set; }
        public int? Useridfk { get; set; }
        public int? Productid { get; set; }
        public string Productname { get; set; }
        public string Productprice { get; set; }
        public string Qtyassign { get; set; }
        public string Createdby { get; set; }
        public DateTime? Createddate { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }

        public virtual Users UseridfkNavigation { get; set; }
    }
}