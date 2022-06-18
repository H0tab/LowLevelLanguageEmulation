int[] registers = new int[2];

//int i = 0;
//while (i < 10)
//{
//    Console.WriteLine("while");
//    i++
//}

var declarations = new ICommand[]
{
    new PutConstantToRegisterCommand(0, 0),
    new WriteCommand("i", 0),
};

var conditionWhile = new ICommand[]
{
    new PutConstantToRegisterCommand(1, 10),
    new ReadCommand("i", 0),
    new LtCommand(0),
};

var body = new ICommand[]
{
    new OutputCommand("while")
}.Concat(new IncrementCommand("i").Compile()).ToArray();

var commands = declarations.Concat(new WhileCommand(conditionWhile, body)
    .Compile()).ToArray();

for (int i = 0; i < commands.Length;)
{
    Console.Write($"[{i.ToString().PadLeft(3, '0')}]");
    var currentCommand = commands[i];
    currentCommand.Dump();
    Console.CursorLeft = 60;
    currentCommand.Execute(registers, ref i);
    Console.CursorLeft = 20;
    registers.Dump();
    Console.CursorLeft = 30;
    Memory.Dump();
    Console.WriteLine();
}

Console.ReadLine();

public class OutputCommand : ICommand
{
    private readonly string _text;

    public OutputCommand(string text)
    {
        _text = text;
    }

    public void Execute(int[] registers, ref int currentCommandIndex)
    {
        Console.Write(_text);
        currentCommandIndex++;
    }

    public void Dump()
    {
        Console.Write("out");
    }
}