using UnityEngine;

// A ScriptableObject: a data asset. Create assets with Create > Enemies > Enemy Stats.
[CreateAssetMenu(fileName = "NewEnemyStats", menuName = "Enemies/Enemy Stats")]
public class EnemyStats : ScriptableObject
{
    public string enemyName;
    public float moveSpeed = 1.5f;
    public Color color = Color.white;
}
