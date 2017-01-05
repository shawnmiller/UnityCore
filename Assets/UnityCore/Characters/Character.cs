using UnityEngine;

namespace UnityCore.Characters {
  public abstract class Character : Actor {

    protected bool useFixedUpdate = false;
    protected float directionDamping = 0f;
    protected float jumpStrength = 18f;

    protected float airTime;
    protected float gravity = 9.81f;
    protected bool isInAir;
    protected bool isJumping;

    /// <summary>
    /// The amount of control to apply when airborn.
    /// 0f for no control, 1f for full control, etc.
    /// </summary>
    protected float airControl = 1f;

    /// <summary>
    /// Move the Character in the given direction.
    /// </summary>
    /// <param name="Direction">The direction to move, adjuested by time.</param>
    public abstract void Move(Vector3 Direction);
    public virtual void BeginJump() { isJumping = true; }
    public virtual void EndJump() { isJumping = false; }
    public abstract bool IsGrounded();

    protected Vector3 GetModifiedDirection(Vector3 direction) {
      if(isInAir) {
        return direction * airControl * (useFixedUpdate ? Time.fixedDeltaTime : Time.deltaTime);
      }
      return direction;
    }
  }
}