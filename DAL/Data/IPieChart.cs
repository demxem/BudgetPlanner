using DAL.Models;

namespace DAL.Data
{
    public interface IPieChart
    {
        Task<IEnumerable<PieChartModel>> GetPieChartIncome();
    }
}