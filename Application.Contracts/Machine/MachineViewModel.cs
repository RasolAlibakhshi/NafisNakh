using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Machine
{
    public class MachineViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int HallID { get; set; }
        public bool IsRemove { get; set; }

        public MachineViewModel()
        {
            
        }

        public MachineViewModel(string name, int hallId)
        {
            Name = name;
            HallID = hallId;
        }
    }
}
