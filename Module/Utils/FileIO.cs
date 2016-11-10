using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Module.Utils
{
  public class FileIO
  {
    private static string _NameFileWithListTrainings = "ListTrainings.txt"                                                ;
    private string _pathToListTrainings              = Directory.GetCurrentDirectory() + "\\" + _NameFileWithListTrainings;

    public string InitFile()
    {
      if (File.Exists(_pathToListTrainings))
      {
        return Read(_pathToListTrainings);
      }
      else
        File.WriteAllText(_pathToListTrainings, "", Encoding.UTF8);
      return string.Empty;
    }

    public string Read(string path)
    {
      if (string.IsNullOrEmpty(path)) return null;
      return File.ReadAllText(path);
    }

    public string Load(string path)
    {
        SetNewPathToListTrainings(path);
        return Read(path);
    }

    public void Save(string contents)
    {
      if (File.Exists(_pathToListTrainings))
      {
        if (contents != "[]")
        {
          try
          {
            File.WriteAllText(_pathToListTrainings, contents, Encoding.UTF8);
          }
          catch (UnauthorizedAccessException ex)
          {
            MessageBox.Show(ex.Message);
          }
        }
      }
    }

    private void SetNewPathToListTrainings(string newPathToListTrainings)
    {
      if (!string.IsNullOrEmpty(newPathToListTrainings))
      {
        _pathToListTrainings = newPathToListTrainings;
      }
    }
  }
}