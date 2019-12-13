using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExampleEntityLibrary
{
    public class معلم
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string الاسم { get; set; }
        public DateTime تاريخ_الميلاد { get; set; }
        public string الخبرة { get; set; }
    }
}
