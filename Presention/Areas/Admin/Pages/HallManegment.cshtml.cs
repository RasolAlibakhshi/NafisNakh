using Application.Contracts.Hall;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Presention.Areas.Admin.Pages
{
    public class HallManegmentModel : PageModel
    {
        private IHallApplication Hall;
        public IEnumerable<HallViewModel> data;
        public string Name { get; set; }
        public int ID { get; set; }
        public bool IsRemove { get; set; }
        public HallManegmentModel(IHallApplication hall)
        {
            Hall = hall;
        }
        public void OnGet(int id)
        {
            data = Hall.GetAll();
            ID = id;
        }

        public IActionResult OnPost(HallViewModel model)
        {
            if (ModelState.IsValid)
            {
                Hall.Create(model);

            }
            return RedirectToPage("HallManegment");

        }

        // public IActionResult OnPostRemove(int id)
        // {
        //     Hall.Remove(Hall.GetById(id)); 
        //     return RedirectToPage("HallManegment");
        // }

        public IActionResult OnGetRemove(int id)
        {
            if (ModelState.IsValid)
            {
                Hall.Remove(Hall.GetById(id));
            }
            
            return RedirectToPage("HallManegment");
        }

        // public IActionResult OnPostRestore(int id)
        // {
        //     Hall.Restore(Hall.GetById(id));
        //     return RedirectToPage("HallManegment");
        // }

        public IActionResult OnGetRestore(int id)
        {
            if (ModelState.IsValid)
            {
                Hall.Restore(Hall.GetById(id));
            }
           
            return RedirectToPage("HallManegment");

        }

        // public IActionResult OnPostDelete(int id)
        // {
        //     Hall.Delete(Hall.GetById(id));
        //
        //     return RedirectToPage("HallManegment");
        // }

        public IActionResult OnGetDelete(int id)
        {
            if (ModelState.IsValid)
            {
                Hall.Delete(Hall.GetById(id));
            }
            

            return RedirectToPage("HallManegment");
        }
    }
}
