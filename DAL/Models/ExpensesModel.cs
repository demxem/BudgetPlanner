using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models;

public class ExpensesModel
{
    public int Id { get; set; }
    public float Housing { get; set; }
    public float Groceries { get; set; }
    public float Utilities { get; set; }
    public float Vacation { get; set; }
    public float Transportation { get; set; }
    public float Medicine { get; set; }
    public float Clothing { get; set; }
    public float Media { get; set; }
    public float Insuranses { get; set; }
    public float TrackedHousing { get; set; }
    public float TrackedGroceries { get; set; }
    public float TrackedUtilities { get; set; }
    public float TrackedVacation { get; set; }
    public float TrackedTransportation { get; set; }
    public float TrackedMedicine { get; set; }
    public float TrackedClothing { get; set; }
    public float TrackedMedia { get; set; }
    public float TrackedInsuranses { get; set; }
    public DateTime Date { get; set; }
    public int MonthId { get; set; }
    public int YearId { get; set; }
}

