using System.Text;

namespace Visitor_Expression
{

    using DictType = Dictionary<Type, Action<Expression, StringBuilder>>;

    internal class Program
    {
        static void Main(string[] args)
        {
            var sb = new StringBuilder();

            var ex = new AdditionalExpression(
                new DoubleExpression(1),
                new AdditionalExpression(new DoubleExpression(2), new DoubleExpression(3)));

            ExpressionPrinter.Print(ex, sb);
            Console.WriteLine(sb);
        }
    }

    public static class ExpressionPrinter
    {
        private readonly static DictType _actions = new DictType
        {
            [typeof(DoubleExpression)] = (e, sb) =>
            {
                var de = (DoubleExpression)e;
                sb.Append(de.Value);
            },
            [typeof(AdditionalExpression)] = (e, sb) => 
            {
                var ae = (AdditionalExpression)e;
                sb.Append('(');
                Print(ae.Left, sb);
                sb.Append('+');
                Print(ae.Right, sb);
                sb.Append(')');
            }
        };

        public static void Print(Expression e, StringBuilder sb)
        {
            _actions[e.GetType()](e, sb);
        }

    }


    public abstract class Expression
    {
        //public abstract void Print(StringBuilder sb);
    }

    public class DoubleExpression : Expression
    {
        public double Value;

        public DoubleExpression(double value)
        {
            this.Value = value;
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

    }
}
