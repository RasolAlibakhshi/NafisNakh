using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class label:Base
    {
        [Required]
        public string Interwoven { set; get; }

        public label()
        {
            
        }

        public label(string interwoven,int machineId)
        {
            Interwoven = interwoven;
            IsDeleted=false;
            CreaationDateTime= DateTime.Now;
            MachineID= machineId;
        }

        public int MachineID { set; get; }
        [ForeignKey(nameof(MachineID))]
        public virtual Machine MachineProp { set; get; }

        public int Type_Label { set; get; }
        public string? Filament { set; get; }
        public string? Den { set; get; }
        public string? Ply { set; get; }
        public string? ColorCode { set; get; }
        public string? Mingle { set; get; }
        public string? Warp_Direction { set; get; }
        public string? Yarn_Type { set; get; }
        public string? Emptyfield1 { set; get; }
        public string? Emptyfield2 { set; get; }
        public string? Emptyfield3 { set; get; }
        public string? Emptyfield4 { set; get; }
        public string TypeOfPackaging { set; get; }
        public string? Description { set; get; }

    }

    

    
    
}
