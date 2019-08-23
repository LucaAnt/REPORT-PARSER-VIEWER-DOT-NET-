using System;

using System.Windows.Forms;

using Parsing_Service.View;

namespace Parsing_Service
{
    static class Program
    {
        

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ReportParsingServiceUISingle());
        }
        
    }
}
