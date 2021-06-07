using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCommunication.DBInitializers
{
    interface ISeed
    {
        void AddToSeed(ref StorageManagementDBContext context);
    }
}
