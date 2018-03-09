using System;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T _instance;
    private static bool isInited = false;

    private void Awake()
    {
        if (MonoSingleton<T>._instance == null)
        {
            MonoSingleton<T>._instance = this as T;
        }

        if (!isInited)
        {
            MonoSingleton<T>._instance.Initialize();
            isInited = true;
        }
    }

    protected virtual void Initialize()
    {
    }

    protected virtual void Dispose()
    {
    }

    protected void OnApplicationQuit()
    {
        if (null != MonoSingleton<T>._instance)
        {
            MonoSingleton<T>._instance.Dispose();
            MonoSingleton<T>._instance = null;
            isInited = false;
        }
    }

    public static T Reference
    {
        get { return _instance; }
    }

    public static T Instance
    {
        get { return GetInstance(); }
    }

    public static T GetInstance()
    {
        if (MonoSingleton<T>._instance == null)
        {
            MonoSingleton<T>._instance = UnityEngine.Object.FindObjectOfType(typeof(T)) as T;
            if (MonoSingleton<T>._instance == null)
            {                
                System.Type[] components = new System.Type[] { typeof(T) };
                MonoSingleton<T>._instance = new GameObject(typeof(T).ToString(), components).GetComponent<T>();
                MonoSingleton<T>._instance.Initialize();
                isInited = true;
            }
        }
        return MonoSingleton<T>._instance;
    }
}