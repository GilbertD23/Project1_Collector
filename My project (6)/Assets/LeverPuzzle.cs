using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzle : MonoBehaviour
{
    public int totalLevers = 3;
    private HashSet<int> pulledLevers = new HashSet<int>();

    public void PullLever(int leverId)
    {
        // Add returns false when the ID is already in the set, so a duplicate is ignored
        if (!pulledLevers.Add(leverId)) return;

        Debug.Log("Lever " + leverId + " pulled (" + pulledLevers.Count + "/" + totalLevers + ")");

        if (pulledLevers.Count == totalLevers)
        {
            Debug.Log("Puzzle solved! Dam opening.");
        }
    }
}