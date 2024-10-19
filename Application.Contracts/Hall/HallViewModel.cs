using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Hall
{
    public class HallViewModel
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public bool IsRemove { get; set; }

        public HallViewModel()
        {
            
        }

        public HallViewModel(String Name)
        {
            this.Name = Name;
        }

    }
}
