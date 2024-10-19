using Application.Contracts.Interwoven;
using Domain;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presention.Areas.Admin.Pages
{
    public class EditeInterwovenModel : PageModel
    {
        private IInterwovenManagementApplicaion interwovens;
        private IRepository<Domain.Hall> halls;
        private IRepository<Domain.Machine> machines;

        public EditeInterwovenModel(IInterwovenManagementApplicaion interwovens, IRepository<Hall> halls, IRepository<Machine> machines)
        {
            this.interwovens = interwovens;
            this.halls = halls;
            this.machines = machines;
        }


        public string HallName_Form { get; set; }
        public string MachineName_Form { get; set; }

        public int MachineId { get; set; }
        public string? HallName { get; set; }
        public string? MachineName { get; set; }
        public string? Interwoven { get; set; }
        public string? TypeLabel { get; set; }
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
        public string? TypeOfPackaging { set; get; }
        public string? Description { set; get; }

        public List<SelectListItem> option = new List<SelectListItem>();

        public void OnGet(int id)
        {
            var EditeInterwoven = interwovens.GetById(id);
            var Machine = machines.GetBy(x => x.ID == EditeInterwoven.MachineId);
            var Hall = halls.GetBy(x => x.ID == Machine.HallID);

            HallName_Form =Hall.Name;
            MachineName_Form=Machine.Name;



            MachineId = id;
            HallName = EditeInterwoven.HallName;
            MachineName=EditeInterwoven.MachineName;
            Interwoven=EditeInterwoven.Interwoven;
            Description=EditeInterwoven.Description;
            TypeOfPackaging=EditeInterwoven.TypeOfPackaging;
            Emptyfield4=EditeInterwoven.Emptyfield4;
            Emptyfield3 = EditeInterwoven.Emptyfield3;
            Emptyfield2 = EditeInterwoven.Emptyfield2;
            Emptyfield1 = EditeInterwoven.Emptyfield1;
            Yarn_Type=EditeInterwoven.Yarn_Type;
            Warp_Direction = EditeInterwoven.Warp_Direction;
            Mingle = EditeInterwoven.Mingle;
            ColorCode=EditeInterwoven.ColorCode;
            Ply=EditeInterwoven.Ply;
            Den=EditeInterwoven.Den;
            Filament = EditeInterwoven.Filament;
            TypeLabel = EditeInterwoven.TypeLabel.ToString();


            option.Add(new SelectListItem("این فیلد آزمایشی است", "-1", true));
            option.Add(new SelectListItem("مصرفی", "0"));
            option.Add(new SelectListItem("داخلی", "1"));
            option.Add(new SelectListItem("صادراتی", "2"));



        }

        public IActionResult OnPost(InterwovenViewModel data)
        {
            interwovens.Update(data);
            return RedirectToPage("InterwovenManagement");
        }
    }
}
