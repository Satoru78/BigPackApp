using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBigPackApp.Model
{
    public partial class Materials
    {
        public string GetImage
        {
            get
            {
                return Environment.CurrentDirectory + "\\" + Image;
            }
            set
            {
                Image = value;
            }
        }
        public string GetFullTitle
        {
            get
            {
                return $"{MaterialsType.Title} | {Title}";
            }
        }
    }
}
