using SharedData.Result;
using System;
using System.Data;

namespace TMS_managerAPI.Utilities
{
    public static class Mappers
    {
        public static AverageTurnAroundTimePerHaulierResult MapToAverageTurnAroundTimePerHaulierResult(IDataRecord record)
        {
            return new AverageTurnAroundTimePerHaulierResult
            {
                HaulierId = Convert.ToInt32(record["HaulierId"]),
                AverageTurnAroundTime = Convert.ToDouble(record["AverageTurnAroundTime"])
            };
        }

        public static AverageTurnAroundTimePerDriverResult MapToAverageTurnAroundTimePerDriverResult(IDataRecord record)
        {
            return new AverageTurnAroundTimePerDriverResult
            {
                DriverId = Convert.ToInt32(record["DriverId"]),
                AverageTurnAroundTime = Convert.ToDouble(record["AverageTurnAroundTime"])
            };
        }

        public static TonnagePerTruckPerDayResult MapToTonnagePerTruckPerDayResult(IDataRecord record)
        {
            return new TonnagePerTruckPerDayResult
            {
                TruckId = Convert.ToInt32(record["TruckId"]),
                Date = Convert.ToDateTime(record["Date"]),
                Tonnage = Convert.ToDecimal(record["Tonnage"])
            };
        }
    }
}