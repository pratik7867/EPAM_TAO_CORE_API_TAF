using System;
using System.Data;
using System.IO;
using System.Reflection;
using ExcelDataReader;
using EPAM_TAO_CORE_UI_TAF.UI_Helpers;

namespace EPAM_TAO_CORE_API_TAF.APIHelpers
{
    public class DataHelper
    {
        private static readonly object syncLock = new object();

        public static DataTable ExcelToDataTable(string strFileName, string strSheetName)
        {
            try
            {
                lock(syncLock)
                {
                    FileStream fileStream = File.Open(strFileName, FileMode.Open, FileAccess.Read);

                    IExcelDataReader excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);

                    DataSet dataSetResult = excelDataReader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    DataTableCollection dataTableCollection = dataSetResult.Tables;

                    DataTable dataTableResult = dataTableCollection[strSheetName];

                    fileStream.Close();

                    return dataTableResult;
                }
            }
            catch(Exception ex)
            {
                ErrorLogger.errorLogger.ErrorLog(MethodBase.GetCurrentMethod().Name, ex);
                throw ex;
            }             
        }
    }
}
