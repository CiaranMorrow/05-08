using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
       /// The main entry point for the application.
       
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MessageBox.Show(" Welcome to Lend-IT-Out Media Hire Comapany \n Please Read Company GDPR Policy Before Using the System");
            //this allows the user to be aware of their responsibility when using the system 
            
            Application.Run(new mdi_user());
        }
    }
}
