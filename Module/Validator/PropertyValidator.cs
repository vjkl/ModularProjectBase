using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Module.Validator
{
  public class PropertyValidator : IValidator
  {
    public string GetSinglePropertyError(object instance, string columnName)
    {
      return string.Join(Environment.NewLine, Validate(instance, columnName).Select(x => x.Message));
    }

    public string GetAnyPropertyError(object instance)
    {
      return string.Join(Environment.NewLine, Validate(instance).Select(x => x.Message));
    }

    private IEnumerable<PropertyValidationError> Validate(object instance)
    {
      return from property in instance.GetType().GetProperties()
             from error in GetValidationErrors(instance, property)
             select error;
    }

    private IEnumerable<PropertyValidationError> Validate(object instance, string propertyName)
    {
      var property = instance.GetType().GetProperty(propertyName);
      return GetValidationErrors(instance, property);
    }

    private static IEnumerable<PropertyValidationError> GetValidationErrors(object instance, PropertyInfo property)
    {
      var context = new ValidationContext(instance, null, null);
      var validators =
        property.GetAttributes<ValidationAttribute>(true)
          .Where(
            attribute =>
              attribute.GetValidationResult(property.GetValue(instance, null), context) != ValidationResult.Success)
          .Select(attribute => new PropertyValidationError(instance
                                                , property.Name
                                                , attribute.FormatErrorMessage(property.Name)));

      return validators.Where(error => error != null);
    }
  }
}