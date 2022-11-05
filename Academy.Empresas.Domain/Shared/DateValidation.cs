using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academy.Empresas.Domain.Shared
{
    public class DateValidation
    {
        public static bool Validacao(string date)
        {
            try
            {
                string[] dateParts = date.Split('/');


                DateTime testDate = new
                    DateTime(Convert.ToInt32(dateParts[2]),
                    Convert.ToInt32(dateParts[0]),
                    Convert.ToInt32(dateParts[1]));

                return true;
            }
            catch
            {

                return false;
            }
        }
    }
}