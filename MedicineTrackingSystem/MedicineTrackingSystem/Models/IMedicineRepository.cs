using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineTrackingSystem.Models
{
    public interface IMedicineRepository
    {
        Medicine GetMedicine(string name);
        IEnumerable<Medicine> GetAllMedicines();
        Medicine Add(Medicine medicine);
        Medicine Update(Medicine medicineChanges);
        Medicine Delete(int id);
    }
}
