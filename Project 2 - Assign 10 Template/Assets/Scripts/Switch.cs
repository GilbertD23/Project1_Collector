using UnityEngine;

public class Switch : MonoBehaviour
{
    public int switchId;
    public SwitchPuzzleController controller;
    public ParticleSystem sparkParticles; // Assign this in the Inspector

    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated) return;
        activated = true;

        GetComponent<SpriteRenderer>().color = Color.green;
        sparkParticles.Play(); // Requirement 7 satisfied
        controller.ActivateSwitch(switchId);
    }
}