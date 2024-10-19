using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.OptionPackaging
{
    public class OptionPackagingViewModel
    {
        public int ID { get; set; }
        public int HallID { get; set; }
        public string TypePackage { get; set; }
        public bool IsDeleted { get; set; }

        public OptionPackagingViewModel()
        {
            
        }

        public OptionPackagingViewModel(int hallId, string typePackage)
        {
            HallID = hallId;
            TypePackage = typePackage;
        }
    }
}
