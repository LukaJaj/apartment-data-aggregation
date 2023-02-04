using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace data_aggregation
{
	public class ApartmentAggregated
	{
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Network { get; set; }

        [Column("p_plus", TypeName = "numeric")]
        public decimal PPlusSum { get; set; }

        [Column("p_minus", TypeName = "numeric")]
        public decimal PMinusSum { get; set; }
    }
}

