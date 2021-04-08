using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using MedicineTrackingSystem.Models;

namespace MedicineTrackingSystem.Controllers
{
    [ApiController]
    [Route("api/medicines/")]
    public class MedicinesController : ControllerBase
    {
        public IMedicineRepository _medicineRepository;
        public MedicinesController(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        [HttpGet]
        [Route("{name}")]
        public IActionResult Get(string name)
        {
            if (_medicineRepository.GetMedicine(name) == null)
                return NotFound("Medicine Not Found");

            return Ok(_medicineRepository.GetMedicine(name));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_medicineRepository.GetAllMedicines());
        }

        [HttpPost]
        public IActionResult Create(Medicine medicine)
        {
            Medicine newMedicine = _medicineRepository.Add(medicine);

            string baseUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            string uri = baseUri + "/" + newMedicine.Id;

            return Created(uri, medicine);
        }
    }
}
