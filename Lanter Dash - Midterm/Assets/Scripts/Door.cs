using System.Collections.Generic;
using UnityEngine;

// Goes on the Door. Remembers which switches are on and slides up when all are.
public class Door : MonoBehaviour
{
    [SerializeField] int totalSwitches = 2;
    [SerializeField] float openHeight = 6.5f;
    [SerializeField] float openSpeed = 3f;

    private HashSet<int> activatedSwitches = new HashSet<int>();
    private Vector3 closedPosition;
    private bool opening = false;

    private void Start()
    {
        closedPosition = transform.position;
    }

    public void ActivateSwitch(int switchId)
    {
        // Add returns false when the ID is already in the set, so a duplicate is ignored.
        if (!activatedSwitches.Add(switchId)) return;

        Debug.Log("Switch " + switchId + " activated (" + activatedSwitches.Count + "/" + totalSwitches + ")");
        if (activatedSwitches.Count == totalSwitches) opening = true;
    }

    private void Update()
    {
        if (!opening) return;

        Vector3 target = closedPosition + Vector3.up * openHeight;
        transform.position = Vector3.MoveTowards(transform.position, target, openSpeed * Time.deltaTime);
    }
}
