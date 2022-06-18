public class AddCommand : BaseBinaryCommand
{
    private readonly int _regNumberForResult;

    public AddCommand(int regNumberForResult) 
        : base(regNumberForResult, "add"){}

    protected override int ExecuteBinaryCommand(int left, int right) => left + right;
}