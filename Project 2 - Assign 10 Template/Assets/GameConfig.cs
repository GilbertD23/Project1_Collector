using UnityEngine;

[CreateAssetMenu(menuName = "Game/LevelConfig")]
public class GameConfig : ScriptableObject
{
    public float timeLimit;
    public string levelName;
}