using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples.Generics
{
    public class DataBaseUtilitiesExample
    {
        #region fields

        private ICollection<VendorExample> _iCollectionOfVendors;
        private List<VendorExample> _listOfVendors;

        #endregion fields


        #region properties

        public List<VendorExample> ListOfVendors
        {
            get { return _listOfVendors; }
            set { _listOfVendors = value; }
        }

        #endregion properties


        #region constructors

        public DataBaseUtilitiesExample()
        {
        }

        public DataBaseUtilitiesExample(int numberOfRecordsToCreate)
        {
            BuildDummyData(numberOfRecordsToCreate);
        }

        #endregion constructors


        #region public methods


        public ICollection<VendorExample> GetVendors<T>(T typeOfICollectionToGet)
        {
            // simulate getting the list from the DB...

            if (typeOfICollectionToGet.GetType() == typeof(List<VendorExample>))
            {
                List<VendorExample> vendorList = new List<VendorExample>();
                for (int index = 0; index < 4; index++)
                {
                    VendorExample vendorExample = new VendorExample(String.Format("some vendor name{0}", index.ToString()));
                    vendorList.Add(vendorExample);
                }

                return vendorList;
            }
            else if (typeOfICollectionToGet.GetType() == typeof(VendorExample[]))
            {
                VendorExample[] vendorsArray = new VendorExample[3];

                for (int index = 0; index < vendorsArray.Length; index++)
                {
                    VendorExample vendorExample = new VendorExample(String.Format("some vendor name{0}", index.ToString()));
                    vendorsArray[index] = vendorExample;
                }

                return vendorsArray;
            }

            for (int index = 0; index < 4; index++)
            {
                VendorExample vendorExample = new VendorExample(String.Format("some vendor name{0}", index.ToString()));
            }

            return _iCollectionOfVendors;
        }


        public IEnumerable<VendorExample> GetVendorsWithIterator()
        {
            // using the yield keyword can be helpful when:
            // - when a method should return one element at a time (Lazy Evaluation)
            // - when you need a deferred execution (there is a delay in the return)
            // - dont use this when its not needed as it can be confusing to debug/calling code

            _iCollectionOfVendors = new List<VendorExample>();

            for (int index = 0; index < 4; index++)
            {
                VendorExample vendorExample = new VendorExample(String.Format("some vendor name{0}", index.ToString()));
                _iCollectionOfVendors.Add(vendorExample);
            }

            foreach (VendorExample vendorExample in _iCollectionOfVendors)
            {
                //Console.WriteLine(vendorExample.VendorName);
                yield return vendorExample;
            }
        }

        #endregion public methods


        #region private methods

        private void BuildDummyData(int numberOfRecordsToCreate)
        {
            _listOfVendors = new List<VendorExample>();

            for (int index = 0; index < numberOfRecordsToCreate; index++)
            {
                VendorExample vendorExample = new VendorExample();
                vendorExample.VendorName = String.Format("some vendor name{0}", index.ToString());
                vendorExample.VendorID = index;
                vendorExample.VendorEmail = String.Format("test{0}@test.com", index.ToString());

                _listOfVendors.Add(vendorExample);
            }
        }
        #endregion private methods
    }
}
