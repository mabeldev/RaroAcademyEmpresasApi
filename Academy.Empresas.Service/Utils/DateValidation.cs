namespace Academy.Empresas.Service.Utils
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