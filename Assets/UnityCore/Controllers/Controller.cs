
namespace UnityCore.Controllers
{
  public class Controller : CoreBehaviour
  {
    protected Actor ownedActor;


    public void SetActor(Actor newActor)
    {
      if (newActor != ownedActor)
      {
        Actor previousActor = ownedActor;
        ownedActor = newActor;
        
        newActor.SetOwningController(this);
        OnNewOwnedActor(previousActor, newActor);
      }
    }

    protected virtual void OnNewOwnedActor(Actor OldActor, Actor NewActor) { }
    
    // Sealed: The nature of input in Unity is such that using FixedUpdate does not
    // always capture input events correctly.
    public sealed override void FixedUpdate()
    {
      base.FixedUpdate();
    }

    // Sealed: Input should always be handled during the normal Update function. If
    // behaviour is occurring outside of that, then this class is being used outside
    // of its intended use case.
    public sealed override void LateUpdate()
    {
      base.LateUpdate();
    }

    /// <summary>
    /// Primary Update function for controllers using Pull <see cref="ControllerDriverStrategy"/>.
    /// </summary>
    protected virtual void ControllerUpdate() { }
  }
}
