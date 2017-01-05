using UnityCore.Controllers;

namespace UnityCore {
  public class Actor : CoreBehaviour {
    private Controller owningController;

    /// <summary>
    /// Sets the owning <see cref="Controller"/> to the one provided.
    /// </summary>
    /// <param name="newController">The <see cref="Controller"/> to set as the new owner.</param>
    public void SetOwningController(Controller newController) {
      owningController = newController;
    }

    /// <summary>
    /// Clears the owning <see cref="Controller"/> if the one calling this
    /// function is currently our owning <see cref="Controller"/>. Prevents
    /// situations where a new <see cref="Controller"/> has been set before
    /// the previous one is cleared.
    /// </summary>
    /// <param name="callingController">The <see cref="Controller"/> calling this function.</param>
    public void ClearOwningController(Controller callingController) {
      if (callingController == owningController) {
        owningController = null;
      }
    }
  }
}
