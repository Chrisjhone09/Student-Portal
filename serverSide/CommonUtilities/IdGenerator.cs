using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace serverSide.CommonUtilities
{
    public class IdGenerator
    {
        public static string GenerateId()
        {
           string prefix = DateTime.Now.Year.ToString();
            Random random = new Random();
            string id = random.Next(1000, 9999).ToString();
            return $"{prefix}-{id}";
        }
    }
}
