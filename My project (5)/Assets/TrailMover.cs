using UnityEngine;
using UnityEngine.InputSystem;

public class TrailMover : MonoBehaviour {
    public float moveSpeed = 8f;
    public ParticleSystem sparks;
    public int sparkCount = 25;

    void Update() {
        if (Keyboard.current == null) return;
        Vector3 dir = Vector3.zero;
        if (Keyboard.current.upArrowKey.isPressed) dir += Vector3.forward;
        if (Keyboard.current.downArrowKey.isPressed) dir += Vector3.back;
        if (Keyboard.current.rightArrowKey.isPressed) dir += Vector3.right;
        if (Keyboard.current.leftArrowKey.isPressed) dir += Vector3.left;

        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

        if (Keyboard.current.spaceKey.wasPressedThisFrame && sparks != null) {
            sparks.transform.position = transform.position;
            sparks.Emit(sparkCount);
        }
    }
}
