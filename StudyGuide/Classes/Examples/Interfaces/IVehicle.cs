using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Examples
{
    // Interfaces are contracts that contain no implementation details, they only define signatures of methods, events, and properties
    // A type can implement multiple interfaces. Interfaces cannot contain fields or properties. All definitions of an interface are implicedly virtual 
    // as must be overridden
    interface IVehicle : IEnumerable
    {
        string VehicleType { get; set; }

        bool IsUsedToTransportGoods();

        void AddItemToVehicle(string itemToStore);

        string GetFirstItemInVehicle();

        //if we want to be able to loop or enumerate through a collection in the classes that Implement this interface, then we need to implement the
        // .NET IEnumerable class and provide an impementation of what to enumerate when this is called
        IEnumerator GetEnumerator();
    }
}
