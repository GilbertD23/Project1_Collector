using UnityEngine;

[CreateAssetMenu(fileName = "NewCollectibleData", menuName = "ScriptableObjects/CollectibleData")]
public class CollectibleData : ScriptableObject
{
    [Header("Collectible Settings")]
    public int coinValue = 10; 
}