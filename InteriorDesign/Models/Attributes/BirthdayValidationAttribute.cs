namespace InteriorDesign.Models.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

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
