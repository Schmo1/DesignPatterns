using System.Text;

namespace Visitor_Expression
{

    //using DictType = Dictionary<Type, Action<Expression, StringBuilder>>;


    internal class Program
    {
        static void Main(string[] args)
        {

            var ex = new AdditionalExpression(
                new DoubleExpression(1),
                new AdditionalExpression(new DoubleExpression(2), new DoubleExpression(3)));

            var exPrinter = new ExpressionPrinter();

            exPrinter.Visit(ex);


            var exCalculator = new ExpressionCalculator();
            exCalculator.Visit(ex);
            Console.WriteLine(exPrinter.ToString() + "=" + exCalculator.Result);
        }
    }

    public class ExpressionPrinter : IExpressionVisitor
    {
        StringBuilder sb = new();
        public void Visit(DoubleExpression de)
        {
            sb.Append(de.Value);
        }

        public void Visit(AdditionalExpression ae)
        {
            sb.Append('(');
            ae.Left.Accept(this);
            sb.Append('+');
            ae.Right.Accept(this);
            sb.Append(')');
        }

        public override string ToString()
         {
             return sb.ToString();
        }
    }

    public class ExpressionCalculator : IExpressionVisitor
    {
        public double Result;
        public void Visit(DoubleExpression de)
        {
            Result = de.Value;
        }
        public void Visit(AdditionalExpression ae)
        {
            ae.Left.Accept(this);
            var left = Result;
            ae.Right.Accept(this);
            var right = Result;
            Result = left + right;
        }
    }

    //public static class ExpressionPrinter
    //{
    //    private readonly static DictType _actions = new DictType
    //    {
    //        [typeof(DoubleExpression)] = (e, sb) =>
    //        {
    //            var de = (DoubleExpression)e;
    //            sb.Append(de.Value);
    //        },
    //        [typeof(AdditionalExpression)] = (e, sb) => 
    //        {
    //            var ae = (AdditionalExpression)e;
    //            sb.Append('(');
    //            Print(ae.Left, sb);
    //            sb.Append('+');
    //            Print(ae.Right, sb);
    //            sb.Append(')');
    //        }
    //    };

    //    public static void Print(Expression e, StringBuilder sb)
    //    {
    //        _actions[e.GetType()](e, sb);
    //    }

    //}


    public abstract class Expression
    {
        //public abstract void Print(StringBuilder sb);
        public abstract void Accept(IExpressionVisitor visitor);
    }

    public class DoubleExpression : Expression
    {
        public double Value;

        public DoubleExpression(double value)
        {
            this.Value = value;
        }

        public override void Accept(IExpressionVisitor visitor)
        {
            //double dispatch
            visitor.Visit(this);
        }
    }

    public class AdditionalExpression : Expression
    {
        public Expression Left , Right;

        public AdditionalExpression(Expression left, Expression right)
        {
            this.Left = left;
            this.Right = right;
        }

        public override void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

}
