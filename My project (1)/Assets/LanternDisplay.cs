using UnityEngine;

public class LanternDisplay : MonoBehaviour
{
    public LanternData lantern;

    void Start()
    {
        GetComponent<Renderer>().material.color = lantern.glow;
        Debug.Log(lantern.lanternName + " is lit.");
    }
}