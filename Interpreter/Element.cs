

namespace Interpreter;

public interface IElement
{
    int Value { get; }

}
public class Integer : IElement
{
    public Integer(int value)
    {
        Value = value;
    }

    public int Value { get; }
}

public class BinaryOperation : IElement
{
    public int Value
    {
        get
        {
            switch (MyType)
            {
                case Type.Addition:
                    return Left.Value + Right.Value;
                case Type.Subraction:
                    return Left.Value - Right.Value;
                default:
                    throw new NotImplementedException();
            }
        }
    }

    public enum Type
    {
        Addition, Subraction
    }

    public Type MyType;
    public IElement Left, Right;

}
