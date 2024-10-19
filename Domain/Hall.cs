using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Hall:Base
    {
        [Required]
        public string Name { get; set; }
        public Hall(){}
        public Hall(string name)
        {
            Name = name;
            IsDeleted = false;
            CreaationDateTime= DateTime.Now;
        }
        public virtual ICollection<Machine> Machines { get; set; }
        public virtual ICollection<LabelType> LabelTypes { get; set; }
        public virtual ICollection<OptionPackaging> OptionPackaging { get; set; }

    }
}
