using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hni.Diagnostic.Gathering;

namespace Hni.Diagnostic.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Test1");
                DiagnosticInformation diagnosticInformation = new DiagnosticInformation("Hni.Diagnostic.TestConsole.Program.Main", "Testing1", "nothing1");
                diagnosticInformation.Save();

                Console.WriteLine("Test2");
                DiagnosticInformation diagnosticInformation2 = new DiagnosticInformation("Hni.Diagnostic.TestConsole.Program.Main", "nothing2");
                diagnosticInformation2.Save();

                Console.WriteLine("Test3");
                diagnosticInformation.DiagnosticDescription = "Testing2";
                diagnosticInformation.DiagnosticData = "nothing2";
                diagnosticInformation.Save();

                int x = Console.Read();
            }catch(Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                int x = Console.Read();
            }
        }
    }
}
