using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models;

public class ExpensesModel
{
    public int ExpensesId { get; set; }
    public float Housing { get; set; }
    public float Groceries { get; set; }
    public float Utilities { get; set; }
    public float Vacation { get; set; }
    public float Transportation { get; set; }
    public float Medicine { get; set; }
    public float Clothing { get; set; }
    public float Media { get; set; }
    public float Insuranses { get; set; }
}

