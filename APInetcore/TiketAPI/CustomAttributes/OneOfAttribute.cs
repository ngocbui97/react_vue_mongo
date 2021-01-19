using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TiketAPI.CustomAttributes
{
    public class OneOfAttribute : ValidationAttribute
    {
        public int[] ItemInt { get; set; }
        public string[] ItemString { get; set; }
        public OneOfAttribute(params int[] items) : base("{0} value is not in " + String.Join(",", items))
        {
            this.ItemInt = items;
        }
        public OneOfAttribute(params string[] items) : base("{0} value is not in " + String.Join(",", items))
        {
            this.ItemString = items;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (ItemInt.Length > 0)
            {
                int val = (int)value;
                if (!ItemInt.Contains(val))
                {
                    return new ValidationResult(base.FormatErrorMessage(validationContext.MemberName)
                                                , new string[] { validationContext.MemberName });
                }
                return null;
            }
            else
            {
                string val = (string)value;
                if (!ItemString.Contains(val))
                {
                    return new ValidationResult(base.FormatErrorMessage(validationContext.MemberName)
                                                , new string[] { validationContext.MemberName });
                }
                return null;
            }
        }
    }
}
