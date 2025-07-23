public class Logger
{
    private static readonly Lazy<Logger> lazyInstance = new Lazy<Logger>(() => new Logger());
 
    private Logger() {}
 
    public static Logger GetInstance()
    {
        return lazyInstance.Value;
    }
}