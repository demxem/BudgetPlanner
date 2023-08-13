using DAL.DbAccess;
using DAL.Models;

namespace DAL.Data;

public class PieChart : IPieChart
{
    private readonly IPgsqlAccess _dataAccess;

    public PieChart(IPgsqlAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<IEnumerable<PieChartModel>> GetPieChartIncome()
    {
        string sql = @"select id, employment, sidehustle, dividends, date, monthid, yearid
                       from income
                       order by date asc;";

        List<PieChartModel> Pie = new List<PieChartModel>();
        IEnumerable<IncomeModel> Income = await _dataAccess.LoadData<IncomeModel, dynamic>(sql, new { });

        foreach (var item in Income)
        {
            foreach (var property in item.GetType().GetProperties())
            {
                string propertyName = property.Name;
                if (propertyName.Equals("Employment") || propertyName.Equals("SideHustle") || propertyName.Equals("Dividends"))
                {
                    decimal propertyValue = (decimal)property.GetValue(item, null)!;
                    Pie.Add(new PieChartModel { Name = propertyName, Value = propertyValue });
                }
            }
        }
        return Pie;
    }
}