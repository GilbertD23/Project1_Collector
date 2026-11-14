using UnityEngine;
using UnityEngine.InputSystem;

public class ParticleBurstOnKey : MonoBehaviour {
    public ParticleSystem ps;
    public int emitCount = 30;

    void Update() {
        if (Keyboard.current == null) return;
        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
            ps.Play();
            Debug.Log("Space pressed: ps.Play()");
        }
        if (Keyboard.current.eKey.wasPressedThisFrame) {
            ps.Emit(emitCount);
            Debug.Log("E pressed: ps.Emit(" + emitCount + ")");
        }
    }
}
