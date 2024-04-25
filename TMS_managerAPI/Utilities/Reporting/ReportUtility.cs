using Ganss.Excel;
using Newtonsoft.Json;
using OfficeOpenXml;
using SharedData.Models;

namespace TMS_managerAPI.Utilities.Reporting
{
    public class ReportUtility
    {
       
        public static void GenererateExcelfromList(List<Assignment> data)
        {
            ExcelMapper excelMapper = new ExcelMapper();
            string filename = $"Report_{DateTime.Now:yyyyMMddHHmmss}.xlsx";
            excelMapper.Save($"C:\\Users\\chris\\source\\repos\\TMS_managerAPI\\TMS_managerAPI\\Reports\\{filename}", data);
        }

    }
}
