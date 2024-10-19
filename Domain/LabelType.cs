using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class LabelType:Base
    {
        public string Name { get; set; }
        public int hallID { get; set; }
        [ForeignKey(nameof(hallID))]
        public virtual Hall HallProp { get; set; }
        public LabelType(){}

        public LabelType(string name, int hallId)
        {
            Name = name;
            hallID = hallId;
            CreaationDateTime = DateTime.Now;
            IsDeleted = false;
        }
    }
}
