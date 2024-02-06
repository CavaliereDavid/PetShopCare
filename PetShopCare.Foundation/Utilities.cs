using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCare.Foundation
{
    public static  class Utilities
    {
        public static Error CaptureException(Exception exception)
        {
            return new Error(exception.Message);
        }

    }
}
