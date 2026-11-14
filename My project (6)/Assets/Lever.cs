using UnityEngine;

public class Lever : MonoBehaviour
{
    public int leverId;
    public LeverPuzzle controller;

    private bool pulled = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (pulled) return;
        pulled = true;

        GetComponent<SpriteRenderer>().color = Color.green;
        controller.PullLever(leverId);
    }
}