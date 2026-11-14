using UnityEngine;

// A ScriptableObject: a data asset. Create assets with Create > Creatures > Crawler Stats.
[CreateAssetMenu(fileName = "NewCrawlerStats", menuName = "Creatures/Crawler Stats")]
public class CrawlerStats : ScriptableObject
{
    public string creatureName;
    public float walkSpeed = 1.5f;
    public Color tint = Color.white;
}
