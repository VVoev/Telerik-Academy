using ProjectManager.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProjectManager.Validatorz
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Validator
    {
        public void Validate<T>(T obj) where T : class
        {
            var error = this.GetValidationErrors(obj);
            if (!(error.Count() == 0))
            {
                throw new UserValidationException(error.First());
            }
        }

        public IEnumerable<string> GetValidationErrors(object obj)
        {
            Type t = obj.GetType();
            PropertyInfo[] property = t.GetProperties();
            Type attrType = typeof(ValidationAttribute);

            foreach (var propertyInfo in property)
            {
                object[] customAttributes = propertyInfo.GetCustomAttributes(attrType, inherit: true);
                foreach (var customAttribute in customAttributes)
                {
                    var validationAttribute = (ValidationAttribute)customAttribute;
                    bool valid = validationAttribute.IsValid(propertyInfo.GetValue(obj, BindingFlags.GetProperty, null, null, null));
                    if (!valid)
                    {
                        yield return validationAttribute.ErrorMessage;
                    }
                }
            }
        }
    }
}