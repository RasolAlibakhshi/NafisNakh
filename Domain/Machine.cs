using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Machine:Base
    {
        [Required]
        public string Name { get; set; }

        public Machine()
        {
            
        }

        public Machine(string name,int hallID)
        {
            Name = name;
            CreaationDateTime= DateTime.Now;
            IsDeleted=false;
            HallID=hallID;
        
        }
        public int HallID { get; set; }
        [ForeignKey(nameof(HallID))]
        public virtual Hall HallProp { get; set; }


        public virtual ICollection<label> Labels { get; set; }
    }
}
