using System;
using System.Collections.Generic;
using UnityCore.Factory;
using UnityEngine;
using System.Linq;

namespace UnityCore.Collections
{
  /// <summary>
  /// Base class for creating object pools.
  /// </summary>
  /// <typeparam name="T">The type of object this pool contains.</typeparam>
  public class ObjectPool<T> : IPool<T>
  {
    public int Size
    {
      get { return size; }
    }
    private int size;

    protected Factory<T> factory;
    
    protected Stack<T> instances;

    /// <summary>
    /// Constructor for ObjectPool.
    /// </summary>
    /// <param name="ObjectFactory">The factory which will create instances for this pool.</param>
    /// <param name="InitialSize">The initial size of this pool.</param>
    public ObjectPool(Factory<T> ObjectFactory, int InitialSize)
    {
      if(ObjectFactory == null)
      {
        throw new System.ArgumentNullException("ObjectFactory", "ObjectFactory cannot be null.");
      }
      if(InitialSize < 0 || (InitialSize == Mathf.Infinity))
      {
        throw new System.ArgumentException("InitialSize must be a finite number greater than 0.", "InitialSize");
      }

      factory = ObjectFactory;
      size = InitialSize;
      instances = new Stack<T>(size);
      Initialize();
    }
    
    /// <summary>
    /// Gets an object from the pool.
    /// </summary>
    public T Get()
    {
      if (instances.Count != 0)
      {
        return instances.Pop();
      }
      return factory.Create();
    }

    /// <summary>
    /// Returns an object to the pool.
    /// </summary>
    /// <param name="Object"></param>
    public void Return(T Object)
    {
      if(!Object.Equals(default(T)))
      {
        instances.Push(Object);
      }
    }

    /// <summary>
    /// Initializes the object pool to the declared size.
    /// </summary>
    protected virtual void Initialize()
    {
      for (int i = 0; i < size; ++i)
      {
        instances.Push(factory.Create());
      }
    }
  }
}
