using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineTrackingSystem.Models
{
    public class MedicineRepository : IMedicineRepository
    {
        private List<Medicine> _medicineList;

        public MedicineRepository()
        {
            _medicineList = new List<Medicine>()
        {
            new Medicine() { Id = 1, Name = "MedA", Brand = "Cipla", Price = 1.00 , Quantity = 1, ExpiryDate = DateTime.Today, Notes = "comments"},
            new Medicine() { Id = 2, Name = "MedB", Brand = "Ranbaxy", Price = 2.34 , Quantity = 1, ExpiryDate = DateTime.Today, Notes = "comments"},
            new Medicine() { Id = 3, Name = "MedC", Brand = "Fizer", Price = 3.44 , Quantity = 1, ExpiryDate = DateTime.Today, Notes = "comments"},
        };
        }
        public Medicine GetMedicine(string name)
        {
            return _medicineList.FirstOrDefault(x => x.Name.ToUpper() == name.ToUpper());
        }

        public IEnumerable<Medicine> GetAllMedicines()
        {
            return _medicineList;
        }

        public Medicine Add(Medicine employee)
        {
            employee.Id = _medicineList.Max(e => e.Id) + 1;
            _medicineList.Add(employee);
            return employee;
        }

        public Medicine Update(Medicine medicineChanges)
        {
            Medicine medicine = _medicineList.FirstOrDefault(med => med.Id == medicineChanges.Id);

            if (medicine != null)
            {
                medicine.Name = medicineChanges.Name;
                medicine.Price = medicineChanges.Price;
                medicine.Quantity = medicineChanges.Quantity;
                medicine.ExpiryDate = medicineChanges.ExpiryDate;
                medicine.Brand = medicineChanges.Brand;
            }

            return medicine;
        }

        public Medicine Delete(int id)
        {
            Medicine medicine = _medicineList.FirstOrDefault(med => med.Id == id);

            if (medicine != null)
            {
                _medicineList.Remove(medicine);
            }

            return medicine;
        }
    }
}

