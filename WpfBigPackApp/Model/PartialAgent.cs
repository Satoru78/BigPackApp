using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBigPackApp.Model
{
   public partial class Agent
    {
        public string GetLogotype
        {
            get
            {
                return Environment.CurrentDirectory + "\\" + Logotype;
            }
            set
            {
                Logotype = value;
            }
        }
    }
}
