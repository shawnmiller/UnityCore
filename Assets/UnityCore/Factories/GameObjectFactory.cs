using System;
using UnityEngine;

namespace UnityCore.Factory
{
  /// <summary>
  /// Base factory for all GameObjects.
  /// </summary>
  public class GameObjectFactory : Factory<GameObject>
  {
    protected GameObject prefab;

    public void SetPrefab(GameObject Prefab)
    {
      if(!Prefab)
      {
        throw new System.ArgumentNullException("Prefab", "Prefab must not be null.");
      }
      prefab = Prefab;

      DetermineFactoryCreatableStatus();
    }
    
    protected sealed override GameObject CreateInstance()
    {
      if(!prefab)
      {
        throw new System.NullReferenceException("Attempted to create an instance of a GameObject from a null prefab.");
      }
      var Instance = GameObject.Instantiate(prefab);
      Instance.SetActive(false);
      return Instance;
    }

    protected sealed override void DetermineFactoryCreatableStatus()
    {
      if(!prefab)
      {
        inheritsCreatable = false;
      }
      else
      {
        if(prefab.GetComponents<IFactoryCreatable>().Length > 0)
        {
          inheritsCreatable = true;
        }
        else
        {
          inheritsCreatable = false;
        }
      }
    }
    
    protected override void PerformObjectOnCreate(GameObject Instance)
    {
      IFactoryCreatable[] Creatables = Instance.GetComponents<IFactoryCreatable>();

      foreach(var Creatable in Creatables)
      {
        Creatable.OnCreate();
      }
    }
  }
}
