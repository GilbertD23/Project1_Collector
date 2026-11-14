using UnityEngine;

[CreateAssetMenu(fileName = "NewLantern", menuName = "Lanterns/Lantern")]
public class LanternData : ScriptableObject
{
    public string lanternName;
    public Color glow = Color.white;
}