using System;
using System.IO;
using System.Text;
using System.Windows;
namespace TrainingSets.Utils
{
  public class FileIO
  {
    public bool Create(string path)
    {
      if (!File.Exists(path))
      {
        File.WriteAllText(path, "", Encoding.UTF8);
        return true;
      }
      return false;
    }

    public string Read(string path)
    {
      if (string.IsNullOrEmpty(path)) return null;
      return File.ReadAllText(path);
    }

    public string Load(string path)
    {
      return Read(path);
    }

    public bool Save(string contents, string path)
    {
      if (File.Exists(path))
      {
        if (contents == "[]")
          contents = "";
        try
        {
          File.WriteAllText(path, contents, Encoding.UTF8);
          return true;
        }
        catch (UnauthorizedAccessException ex)
        {
          MessageBox.Show(ex.Message);
          return false;
        }
      }
      return false;
    }
  }
}
