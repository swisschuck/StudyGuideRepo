using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using CsvHelper;

namespace StudyGuide.Classes.Examples.SQLBulkCopy
{
    public class SQLBulkCopyTest
    {
        #region fields

        private SqlConnectionStringBuilder _sandboxDB;

        #endregion fields


        #region properties
        #endregion properties


        #region constructors

        public SQLBulkCopyTest()
        {
            _sandboxDB = new SqlConnectionStringBuilder()
            {
                DataSource = @"CHARLIESHPENVY\CHARLIESQL2017",
                InitialCatalog = "SandBox",
                IntegratedSecurity = true,
                TrustServerCertificate = true
            };
        }

        #endregion constructors


        #region public methods

        public bool TestSQLConnection()
        {
            using (SqlConnection connection = new SqlConnection(_sandboxDB.ConnectionString))
            {
                try
                {
                    connection.Open();

                    //if (connection.State == ConnectionState.Open)
                    //{

                    //}
                    //else
                    //{

                    //}
                    return true;
                }
                catch (SqlException sqlEx)
                {
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }


        public bool PerformBasicBulkCopy()
        {
            bool statusToReturn = true;

            try
            {
                DataTable tempDataTable = new DataTable();
                tempDataTable.Columns.Add("EmployeeID");
                tempDataTable.Columns.Add("Name");

                for (int index = 1; index < 1000000; index++)
                {
                    tempDataTable.Rows.Add(index + 1, "Name " + index + 1);

                }

                using (SqlBulkCopy sqlBulk = new SqlBulkCopy(_sandboxDB.ConnectionString))
                {
                    sqlBulk.DestinationTableName = "EmployeesTestTable";
                    sqlBulk.WriteToServer(tempDataTable);
                }

                statusToReturn = true;
            }
            catch (Exception ex)
            {
                statusToReturn = false;
            }

            return statusToReturn;
        }


        public bool PerformBasicBulkCopyWithIdentity()
        {
            bool statusToReturn = true;

            try
            {
                DataTable tempDataTable = new DataTable();
                tempDataTable.Columns.Add("EmployeeID");
                tempDataTable.Columns.Add("Name");

                for (int index = 1; index < 1000000; index++)
                {
                    tempDataTable.Rows.Add(index + 1, "Name " + index + 1);

                }

                // if you need to use the identity values in the source you need to use the KeepIdentity option when instantiating your SqlBulkCopy.
                using (SqlBulkCopy sqlBulk = new SqlBulkCopy(_sandboxDB.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
                {
                    sqlBulk.DestinationTableName = "EmployeesTestTableIdentity";
                    sqlBulk.WriteToServer(tempDataTable);
                }

                statusToReturn = true;
            }
            catch (Exception ex)
            {
                statusToReturn = false;
            }

            return statusToReturn;
        }


        public bool PerformBulkCopyWithTransaction()
        {
            bool statusToReturn = true;

            DataTable tempDataTable = new DataTable();
            tempDataTable.Columns.Add("EmployeeID");
            tempDataTable.Columns.Add("Name");

            for (int index = 1; index < 1000000; index++)
            {
                tempDataTable.Rows.Add(index + 1, "Name " + index + 1);

            }

            using (SqlConnection connection = new SqlConnection(_sandboxDB.ConnectionString))
            {
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction();

                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepIdentity, transaction))
                {
                    sqlBulkCopy.DestinationTableName = "EmployeesTransactionTest";

                    try
                    {
                        sqlBulkCopy.WriteToServer(tempDataTable);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        statusToReturn = false;
                    }

                }
            }

            statusToReturn = true;


            return statusToReturn;
        }



        public bool PerformBulkCopyWithBatchSizes()
        {
            bool statusToReturn = true;

            DataTable tempDataTable = new DataTable();
            tempDataTable.Columns.Add("EmployeeID");
            tempDataTable.Columns.Add("Name");

            for (int index = 1; index < 1000000; index++)
            {
                tempDataTable.Rows.Add(index + 1, "Name " + index + 1);

            }

            Console.WriteLine($"Temp table created, it contains {tempDataTable.Rows.Count} records to insert.");

            using (SqlConnection connection = new SqlConnection(_sandboxDB.ConnectionString))
            {
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction();

                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepIdentity, transaction))
                {
                    sqlBulkCopy.DestinationTableName = "EmployeesBatchTest";
                    sqlBulkCopy.BatchSize = 1000; // writing 1000 records at a time to SQL
                    Console.WriteLine($"Batch Size Set To: {sqlBulkCopy.BatchSize}");

                    try
                    {

                        sqlBulkCopy.WriteToServer(tempDataTable);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        statusToReturn = false;
                    }

                }
            }

            statusToReturn = true;


            return statusToReturn;
        }



        public bool PerformBulkCopyWithNotifications()
        {
            bool statusToReturn = true;

            DataTable tempDataTable = new DataTable();
            tempDataTable.Columns.Add("EmployeeID");
            tempDataTable.Columns.Add("Name");

            for (int index = 1; index < 1000000; index++)
            {
                tempDataTable.Rows.Add(index + 1, "Name " + index + 1);

            }

            Console.WriteLine($"Temp table created, it contains {tempDataTable.Rows.Count} records to insert.");

            using (SqlConnection connection = new SqlConnection(_sandboxDB.ConnectionString))
            {
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction();

                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepIdentity, transaction))
                {
                    try
                    {
                        sqlBulkCopy.DestinationTableName = "EmployeesNotificationsTest";

                        // this is just a short cut way to 
                        //sqlBulkCopy.SqlRowsCopied += (sender, eventArgs) => Console.WriteLine("Wrote " + eventArgs.RowsCopied + " records.");
                        sqlBulkCopy.SqlRowsCopied += new SqlRowsCopiedEventHandler(OnSqlRowsCopied);
                        sqlBulkCopy.NotifyAfter = 1000; // set to tell us when 1000 records has been inserted

                        sqlBulkCopy.WriteToServer(tempDataTable);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        statusToReturn = false;
                    }

                }
            }

            statusToReturn = true;


            return statusToReturn;
        }


        public bool PerformBulkCopyWithColumnMappings()
        {
            bool statusToReturn = true;


            DataTable tempDataTable = new DataTable();
            tempDataTable.Columns.Add("SourceEmployeeID");
            tempDataTable.Columns.Add("SourceEmployeeName");

            for (int index = 1; index < 1000000; index++)
            {
                tempDataTable.Rows.Add(index + 1, "Name " + index + 1);

            }

            using (SqlConnection connection = new SqlConnection(_sandboxDB.ConnectionString))
            {
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction();

                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepIdentity, transaction))
                {
                    // if our source has different column names than whats in the database, we can map those columns 
                    sqlBulkCopy.ColumnMappings.Add("SourceEmployeeID", "EmployeeID");
                    sqlBulkCopy.ColumnMappings.Add("SourceEmployeeName", "Name");
                    sqlBulkCopy.DestinationTableName = "EmployeesColumnMappingTest";

                    try
                    {
                        sqlBulkCopy.WriteToServer(tempDataTable);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        statusToReturn = false;
                    }

                }
            }

            statusToReturn = true;


            return statusToReturn;
        }


        public bool PerformBulkCopyMultipleTables()
        {
            bool statusToReturn = true;


            DataTable tempEmployeesDataTable = new DataTable();
            tempEmployeesDataTable.Columns.Add("EmployeeID");
            tempEmployeesDataTable.Columns.Add("Name");

            for (int index = 1; index < 1000000; index++)
            {
                tempEmployeesDataTable.Rows.Add(index + 1, "Name " + index + 1);
            }


            DataTable tempPayRollDataTable = new DataTable();
            tempPayRollDataTable.Columns.Add("PayrollID");
            tempPayRollDataTable.Columns.Add("PayrollName");

            for (int index = 1; index < 1000000; index++)
            {
                tempPayRollDataTable.Rows.Add(index + 1, "Name " + index + 1);
            }

            using (SqlConnection connection = new SqlConnection(_sandboxDB.ConnectionString))
            {
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction();

                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepIdentity, transaction))
                {
                    try
                    {
                        sqlBulkCopy.DestinationTableName = "EmployeesMultiTableTest";
                        sqlBulkCopy.WriteToServer(tempEmployeesDataTable);

                        sqlBulkCopy.DestinationTableName = "PayrollMultiTableTest";
                        sqlBulkCopy.WriteToServer(tempPayRollDataTable);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        statusToReturn = false;
                    }

                }
            }

            statusToReturn = true;


            return statusToReturn;
        }


        public bool PerformBulkCopyFromCSVFile()
        {
            bool statusToReturn = true;

            // read the csv file

            using (var textReader = File.OpenText(""))
            using (CsvReader csvReader = new CsvReader(textReader))
            {
                csvReader.Configuration.HasHeaderRecord = true;
                csvReader.Configuration.RegisterClassMap<EarthQuakeDataEventMapper>();

                //TVPCollection<ogs_Event> tvpCollection = new TVPCollection<ogs_Event>(csvReader.GetRecords<ogs_Event>());

                //IDataReader convertedEarthquakeData = csvReader.GetRecords<Model.ogs_Event>().AsDataReader();
            }




            using (SqlConnection connection = new SqlConnection(_sandboxDB.ConnectionString))
            {
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction();

                using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepIdentity, transaction))
                {
                    try
                    {
                        sqlBulkCopy.DestinationTableName = "EarthQuakeDataTableTest";
                        //sqlBulkCopy.WriteToServer(tempEmployeesDataTable);

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        statusToReturn = false;
                    }

                }
            }

            statusToReturn = true;


            return statusToReturn;
        }

        #endregion public methods


        #region private methods

        private static void OnSqlRowsCopied(object sender, SqlRowsCopiedEventArgs e)
        {
            Console.WriteLine("Copied {0} records so far...", e.RowsCopied);
        }


        #endregion private methods
    }
}
