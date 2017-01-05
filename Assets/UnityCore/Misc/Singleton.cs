namespace UnityCore
{
  public abstract class Singleton<T>
  {
    private static T instance;

    public static T Get()
    {
      if(instance == null)
      {
        instance = default(T);
      }

      return instance;
    }
  }
}
