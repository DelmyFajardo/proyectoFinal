using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDeRegistrosMedicos
{
    static class Program
    {
        [STAThread] 
        static void Main(string[] args)
        {
            ApplicationException.EnableVisualStyles();
            ApplicationException.SetCompatibleTextRenderingDefaul(false);
            ApplicationException.Run(new Employees());
        }
    }
}
