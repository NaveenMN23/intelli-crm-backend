﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Collections;

namespace IntelliCRMAPIService.Postgres
{
    public partial class Userdetails
    {
        public int Userdetailsid { get; set; }
        public int? UseridFk { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Coutry { get; set; }
        public double? Creditlimit { get; set; }
        public double? Soareceviedamount { get; set; }
        public BitArray Uploadfile { get; set; }
        public string Createdby { get; set; }
        public DateOnly? Createddate { get; set; }
        public string Modifiedby { get; set; }
        public DateOnly? Modifieddate { get; set; }

        public virtual Users UseridFkNavigation { get; set; }
    }
}