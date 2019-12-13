using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExampleEntityLibrary
{
    public class School
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(40)]
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }
    }
}
