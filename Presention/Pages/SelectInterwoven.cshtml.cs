using System.Globalization;
using Application.Contracts.Interwoven;
using Application.Contracts.Machine;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presention.PrintModel;


namespace Presention.Pages
{
    
    public class SelectInterwovenModel : PageModel
    {
        private IInterwovenManagementApplicaion Intervowen;
        private IMachineApplication _Machine;


        public SelectInterwovenModel(IInterwovenManagementApplicaion intervowen, IMachineApplication machine)
        {
            Intervowen = intervowen;
            _Machine = machine;
        }

        public List<InterwovenViewModel> interwovenModels;
        public void OnGet(int id)
        {
            interwovenModels = Intervowen.GetAll_Interwoven().Where(x => x.MachineId == id).ToList();
        }

        public IActionResult OnGetModalLabel(int id)
        {
            var data = Intervowen.GetById(id);
            System.Globalization.PersianCalendar date = new PersianCalendar();
            string shamsi =
                $"{date.GetYear(DateTime.Now).ToString()}/{date.GetMonth(DateTime.Now).ToString("0#")}/{date.GetDayOfMonth(DateTime.Now).ToString()}";
            var printModelOutput = new PrintModelOutput(data.Interwoven, data.Filament, data.Den, data.Ply, data.Mingle, _Machine.GetById(data.MachineId).Name, shamsi);
            return Partial("_Print", printModelOutput);
        }
    }
}
