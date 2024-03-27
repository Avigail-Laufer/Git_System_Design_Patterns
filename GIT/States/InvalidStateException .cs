
namespace GIT.States;

internal class InvalidStateException : Exception
{
    public InvalidStateException(string s)
    {
        Console.WriteLine(s);
    }

}
