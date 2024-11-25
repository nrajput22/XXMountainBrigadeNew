using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XXMountainBrigadeNew.Models
{
    public class PersonnelViewModel
    {
        public int Id { get; set; }
        //public List<SelectListItem> PersonnelsList { get; set; }
        //[Required(ErrorMessage = "Perse is required.")]
        [Required]
        public int PersId { get; set; }

        [DisplayName("Coompany Name")]
        [Required]
        public int CoyId { get; set; }

        [DisplayName("Rank Name")]
        [Required]
        public int RankId { get; set; }

        [Required]
        [StringLength(20)]
        public string TypeOfPersonnel { get; set; }

        [Required]
        public int PersNo { get; set; }

        [Required]
        [StringLength(500)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(500)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(500)]
        public string PermanentAddress { get; set; }

        [NotMapped]
        public List<SelectListItem> Companies { get; set; }

        [NotMapped]
        public List<SelectListItem> Ranks { get; set; }
    }
}
