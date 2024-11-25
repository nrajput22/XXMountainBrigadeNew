using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XXMountainBrigadeNew.Models
{
    public class Company
    {
        [Key]
        public int CoyId { get; set; }
       
        public string CoyName { get; set; }
        [NotMapped]
        public List<SelectListItem> CompanyList { get; set; }
    }
}
