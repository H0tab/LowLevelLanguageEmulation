public class SubstractCommand : BaseBinaryCommand
{
    private readonly int _regNumberForResult;

    public SubstractCommand(int regNumberForResult) 
        : base(regNumberForResult, "substr"){}

    protected override int ExecuteBinaryCommand(int left, int right) => left - right;
}