using UnityEngine;

namespace UnityCore.Characters {
  public abstract class PhysicsCharacter : Character {

    public override void Move(Vector3 Direction) {
      throw new System.NotImplementedException();
    }

    public override bool IsGrounded() {
      throw new System.NotImplementedException();
    }
  }
}