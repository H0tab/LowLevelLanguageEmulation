public class WriteCommand : ICommand
{
    private readonly string _address;
    private readonly int _regNumberToWriteFrom;

    public WriteCommand(string address, int regNumberToWriteFrom)
    {
        _address = address;
        _regNumberToWriteFrom = regNumberToWriteFrom;
    }

    public void Execute(int[] registers, ref int currentCommandIndex)
    {
        Memory.Write(_address, registers[_regNumberToWriteFrom]);
        currentCommandIndex++;
    }

    public void Dump()
    {
        Console.Write($"{_address} = r{_regNumberToWriteFrom}");
    }
}