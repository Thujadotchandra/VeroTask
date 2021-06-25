using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeroTest.Core.Helper
{
    public static class CheckString
    {
        public static void IsValid(string parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(parameter);
            }

            if (parameter.Trim() == String.Empty)
            {
                throw new ArgumentException("Input cannot be empty", parameter);
            }
        }
    }
}
