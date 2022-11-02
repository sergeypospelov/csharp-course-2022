using System.Runtime.ExceptionServices;

void AlwaysThrowsAe()
{
    throw new ArgumentException("Illegal argument!");
}

ExceptionDispatchInfo exceptionDispatchInfo;

try
{
    AlwaysThrowsAe();
}
catch (ArgumentException e)
{
    exceptionDispatchInfo = ExceptionDispatchInfo.Capture(e);
    Console.Out.WriteLine("StackTrace length at 1st point:");
    Console.Out.WriteLine(e.StackTrace?.Length);
}

try
{
    exceptionDispatchInfo.Throw();
}
catch (ArgumentException e)
{
    Console.Out.WriteLine("StackTrace length at 2nd point:");
    Console.Out.WriteLine(e.StackTrace?.Length);    
}
