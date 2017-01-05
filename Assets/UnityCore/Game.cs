using UnityCore.Collections;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

namespace UnityCore {
  public sealed class Game : CoreSingleton<Game> {
    private List<CoreBehaviour> behaviours;

    public override void Awake() {
      base.Awake();

      behaviours = new List<CoreBehaviour>();
      MakePermanent();
    }

    public void RegisterCoreBehaviour(CoreBehaviour newBehaviour) {
      if (newBehaviour == this) return;

      behaviours.AddUnique(newBehaviour);
    }

    public void UnregisterCoreBehaviour(CoreBehaviour unregisterBehaviour) {
      behaviours.Remove(unregisterBehaviour);
    }

    public IEnumerable<CoreBehaviour> GetScriptsOfType<T>() {
      return behaviours.Where(x => x is T);
    }
  }
}