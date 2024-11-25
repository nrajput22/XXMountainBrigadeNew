using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XXMountainBrigadeNew.Models;

namespace XXMountainBrigadeNew.MBRepository
{
    public class PersonnelRepository : IPersonnel
    {
        private readonly MBDbContext personnelDB;

        public PersonnelRepository(MBDbContext personnelDB)
        {
            this.personnelDB = personnelDB;
        }

        public async Task addPesonnelAsync(Personnel personnel)
        {
            if (personnel == null)
            {
                throw new ArgumentNullException(nameof(personnel), "Personnel cannot be null");
            }

            await personnelDB.Personnels.AddAsync(personnel);

            await personnelDB.SaveChangesAsync();

        }

        public async Task<List<Personnel>> getAllPersonnelAsync()
        {
            var allPersonnel = await personnelDB.Personnels.ToListAsync();
            return allPersonnel;
        }

        public async Task<List<Personnel>> getPersonnelByNameAsync(string firstName)
        {
            var searchPersonnels = await personnelDB.Personnels.Where(x => x.FirstName == firstName).ToListAsync();
            return searchPersonnels;
        }

        public async  Task<Personnel> persDeleteConfirmedAsync(int id)
        {
            var perDataDelete = await personnelDB.Personnels.FindAsync(id);
            personnelDB.Personnels.Remove(perDataDelete);
            await personnelDB.SaveChangesAsync();
            return perDataDelete;
        } 

        public async  Task<Personnel> getPersonnelByIdAsync(int id)
        {
            var perDelete = await personnelDB.Personnels.FirstOrDefaultAsync(x => x.Id == id);
            return perDelete;
        }

        public async Task<Personnel> updateEditPersonnelAsync(Personnel personnel)
        {
            if (personnel == null)
            {
                throw new ArgumentNullException(nameof(personnel), "Personnel cannot be null");
            }
            //var updtPersonnel = await personnelDB.Personnels.ExecuteUpdateAsync(personnel);
            //personnelDB.SaveChanges();
            //return personnel;
            var existingPersonnel = await personnelDB.Personnels.FindAsync(personnel.Id);

            if (existingPersonnel == null)
            {
                throw new KeyNotFoundException($"Personnel with ID {personnel.Id} not found");
                //return null;
            }

            // Update the properties of the existing entity
            existingPersonnel.PersId = personnel.PersId;
            existingPersonnel.TypeOfPersonnel = personnel.TypeOfPersonnel;
            existingPersonnel.PersNo = personnel.PersNo;
            existingPersonnel.FirstName = personnel.FirstName;
            existingPersonnel.LastName = personnel.LastName;
            existingPersonnel.DateOfBirth = personnel.DateOfBirth;
            existingPersonnel.PermanentAddress = personnel.PermanentAddress;
            existingPersonnel.CoyName = personnel.CoyName;  // Assuming CoyName is a property of Personnel
            existingPersonnel.RankName = personnel.RankName;  // Assuming RankName is a property of Personnel

            await personnelDB.SaveChangesAsync();

            return existingPersonnel;
        }
    }
}
