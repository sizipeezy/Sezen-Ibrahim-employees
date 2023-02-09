namespace SirmaSolutionTask.Repository
{
    using SirmaSolutionTask.Models;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;


    public interface EmployeerepositoryInterface
    {
        void save(DatabaseRecord record);

        void saveAll(Collection<DatabaseRecord> records);

        List<DatabaseRecord> getAllRecords();
    }
}
