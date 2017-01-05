
interface IPool<T>
{
  /// <summary>
  /// Fetches a new instance of the pooled object.
  /// </summary>
  T Get();

  /// <summary>
  /// Used to return a pooled object to the pool.
  /// </summary>
  void Return(T Object);
}
