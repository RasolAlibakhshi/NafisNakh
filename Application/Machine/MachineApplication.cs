using Application.Contracts.Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTO;
using Domain;

namespace Application.Machine
{
    public class MachineApplication: IMachineApplication
    {
        private IRepository<Domain.Machine> MachineRepository;
        private IRepository<Domain.Hall> HallRepository;

        public MachineApplication(IRepository<Domain.Machine> machineRepository, IRepository<Domain.Hall> hallRepository)
        {
            MachineRepository = machineRepository;
            HallRepository = hallRepository;
        }

        public IEnumerable<MachineViewModel> GetAll()
        {
            var data=MachineRepository.GetAll();
            List<MachineViewModel> MyList=new List<MachineViewModel>();
            foreach (var item in data)
            {
                MyList.Add(new MachineViewModel(){Name = item.Name,IsRemove = item.IsDeleted,ID = item.ID,HallID = item.HallID});
            }
            return MyList;
        }

        public IEnumerable<HallAndMachineViewmodel> HallAndMachine_Collection()
        {
            var MachineList = MachineRepository.GetAll().ToList();
            var HallList = HallRepository.GetAll().ToList();


            var data=MachineList.Join(HallList, machine => machine.HallID, hall => hall.ID,
                    (machine, hall) => new { machine, hall })
                .Select(x => new HallAndMachineViewmodel
                {
                    HallID = x.hall.ID,
                    MachineID = x.machine.ID,
                    HallName = x.hall.Name,
                    MachineName = x.machine.Name,
                    IsRemoveHall = x.hall.IsDeleted,
                    IsRemoveMachine = x.machine.IsDeleted
                    
                }).ToList();
           
            return data;
        }

        public MachineViewModel GetById(int ID)
        {
            var data = MachineRepository.GetBy(x => x.ID == ID);
            return new MachineViewModel() {ID = data.ID,Name = data.Name,IsRemove = data.IsDeleted,HallID = data.HallID};
        }

        public MachineViewModel Create(MachineViewModel model)
        {
            MachineRepository.Create(new Domain.Machine()
                { Name = model.Name, HallID = model.HallID, IsDeleted = model.IsRemove });
            MachineRepository.SaveChanges();
            return model;
        }

        public MachineViewModel Update(MachineViewModel model)
        {
            var data = MachineRepository.GetBy(x=>x.ID==model.ID);
            data.Name = model.Name;
            MachineRepository.SaveChanges();
            return model;
        }

        public MachineViewModel Remove(MachineViewModel model)
        {

            var data = MachineRepository.GetBy(x => x.ID == model.ID);
            data.IsDeleted = true;
            MachineRepository.SaveChanges();
            return model;
        }

        public MachineViewModel Delete(MachineViewModel model)
        {
            MachineRepository.DeleteByID(model.ID);
            
            MachineRepository.SaveChanges();
            return model;
        }

        public MachineViewModel Restore(MachineViewModel model)
        {
            var data = MachineRepository.GetBy(x => x.ID == model.ID);
            data.IsDeleted = false;
            MachineRepository.SaveChanges();
            return model;
        }
    }
}
