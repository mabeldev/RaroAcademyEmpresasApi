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
            DateTime temp;
            if (DateTime.TryParse(date, out temp))
            {
                return true;
            }
            return false;
        }
    }
}