using Application.Contracts.Hall;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Areas.Admin.Pages
{
    public class EditeHallModel : PageModel
    {
        private IHallApplication Hall;
        public HallViewModel data;
        public EditeHallModel(IHallApplication hall)
        {
            Hall = hall;
        }

        public string Name;
        public int ID;
        public void OnGet(int id)
        {
            data = Hall.GetById(id);
            Name=data.Name;
            ID = data.ID;
        }

        public IActionResult OnPost(HallViewModel Model)
        {
            if (ModelState.IsValid)
            {
                Hall.Update(Model);
            }
            

            return RedirectToPage("HallManegment");
        }
    }
}
