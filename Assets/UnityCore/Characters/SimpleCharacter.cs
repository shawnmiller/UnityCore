using System;
using UnityEngine;

namespace UnityCore.Characters {
  [RequireComponent(typeof(CharacterController))]
  public abstract class SimpleCharacter : Character {

    protected CharacterController controller;

    public override void Start() {
      base.Start();
      controller = GetComponent<CharacterController>();
    }

    public override void Update() {
      base.Update();

      // Handle air/ground states.
      if (controller.isGrounded) {
        airTime = 0f;
        isInAir = false;
        isJumping = false;
      }
      else {
        airTime += Time.deltaTime;
        isInAir = true;
      }
    }

    public override void Move(Vector3 direction) {
      direction = GetModifiedDirection(direction);
      controller.Move(direction);
    }

    public override void BeginJump() {
      base.BeginJump();
    }

    public override void EndJump() {
      // Intentionally blank. No extended jump feature.
    }

    public override bool IsGrounded() {
      return controller.isGrounded;
    }
  }
}