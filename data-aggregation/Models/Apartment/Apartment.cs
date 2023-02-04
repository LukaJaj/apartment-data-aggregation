using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace data_aggregation
{
	public class Apartment
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        [Column("network", TypeName = "varchar(256)")]
        public string Network { get; set; }

        [Required]
        [Column("obt_name", TypeName = "varchar(256)")]
        public string ObtName { get; set; }


        [Required]
        [Column("obj_gv_type", TypeName = "varchar(256)")]
        public string ObjGvType { get; set; }

        [Required]
        [Column("obj_number", TypeName = "varchar(256)")]
        public string ObjNumber { get; set; }

        [Column("p_plus", TypeName = "decimal")]
        [Precision(6, 2)]

        public decimal PPlus { get; set; }

        [Required]
        [Column("pl_time", TypeName = "text")] 
        public string PlTime { get; set; }

        [Column("p_minus", TypeName = "decimal")]
        [Precision(6, 2)]
        public decimal PMinus { get; set; }
    }
}

