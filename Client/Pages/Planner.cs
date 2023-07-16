using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Pages
{

    public class Planner
    {
        public IEnumerable<MonthModel> Income;
        public IEnumerable<MonthModel> Savings;
        public IEnumerable<MonthModel> Expenses;
        private float montlhlyIncome;
        private float monthlySavings;
        private float monthlyExpenses;

        public float CalculateYearlyUndistributedIncome()
        {
            var totalIncome = CalculateYearlyIncome();
            var totalSavings = CalculateYearlySavings();
            var totalExpenses = CalculateYearlyExpenses();
            var undistributedIncome = totalIncome - (totalSavings + totalExpenses);
            return undistributedIncome;
        }

        public float CalculateMonthlyUndistributedIncome()
        {
            var undistributedMonthlyIncome = montlhlyIncome - (monthlySavings + monthlyExpenses);
            return undistributedMonthlyIncome;
        }

        public float CalculateMonthlyIncome(MonthModel selectedData, int activeTabNumber)
        {
            if (activeTabNumber == 0)
            {
                if (selectedData == null) return 0;
                montlhlyIncome = Income.Where(income => income.Equals(selectedData)).Select(income => income.MonthlyIncome).FirstOrDefault(0);
                return montlhlyIncome;
            }

            if (activeTabNumber == 1)
            {
                if (selectedData == null) return 0;
                montlhlyIncome = Income.Where(income => income.Name.Equals(selectedData.Name)).Select(income => income.MonthlyIncome).FirstOrDefault(0);
                return montlhlyIncome;
            }
            else
            {
                if (selectedData == null) return 0;
                montlhlyIncome = Income.Where(income => income.Name.Equals(selectedData.Name)).Select(income => income.MonthlyIncome).FirstOrDefault(0);
                return montlhlyIncome;
            }
        }

        public float CalculateMonthlySavings(MonthModel selectedData, int activeTabNumber)
        {
            if (activeTabNumber == 0)
            {
                monthlySavings = Savings.Where(savings => savings.Name.Equals(selectedData.Name)).Select(savings => savings.MonthlySavings).FirstOrDefault(0);
                return monthlySavings;
            }

            if (activeTabNumber == 1)
            {
                monthlySavings = Savings.Where(savings => savings.Equals(selectedData)).Select(savings => savings.MonthlySavings).FirstOrDefault(0);
                return monthlySavings;
            }

            monthlySavings = Savings.Where(savings => savings.Name.Equals(selectedData.Name)).Select(savings => savings.MonthlySavings).FirstOrDefault(0);
            return monthlySavings;
        }

        public float CalculateMonthlyExpenses(MonthModel selectedData, int activeTabNumber)
        {
            if (activeTabNumber == 0)
            {
                monthlyExpenses = Expenses.Where(expenses => expenses.Name.Equals(selectedData.Name)).Select(expenses => expenses.MonthlyExpenses).FirstOrDefault(0);
                return monthlyExpenses;
            }

            if (activeTabNumber == 1)
            {
                monthlyExpenses = Expenses.Where(expenses => expenses.Name.Equals(selectedData.Name)).Select(expenses => expenses.MonthlyExpenses).FirstOrDefault(0);
                return monthlyExpenses;
            }

            monthlyExpenses = Expenses.Where(expenses => expenses.Equals(selectedData)).Select(expenses => expenses.MonthlyExpenses).FirstOrDefault(0);
            return monthlyExpenses;
        }

        public float CalculateYearlyIncome()
        {
            return Income.Select(income => income.MonthlyIncome).Sum();
        }

        public float CalculateYearlySavings()
        {
            return Savings.Select(savings => savings.MonthlySavings).Sum();
        }

        public float CalculateYearlyExpenses()
        {
            return Expenses.Select(expenses => expenses.MonthlyExpenses).Sum();
        }


    }
}