using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pharmacy2.Models
{
    public class Filter
    {
        public Filter(List<Drug> drugs, int? drug, string name)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            drugs.Insert(0, new Drug { Name = "Все", Id = 0 });
            Drugs = new SelectList(drugs, "Id", "Name", drug);
            SelectedDrug = drug;
            SelectedName = name;

        }
        public SelectList Drugs { get; private set; } // список лекартсв
        public int? SelectedDrug { get; private set; }   // выбранное лекартсво
        public string SelectedName { get; private set; }    // введенное имя
    }
}
