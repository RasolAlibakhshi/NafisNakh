using Application.Contracts.OptionPackaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTO;
using Domain;

namespace Application.OptionPackaging
{
    public class OptionPackagingApplication: IOptionPackagingApplication
    {
        private IRepository<Domain.OptionPackaging> _repository;
        private IRepository<Domain.Hall> Hallrepository;

        public OptionPackagingApplication(IRepository<Domain.OptionPackaging> repository, IRepository<Domain.Hall> hallrepository)
        {
            _repository = repository;
            Hallrepository=hallrepository;
        }
        public IEnumerable<OptionPackagingViewModel> GetAll()
        {
            List<OptionPackagingViewModel> MyList= new List<OptionPackagingViewModel>();
            foreach (var Item in _repository.GetAll())
            {
               MyList.Add(new OptionPackagingViewModel{ID = Item.ID,HallID = Item.HallID,TypePackage = Item.TypePackage, IsDeleted = Item.IsDeleted}); 
            }
            return MyList;
        }

      

        public OptionPackagingViewModel GetById(int ID)
        {
            var data = _repository.GetBy(x => x.ID == ID);
            return new OptionPackagingViewModel { ID = data.ID, HallID = data.HallID, TypePackage = data.TypePackage,IsDeleted = data.IsDeleted};
        }

        public OptionPackagingViewModel Create(OptionPackagingViewModel model)
        {

            _repository.Create(new Domain.OptionPackaging {TypePackage = model.TypePackage,HallID = model.HallID,IsDeleted = model.IsDeleted});
            _repository.SaveChanges();
            return model;
        }

        public OptionPackagingViewModel Update(OptionPackagingViewModel model)
        {
            var data = _repository.GetBy(x => x.ID == model.ID);
            data.TypePackage = model.TypePackage;
            _repository.SaveChanges();
            return model;
        }

        public OptionPackagingViewModel Remove(OptionPackagingViewModel model)
        {
            var data = _repository.GetBy(x => x.ID == model.ID);
            data.IsDeleted = true;
            _repository.SaveChanges();
            return model;
        }

        public OptionPackagingViewModel Delete(OptionPackagingViewModel model)
        {
            var data = _repository.GetBy(x => x.ID == model.ID);
            _repository.Delete(data);
            _repository.SaveChanges();
            return model;
        }

        public OptionPackagingViewModel Restore(OptionPackagingViewModel model)
        {
            var data = _repository.GetBy(x => x.ID == model.ID);
            data.IsDeleted = false;
            _repository.SaveChanges();
            return model;
        }
    }
}
