namespace InteriorDesign.Web.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class BirthdayValidationAttribute : ValidationAttribute
    {
        private const int MinAge = 18;

        private const int MaxAge = 90;

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var val = (DateTime)value;

            if (val.AddYears(MinAge) > DateTime.Now)
            {
                return false;
            }

            return val.AddYears(MaxAge) > DateTime.Now;
        }
    }
}
