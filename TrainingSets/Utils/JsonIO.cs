using Newtonsoft.Json;
using System.Windows;

namespace TrainingSets.Utils
{
  public class JsonIO
  {
    public string SerializeObject<T>(T inputString)
    {
      return JsonConvert.SerializeObject(inputString, Formatting.Indented);
    }

    public T DeserializeObject<T>(string inputString) where T : class
    {
      if (!string.IsNullOrEmpty(inputString))
      {
        try
        {
          return JsonConvert.DeserializeObject<T>(inputString);
        }
        catch (JsonSerializationException ex)
        {
          MessageBox.Show(ex.Message);
        }
      }
      return null;
    }
  }
}
