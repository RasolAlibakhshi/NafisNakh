using Application.Contracts.Hall;
using Domain;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Hall
{
    public class HallApplication : IHallApplication
    {
        private IRepository<Domain.Hall> _Context;

        public HallApplication(IRepository<Domain.Hall> Context)
        {
            _Context = Context;
        }

        public HallViewModel Create(HallViewModel model)
        {

            _Context.Create(new Domain.Hall(model.Name));
           _Context.SaveChanges();
            return model;
        }

        public HallViewModel Delete(HallViewModel model)
        {
            var data =_Context.GetBy(x => x.Name==model.Name);
            _Context.Delete(data);
            _Context.SaveChanges();
            return model;
        }

        public IEnumerable<HallViewModel> GetAll()
        {
            List<HallViewModel> data= new List<HallViewModel>();
            foreach(var item in _Context.GetAll()) 
            {
                data.Add(new HallViewModel(item.Name) { ID=item.ID,IsRemove=item.IsDeleted  });
            }
            return data;
            
        }

        public HallViewModel GetById(int ID)
        {
            var data = _Context.GetBy(x => x.ID==ID);
            return new HallViewModel(data.Name) { ID= data.ID };
        }

        public HallViewModel Remove(HallViewModel model)
        {
            var data = _Context.GetBy(x => x.Name==model.Name);
            data.IsDeleted = true;
            _Context.SaveChanges();
            return model;
        }

        public HallViewModel Restore(HallViewModel model)
        {
            var data = _Context.GetBy(x => x.Name==model.Name);
            data.IsDeleted = false;
            _Context.SaveChanges();
            return model;

        }

        public HallViewModel Update(HallViewModel model)
        {
            var data = _Context.GetBy(x => x.ID == model.ID);
            data.Name = model.Name;
            _Context.Update(data);
            _Context.SaveChanges();
            return model;
            
        }
    }
}
