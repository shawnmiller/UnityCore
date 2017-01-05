
namespace UnityCore.Factory
{
  public interface IFactoryCreatable
  {
    /// <summary>
    /// Called when first created by a factory.
    /// </summary>
    void OnCreate();
  }
}
