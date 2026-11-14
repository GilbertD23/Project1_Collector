using UnityEngine;

public class Switch : MonoBehaviour
{
    public int switchId;
    public SwitchPuzzleController controller;

    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated) return;
        activated = true;

        GetComponent<SpriteRenderer>().color = Color.green;
        controller.ActivateSwitch(switchId);
    }
}