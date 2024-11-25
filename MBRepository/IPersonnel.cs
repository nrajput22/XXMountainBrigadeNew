using System.Collections.Generic;
using System.Threading.Tasks;
using XXMountainBrigadeNew.Models;

namespace XXMountainBrigadeNew.MBRepository
{
    public interface IPersonnel
    {
        Task<List<Personnel>> getAllPersonnelAsync();
        Task <List<Personnel>> getPersonnelByNameAsync(string firstName);
        Task addPesonnelAsync(Personnel personnel);
        Task< Personnel> getPersonnelByIdAsync(int id);
        Task<Personnel> updateEditPersonnelAsync(Personnel personnel);
        Task<Personnel> persDeleteConfirmedAsync(int id);
    }
}
