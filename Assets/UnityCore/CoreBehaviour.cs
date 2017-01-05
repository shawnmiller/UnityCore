using System;
using UnityCore.Factory;
using UnityEngine;

namespace UnityCore {
  public abstract class CoreBehaviour : MonoBehaviour, IFactoryCreatable {
    #region Unity Component Storage
    protected Animation c_animation {
      get {
        if (!cAnimation) {
          cAnimation = GetComponent<Animation>();
        }
        return cAnimation;
      }
    }
    private Animation cAnimation;

    protected Rigidbody c_rigidbody {
      get {
        if (!cRigidbody) {
          cRigidbody = GetComponent<Rigidbody>();
        }
        return cRigidbody;
      }
    }
    private Rigidbody cRigidbody;

    protected Rigidbody2D c_rigidbody2D {
      get {
        if (!cRigidbody2D) {
          cRigidbody2D = GetComponent<Rigidbody2D>();
        }
        return cRigidbody2D;
      }
    }
    private Rigidbody2D cRigidbody2D;

    protected Collider c_collider {
      get {
        if (!cCollider) {
          cCollider = GetComponent<Collider>();
        }
        return cCollider;
      }
    }
    private Collider cCollider;

    protected Collider2D c_collider2D {
      get {
        if (!cCollider2D) {
          cCollider2D = GetComponent<Collider2D>();
        }
        return cCollider2D;
      }
    }
    private Collider2D cCollider2D;

    protected AudioSource c_audio {
      get {
        if (!cAudio) {
          cAudio = GetComponent<AudioSource>();
        }
        return cAudio;
      }
    }
    private AudioSource cAudio;

    protected Camera c_camera {
      get {
        if (!cCamera) {
          cCamera = GetComponent<Camera>();
        }
        return cCamera;
      }
    }
    private Camera cCamera;

    protected Renderer c_renderer {
      get {
        if (!cRenderer) {
          cRenderer = GetComponent<Renderer>();
        }
        return cRenderer;
      }
    }
    private Renderer cRenderer;
    #endregion

    public virtual void Awake() {
      Game.Get().RegisterCoreBehaviour(this);
    }
    public virtual void Start() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void LateUpdate() { }

    public virtual void OnPlayBegin() { }
    public virtual void OnPlayEnd() { }

    public virtual void OnPause() { }
    public virtual void OnResume() { }

    public virtual void OnDestroy() {
      Game.SafeGet()?.UnregisterCoreBehaviour(this);
    }

    private void RegisterBehaviour() {
      Game.Get().RegisterCoreBehaviour(this);
    }

    private void UnregisterBehaviour() {
      Game.SafeGet()?.UnregisterCoreBehaviour(this);
    }

    public virtual void OnCreate() {
      this.enabled = false;
    }
  }
}
