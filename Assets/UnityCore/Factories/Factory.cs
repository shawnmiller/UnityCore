
using System;

namespace UnityCore.Factory
{
  /// <summary>
  /// Base class for all factories.
  /// </summary>
  /// <typeparam name="T">The object type this factory creates.</typeparam>
  public abstract class Factory<T> : IFactory<T>
  {
    /// <summary>
    /// Base constructor for factories to determines underlying data about the object.
    /// </summary>
    public Factory()
    {
      DetermineFactoryCreatableStatus();
    }

    protected bool inheritsCreatable;

    /// <summary>
    /// Returns an instance of the object this factory should create.
    /// </summary>
    /// <returns></returns>
    public T Create()
    {
      T Instance = CreateInstance();
      OnInstanceCreated(Instance);
      return Instance;
    }

    /// <summary>
    /// Creates an instance of the object this factory should create.
    /// </summary>
    /// <returns></returns>
    protected virtual T CreateInstance()
    {
      return default(T);
    }

    /// <summary>
    /// Performs creation actions on the object if it can.
    /// </summary>
    /// <param name="Instance">The instance that was just created.</param>
    protected void OnInstanceCreated(T Instance)
    {
      if(inheritsCreatable)
      {
        PerformObjectOnCreate(Instance);
      }
    }

    /// <summary>
    /// Called when creating an object which inherits from IFactoryCreatable.
    /// </summary>
    /// <param name="Instance"></param>
    protected virtual void PerformObjectOnCreate(T Instance)
    {
      ((IFactoryCreatable)Instance).OnCreate();
    }

    /// <summary>
    /// Determines if the object type inherits from IFactoryCreatable.
    /// </summary>
    protected virtual void DetermineFactoryCreatableStatus()
    {
      if (typeof(T).IsAssignableFrom(typeof(IFactoryCreatable)))
      {
        inheritsCreatable = true;
      }
      else
      {
        inheritsCreatable = false;
      }
    }
  }
}
