namespace Module.Validator
{
  interface IValidator
  {
    string GetSinglePropertyError(object instance, string columnName);
    string GetAnyPropertyError(object instance);
  }
}
