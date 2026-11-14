using UnityEngine;
using UnityEngine.InputSystem;

public class KiteWind : MonoBehaviour
{
    public Animator animator;
    bool wasFlying;

    void Update()
    {
        if (Keyboard.current == null) return;

        bool isFlying = Keyboard.current.upArrowKey.isPressed
                     || Keyboard.current.downArrowKey.isPressed;

        if (isFlying != wasFlying)
        {
            Debug.Log(isFlying ? "Wind started" : "Wind stopped");
            wasFlying = isFlying;
        }

        animator.SetBool("IsFlying", isFlying);
    }
}
