using UnityCore.Factory;
using UnityEngine;

namespace UnityCore.Collections
{
  public class GameObjectPool : ObjectPool<GameObject>
  {
    public GameObjectPool(Factory<GameObject> ObjectFactory, int InitialSize) : base(ObjectFactory, InitialSize)
    {
    }
  }
}