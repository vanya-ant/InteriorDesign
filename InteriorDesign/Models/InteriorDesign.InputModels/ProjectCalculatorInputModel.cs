using InteriorDesign.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.InteriorDesign.InputModels
{
    public class ProjectCalculatorInputModel
    {
        public string Property { get; set; }

        public string Project { get; set; }

        public int NumberOfBedrooms { get; set; }

        public decimal NumberOfBathrooms { get; set; }

        public decimal HousingArea { get; set; }
    }
}
