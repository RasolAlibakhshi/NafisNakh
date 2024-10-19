using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class OptionPackaging:Base
    {
        public string TypePackage { get; set; }
        public int HallID { get; set; }
        [ForeignKey(nameof(HallID))]
        public virtual Hall HallProp { get; set; }

        public OptionPackaging()
        {
            IsDeleted=false;
            CreaationDateTime=DateTime.Now;
        }

        public OptionPackaging(string typePackage, int hallId)
        {
            TypePackage = typePackage;
            HallID = hallId;
           
        }
    }
}
