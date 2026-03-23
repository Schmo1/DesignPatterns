namespace Visitor_Expression
{
    public interface IExpressionVisitor
    {
        void Visit(DoubleExpression de);
        void Visit(AdditionalExpression ae);
    }
}