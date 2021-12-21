using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmacy2.Models
{
    public enum Sort
    {
        NameAsc,    // по имени по возрастанию
        NameDesc,   // по имени по убыванию
        AdressAsc, // по адрессу по возрастанию
        AdressDesc,    // по адрессу по убыванию
        DrugAsc, // по лекарствам по возрастанию
        DrugDesc, // по лекарствам по убыванию
        Phone_NumberAsc, // по номеру телефонов по убыванию
        Phone_NumberDesc // по номеру телефонов по убыванию
    }
}
