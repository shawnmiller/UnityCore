
namespace UnityCore.Settings
{
  public abstract class Setting<T>
  {
    T minimumLevel;
    T maximumLevel;
    T current;
  }
}
