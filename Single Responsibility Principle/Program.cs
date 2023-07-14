using System.Diagnostics;

namespace SingleResponsibilityPrinciple

{
    internal class Program
    {

        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("Today i cry!");
            j.AddEntry("I ate a bug");
            Console.WriteLine(j);
            
            var p = new Persistance();
            var filename = @"c:\temp\journal.txt";

            p.SafeToFile(j, filename, true);

            var stInfo = new ProcessStartInfo(filename);
            stInfo.WorkingDirectory = @"c:\temp\";
            stInfo.UseShellExecute = true;
   
            Process.Start(stInfo);
        }
    }
}