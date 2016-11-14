using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Utils
{
  public class DialogUtil
  {
    public string GetPathToFileFromDialog()
    {
      System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();

      openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
      openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
      openFileDialog.FilterIndex = 2;
      openFileDialog.RestoreDirectory = true;

      if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        return openFileDialog.FileName;
      }
      return string.Empty;
    }
  }
}
