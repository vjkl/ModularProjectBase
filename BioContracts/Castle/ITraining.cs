using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioContracts.Castle
{
  public interface ITraining
  {
    void Create();
    void Load(string path);
  }
}
