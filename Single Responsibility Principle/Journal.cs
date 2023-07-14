

using System.IO.Enumeration;

namespace SingleResponsibilityPrinciple
{
    public class Journal
    {
        private readonly List<string> entries = new();
        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; //info: memento pattern
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }


        /* Do not this...
         
         public void SafeToFile()
        {
        }

        public void LoadFromFile()
        {
        }        
         
        Create seperate class ==> single Responsibility
         */
    }


    public class Persistance
    {
        public void SafeToFile(object j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, j.ToString());
            }
        }
    }
}
