
using Application.Contracts.Interwoven;
using Domain;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presention.Areas.Admin.Pages
{
    public class AddInterwovenModel : PageModel
    {
        private IInterwovenManagementApplicaion applicaion;
        private IRepository<Domain.Hall> halls;
        private IRepository<Domain.Machine> machines;

        public AddInterwovenModel(IRepository<Hall> halls, IRepository<Machine> machines, IInterwovenManagementApplicaion applicaion)
        {
            this.halls = halls;
            this.machines = machines;
            this.applicaion=applicaion;
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


        public List<SelectListItem> option=new List<SelectListItem>();

        public void OnGet(int id)
        {
            var data=machines.GetBy(x => x.ID == id);
            MachineName_Form = data.Name;
            HallName_Form=halls.GetBy(x=>x.ID==data.HallID).Name;
            MachineId = id;
            option.Add(new SelectListItem("این فیلد آزمایشی است", "-1",true));
            option.Add(new SelectListItem("مصرفی", "0"));
            option.Add(new SelectListItem("داخلی","1"));
            option.Add(new SelectListItem("صادراتی", "2"));


        }

        public IActionResult OnPost(InterwovenViewModel data)
        {
            
            if (ModelState.IsValid)
            {
                applicaion.Create(data);
                TempData["AddInterwovenSuccess"] = "ثبت همبافت با موفقیت انجام شد";
            }
                
            
            
            return RedirectToPage("InterwovenManagement");
        }
    }
}
