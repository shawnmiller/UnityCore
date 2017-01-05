
namespace UnityCore.Collections
{
  public interface IPoolable<T>
  {
    /// <summary>
    /// Called whenever the object is returned to the pool.
    /// </summary>
    void OnEnterPool();

    /// <summary>
    /// Called whenever the object is gotten from the pool.
    /// </summary>
    void OnExitPool();
  }
}
