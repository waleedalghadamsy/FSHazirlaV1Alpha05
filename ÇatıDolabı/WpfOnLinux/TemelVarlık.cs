using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WpfOnLinux
{
    public class TemelVarlık
    {
        public TemelVarlık()
        {
            //SistemDurum = VarlıkSistemDurum.Aktif;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public byte SistemDurum { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Oluşturulduğunda { get; set; }
        public int OluşturuKimsiId { get; set; }
    }
}
