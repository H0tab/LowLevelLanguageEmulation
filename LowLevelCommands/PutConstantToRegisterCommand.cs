class PutConstantToRegisterCommand : ICommand
{
    private readonly int _regNumberToWrite;
    private readonly int _constant;

    public PutConstantToRegisterCommand(int regNumberToWrite, int constant)
    {
        _regNumberToWrite = regNumberToWrite;
        _constant = constant;
    }
    public void Execute(int[] registers, ref int currentCommandIndex)
    {
        registers[_regNumberToWrite] = _constant;
        currentCommandIndex++;
    }

    public void Dump()
    {
        Console.Write($"put r{_regNumberToWrite} {_constant}");
    }
}