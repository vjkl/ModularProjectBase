namespace Module.Validator
{
  public interface IValidator
  {
    string GetSinglePropertyError(object instance, string columnName);
    string GetAnyPropertyError(object instance);
  }
}
