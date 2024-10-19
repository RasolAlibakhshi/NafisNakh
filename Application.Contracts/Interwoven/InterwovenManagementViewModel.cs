using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Interwoven
{
    public class InterwovenManagementViewModel
    {
        public string HallName { get; set; }
        public int HallID { get; set; }
        public bool HallVisible { get; set; }



        public string MachineName { get; set; }
        public bool MachineVisible { get; set; }
        public int MachineKey { get; set; }
        public int MachineID { get; set; }


        public int InterwovenID { get; set; }
        public string InterwovenName { get; set; }
        public int Interwovenkey { get; set; }
        public bool InterwovenVisible { get; set;}


        public InterwovenManagementViewModel()
        {
            
        }

    }
}
