using UnityCore.Controllers;
using UnityCore.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UnityCore {
  public class GameWorld : CoreSingleton<GameWorld> {
    private List<PlayerController> playerControllers;
    private List<Controller> controllers;
    private List<Actor> actors;

    public override void Awake() {
      base.Awake();

      playerControllers = new List<PlayerController>();
      controllers = new List<Controller>();
      actors = new List<Actor>();
    }

    /// <summary>
    /// Adds the <see cref="Controller"/> to the list of known Controllers.
    /// </summary>
    /// <param name="newController">The new <see cref="Controller"/> to add.</param>
    public void AddController(Controller newController) {
      if (newController is PlayerController) {
        playerControllers.AddUnique((PlayerController)newController);
      }

      controllers.AddUnique(newController);
    }

    /// <summary>
    /// Removes the <see cref="Controller"/> from the list of known Controllers.
    /// </summary>
    /// <param name="removeController">The <see cref="Controller"/> to remove.</param>
    public void RemoveController(Controller removeController) {
      if (removeController is PlayerController) {
        playerControllers.Remove((PlayerController)removeController);
      }

      controllers.Remove(removeController);
    }

    /// <summary>
    /// Gets the <see cref="PlayerController"/> for the given index.
    /// </summary>
    /// <param name="index">The index of the controller.</param>
    public PlayerController GetPlayerController(int index) {
      return playerControllers.Where(x => x.GetIndex() == index).First();
    }

    /// <summary>
    /// Gets a read-only collection of all <see cref="PlayerController"/>s.
    /// </summary>
    public ReadOnlyCollection<PlayerController> GetAllPlayerControllers() {
      return playerControllers.AsReadOnly();
    }

    /// <summary>
    /// Get an iterator of all <see cref="PlayerController"/>s.
    /// </summary>
    public IEnumerator<PlayerController> GetPlayerControllerIterator() {
      return playerControllers.GetEnumerator();
    }

    /// <summary>
    /// Gets a read-only collection of all <see cref="Controller"/>s.
    /// </summary>
    public ReadOnlyCollection<Controller> GetAllControllers() {
      return controllers.AsReadOnly();
    }

    /// <summary>
    /// Get an iterator of all <see cref="Controller"/>s. This includes <see cref="PlayerController"/>s
    /// as well as <see cref="AIController"/>s.
    /// </summary>
    public IEnumerator<Controller> GetControllerIterator() {
      return controllers.GetEnumerator();
    }

    /// <summary>
    /// Gets a read-only collection of all <see cref="Actor"/>s.
    /// </summary>
    public ReadOnlyCollection<Actor> GetAllActors() {
      return actors.AsReadOnly();
    }

    /// <summary>
    /// Get an iterator of all <see cref="Actor"/>s.
    /// </summary>
    public IEnumerator<Actor> GetActorIterator() {
      return actors.GetEnumerator();
    }

    /// <summary>
    /// Gets an iterator of all <see cref="Actor"/>s of type T.
    /// </summary>
    /// <typeparam name="T">The type of script to look for.</typeparam>
    public IEnumerator<Actor> GetActorsOfType<T>() {
      return actors.Where(x => x is T).GetEnumerator();
    }
  }
}
