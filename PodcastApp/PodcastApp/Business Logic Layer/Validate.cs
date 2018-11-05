using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Validate : StringManipulator
    {
        public Validate()
        {

        }

        public bool ValidateLength(string input, int minLength, int maxLength)
        {
            bool validate = false;

            if (input.Length >= minLength && input.Length <= maxLength)
            {
                validate = true;
            }
            return validate;


        }
        public bool ValidateUpdateCategory(string input)
        {
            bool validate = false;
            if (ValidateLength(input, 3, 20))
            {
                validate = true;
            }
            return validate;
        }

        public bool ValidateUrl(string url)
        {
            bool result = Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            return result;
        }
    }

    
   
}
