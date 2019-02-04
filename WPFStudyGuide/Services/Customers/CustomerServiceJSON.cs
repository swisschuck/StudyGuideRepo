using System;
using System.Collections.Generic;
using System.Linq;
using System.Json;
using System.Threading.Tasks;
using WPFStudyGuide.Classes.Other;
using System.IO;
using Newtonsoft.Json;

namespace WPFStudyGuide.Services.Customers
{
    public class CustomerServiceJSON : ICustomerService
    {
        #region fields

        private string _parentDirectory;
        private string _customersJsonFilePath;


        #endregion fields


        #region properties
        #endregion properties


        #region constructors

        public CustomerServiceJSON()
        {
            _parentDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            _customersJsonFilePath = _parentDirectory + @"\DataBase\JSON\CustomersMockDB.json";
        }

        #endregion constructors


        #region public methods

        public Task<SimpleCustomer> GetCustomerAsync(Guid id)
        {
            Task<SimpleCustomer> taskToReturn = Task.Run(() =>
            {
                return new SimpleCustomer();
            });

            return taskToReturn;
        }

        public Task<List<SimpleCustomer>> GetCustomersAsync(bool getMockedData = false)
        {
            List<SimpleCustomer> customersToReturn = new List<SimpleCustomer>();

            Task<List<SimpleCustomer>> taskToReturn = Task.Run(() =>
            {
                if (getMockedData)
                {
                    return GetSimpleCustomersMocked();
                }

                try
                {
                    string jsonstring = DoesFileExist(_customersJsonFilePath);

                    if (String.IsNullOrEmpty(jsonstring))
                    {
                        return customersToReturn;
                    }

                    customersToReturn = JsonConvert.DeserializeObject<List<SimpleCustomer>>(jsonstring);

                    if (customersToReturn.Count == 1 && customersToReturn.FirstOrDefault().Id == new Guid())
                    {
                        // if there is only an empty JSON array in the file then just an empty list
                        return new List<SimpleCustomer>();
                    }
                }
                catch (Exception ex)
                {
                    return new List<SimpleCustomer>();
                }

                return customersToReturn;
            });

            return taskToReturn;
        }


        public async Task<bool> AddCustomerAsync(SimpleCustomer customerToAdd)
        {
            List<SimpleCustomer> currentCustomers = new List<SimpleCustomer>();

            Task<bool> taskToReturn = Task.Run(() => {

                try
                {
                    string jsonstring = DoesFileExist(_customersJsonFilePath);

                    if (String.IsNullOrEmpty(jsonstring))
                    {
                        return false;
                    }

                    currentCustomers = JsonConvert.DeserializeObject<List<SimpleCustomer>>(jsonstring);

                    if (currentCustomers.Count == 1 && currentCustomers.FirstOrDefault().Id == new Guid())
                    {
                        currentCustomers.Add(customerToAdd);
                    }
                    else
                    {
                        bool userAlreadyExists = currentCustomers.Exists(currentCustomer => currentCustomer.Id == customerToAdd.Id);

                        if (userAlreadyExists)
                        {
                            return false;
                        }
                        else
                        {
                            currentCustomers.Add(customerToAdd);
                        }
                    }

                    File.WriteAllText(_customersJsonFilePath, JsonConvert.SerializeObject(currentCustomers, Formatting.Indented));

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            });

            taskToReturn.Wait();

            return true;
        }

        public async Task<bool> UpdateCustomerAsync(SimpleCustomer customerToUpdate)
        {
            List<SimpleCustomer> currentCustomers = new List<SimpleCustomer>();

            Task<bool> taskToReturn = Task.Run(() => {

                try
                {
                    string jsonstring = DoesFileExist(_customersJsonFilePath);

                    if (String.IsNullOrEmpty(jsonstring))
                    {
                        return false;
                    }

                    currentCustomers = JsonConvert.DeserializeObject<List<SimpleCustomer>>(jsonstring);

                    if (currentCustomers.Count == 1 && currentCustomers.FirstOrDefault().Id == new Guid())
                    {
                        // this means we have a file with an empty JSON array in it
                        return false;
                    }
                    else
                    {
                        SimpleCustomer customerFromDB = currentCustomers.Where(currentCustomer => currentCustomer.Id == customerToUpdate.Id).FirstOrDefault();

                        if (customerFromDB != null)
                        {
                            currentCustomers.Remove(customerFromDB);

                            customerFromDB.FirstName = customerToUpdate.FirstName;
                            customerFromDB.LastName = customerToUpdate.LastName;
                            customerFromDB.Phone = customerToUpdate.Phone;
                            customerFromDB.State = customerToUpdate.State;
                            customerFromDB.StoreId = customerToUpdate.StoreId;
                            customerFromDB.Street = customerToUpdate.Street;
                            customerFromDB.Zip = customerToUpdate.Zip;
                            customerFromDB.City = customerToUpdate.City;
                            customerFromDB.Email = customerToUpdate.Email;

                            currentCustomers.Add(customerFromDB);
                        }
                        else
                        {
                            // user was not found in the DB
                            return false;
                        }
                    }

                    File.WriteAllText(_customersJsonFilePath, JsonConvert.SerializeObject(currentCustomers, Formatting.Indented));

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            });

            taskToReturn.Wait();

            return true;
        }

        public async Task<bool> DeleteCustomerAsync(SimpleCustomer customerToDelete)
        {
            List<SimpleCustomer> currentCustomers = new List<SimpleCustomer>();

            Task<bool> taskToReturn = Task.Run(() => {

                try
                {
                    string jsonstring = DoesFileExist(_customersJsonFilePath);

                    if (String.IsNullOrEmpty(jsonstring))
                    {
                        return false;
                    }

                    currentCustomers = JsonConvert.DeserializeObject<List<SimpleCustomer>>(jsonstring);

                    if (currentCustomers.Count == 1 && currentCustomers.FirstOrDefault().Id == new Guid())
                    {
                        // this means we have a file with an empty JSON array in it
                        return false;
                    }
                    else
                    {
                        SimpleCustomer customerFromDB = currentCustomers.Where(currentCustomer => currentCustomer.Id == customerToDelete.Id).FirstOrDefault();

                        if (customerFromDB != null)
                        {
                            currentCustomers.Remove(customerFromDB);
                        }
                        else
                        {
                            // user was not found in the DB
                            return false;
                        }
                    }

                    File.WriteAllText(_customersJsonFilePath, JsonConvert.SerializeObject(currentCustomers, Formatting.Indented));

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }

            });

            taskToReturn.Wait();

            return true;
        }
        #endregion public methods


        #region private methods

        private List<SimpleCustomer> GetSimpleCustomersMocked()
        {
            List<SimpleCustomer> customersToSendBack = new List<SimpleCustomer>();

            for (int index = 0; index < 20; index++)
            {
                SimpleCustomer customer = new SimpleCustomer();
                customer.Id = Guid.NewGuid();
                customer.FirstName = String.Format("FirstName{0}", index);
                customer.LastName = String.Format("LastName{0}", index);
                customer.Email = String.Format("test{0}@fake.com", index);
                customer.Phone = String.Format("555-555-55{0}", index < 10 ? String.Concat(index, index) : index.ToString());
                customer.State = "Colorado";
                customer.Street = String.Format("{0} fake street", index < 10 ? String.Concat(index, index) : index.ToString());
                customer.City = "Denver";
                customer.Zip = "80001";
                customer.StoreId = new Guid();
                customersToSendBack.Add(customer);
            }

            return customersToSendBack;
        }

        private string DoesFileExist(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return null;
            }

            string fileContents = File.ReadAllText(filePath);

            if (String.IsNullOrEmpty(fileContents))
            {
                return null;
            }

            try
            {
                var tmpObj = JsonValue.Parse(fileContents);
            }
            catch(FormatException fe)
            {
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }

            return fileContents.Trim();
        }

        #endregion private methods
    }
}
