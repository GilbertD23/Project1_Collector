using UnityEngine;

public class FlareEvent : MonoBehaviour
{
    public Renderer lamp;

    public void Flare(int brightness)
    {
        if (lamp == null)
        {
            Debug.LogWarning("FlareEvent needs a Lamp renderer.");
            return;
        }

        lamp.material.color = Color.yellow;
        Debug.Log("Flare! Brightness " + brightness);
    }
}
