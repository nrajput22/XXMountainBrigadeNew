using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XXMountainBrigadeNew.Models
{
    public class Personnel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PersId { get; set; }

        [Required]
        [ForeignKey("CoyId")]
        public virtual Company Companies { get; set; }

        [Required]
        [ForeignKey("RankId")]
        public virtual Rank Ranks { get; set; }

        [Required]
        [StringLength(20)]
        public string TypeOfPersonnel { get; set; }

        [Required]
        [Column("PersonnelNumber")]
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

        [DisplayName("Coy Name")]
        [Required]
        public string CoyName { get; set; }

        [DisplayName("Rank Name")]
        [Required]
        public string RankName { get; set; }
    }
}
