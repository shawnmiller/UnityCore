
namespace UnityCore.States {

  /// <summary>
  /// Base class for all states.
  /// </summary>
  public abstract class State {

    /// <summary>
    /// Called when entering a state.
    /// </summary>
    public virtual void Enter(object target = null) { }

    /// <summary>
    /// Called when a state needs to be updated.
    /// </summary>
    public virtual void Update(object target = null) { }

    /// <summary>
    /// Called when exiting a state.
    /// </summary>
    public virtual void Exit(object target = null) { }
  }
}