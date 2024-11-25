using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XXMountainBrigadeNew.Models
{
    public class Rank
    {
        [Key]
        public int RankId { get; set; }
        
        public string RankName { get; set; }
        
        public string Seniority { get; set; }
        [NotMapped]
        public List<SelectListItem> SelectRank
        {
            get; set;
        }
    }
}
