using UnityEngine;

namespace UnityCore
{
  public abstract class CoreSingleton<T> : CoreBehaviour
    where T : CoreBehaviour
  {
    private static T instance;

    /// <summary>
    /// Getter for all < <see cref="CoreSingleton{T}"/> which WILL create
    /// new instances if a reference is not found.
    /// </summary>
    public static T Get()
    {
      if(instance == null)
      {
        T tInScene = GameObject.FindObjectOfType<T>();
        if(tInScene != null)
        {
          instance = tInScene;
        }
        else
        {
          GameObject newGameObject = new GameObject("~" + typeof(T).Name);
          instance = newGameObject.AddComponent<T>();
        }
      }

      return instance;
    }

    /// <summary>
    /// Getter for all <see cref="CoreSingleton{T}"/> which WILL NOT create
    /// new instances if a reference is not found. Use this in scenarios where
    /// you do not want to create a new instance of the singleton such as
    /// during scene destruction.
    /// </summary>
    public static T SafeGet()
    {
      if(instance == null)
      {
        T tInScene = GameObject.FindObjectOfType<T>();
        if (tInScene != null)
        {
          instance = tInScene;
        }
      }

      return instance;
    }

    public void MakePermanent()
    {
      DontDestroyOnLoad(this);
    }

    public override void OnDestroy()
    {
      base.OnDestroy();

      instance = null;
    }
  }
}
