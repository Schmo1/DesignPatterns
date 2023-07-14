using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Interface_Segregation_Principle
{
    public class Document
    {

    }

    public class MultiFunctionPrinter : IMultifunctionDevice
    {
        public void Fax(Document document)
        {
            //
        }

        public void Print(Document document)
        {
            //
        }

        public void Scan(Document document)
        {
            //
        }
    }

    public class OldFashionedPrinter : IPrinter
    {
        public void Print(Document d)
        {
            //
        }
    }

    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {

        }

        public void Scan(Document d)
        {
            //
        }
    }

    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    public interface IFax
    {
        void Fax(Document d);
    }

    public interface IMultifunctionDevice : IPrinter, IScanner, IFax
    {

    }


    /*
     * Don't use one big Interface
    public interface IMachine 
    {
        void Print(Document document);
        void Scan(Document document);
        void Fax(Document document);        
    }
    */

}
