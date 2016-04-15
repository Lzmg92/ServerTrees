using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServerTrees
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Servicio" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Servicio.svc or Servicio.svc.cs at the Solution Explorer and start debugging.
    public class Servicio : IServicio
    {
        #region IServicio Members

        public string JSONData(string id)
        {
            return "(JSON) You requested product" + id;
        }

        public string XMLData(string id)
        {
            return "(XML) You requested product" + id;
        }
        #endregion
    }
}
