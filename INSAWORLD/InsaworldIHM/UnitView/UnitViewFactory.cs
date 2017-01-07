using InsaworldIHM.UnitView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsaworldIHM.UnitView
{
    class UnitViewFactory
    {
        private static UnitViewFactory instance;
        public static UnitViewFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UnitViewFactory();
                }
                return instance;
            }
        }

        public ViewUnit build(String r)
        {
            switch (r)
            {
                case "Centaurs":
                    return new ViewUnitCentaurs();
                case "Cyclops":
                    return new ViewUnitCyclop();
                case "Cerberus":
                    return new ViewUnitCerberus();
                default: throw new Exception("Unit Type Badly Given");
            }
        }
    }
}
