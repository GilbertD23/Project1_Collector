using System.Collections.Generic;
using UnityEngine;

public class SwitchPuzzleController : MonoBehaviour
{
    public int totalSwitches = 3;
    private HashSet<int> activatedSwitches = new HashSet<int>();

    public void ActivateSwitch(int switchId)
    {
        // Add returns false when the ID is already in the set, so a duplicate is ignored
        if (!activatedSwitches.Add(switchId)) return;

        Debug.Log("Switch " + switchId + " activated (" + activatedSwitches.Count + "/" + totalSwitches + ")");

        if (activatedSwitches.Count == totalSwitches)
        {
            Debug.Log("Puzzle solved! Door opening.");
        }
    }
}
