using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Interwoven
{
    public class InterwovenViewModel
    {
        public InterwovenViewModel()
        {
            
        }

        public InterwovenViewModel(int id,int machineId, string interwoven, string typeLabel, string? filament, string? den, string? ply, string? colorCode, string? mingle, string? warpDirection, string? yarnType, string? emptyfield1, string? emptyfield2, string? emptyfield3, string? emptyfield4, string typeOfPackaging, string? description)
        {
            ID=id;
            MachineId = machineId;
            Interwoven = interwoven;
            TypeLabel = int.Parse(typeLabel);
            Filament = filament;
            Den = den;
            Ply = ply;
            ColorCode = colorCode;
            Mingle = mingle;
            Warp_Direction = warpDirection;
            Yarn_Type = yarnType;
            Emptyfield1 = emptyfield1;
            Emptyfield2 = emptyfield2;
            Emptyfield3 = emptyfield3;
            Emptyfield4 = emptyfield4;
            TypeOfPackaging = typeOfPackaging;
            Description = description;
        }
        public int ID { get; set; }
        public int MachineId { get; set; }
        public string HallName { get; set; }
        public string MachineName { get; set; }
        public string Interwoven { get; set; }
        public int TypeLabel { get; set; }
        
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
