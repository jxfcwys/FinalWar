public class Singleton<T> where T : Singleton<T>, new()
{
    private static T _instance;

    private static readonly object _sync = new object();

    static Singleton()
    {
        Singleton<T>._instance = default(T);
    }

    public static T Instance
    {
        get { return GetInstance(); }
    }

    public static T GetInstance()
    {
        if (null == Singleton<T>._instance)
        {
            lock (_sync)
            {
                if (null == Singleton<T>._instance)
                {
                    Singleton<T>._instance = new T();
                    Singleton<T>._instance.Initialize();
                }
            }
        }
        return Singleton<T>._instance;
    }

    protected virtual void Initialize()
    {

    }
}