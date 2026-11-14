using System.Collections.Generic;
using UnityEngine;

// Goes on the Gate. Remembers which levers are pulled and lifts when all are.
public class Gate : MonoBehaviour
{
    [SerializeField] int totalLevers = 2;
    [SerializeField] float liftHeight = 6.5f;
    [SerializeField] float liftSpeed = 3f;

    private HashSet<int> pulledLevers = new HashSet<int>();
    private Vector3 shutPosition;
    private bool lifting = false;

    private void Start()
    {
        shutPosition = transform.position;
    }

    public void PullLever(int leverId)
    {
        // Add returns false when the ID is already in the set, so a duplicate is ignored.
        if (!pulledLevers.Add(leverId)) return;

        Debug.Log("Lever " + leverId + " pulled (" + pulledLevers.Count + "/" + totalLevers + ")");
        if (pulledLevers.Count == totalLevers) lifting = true;
    }

    private void Update()
    {
        if (!lifting) return;

        Vector3 target = shutPosition + Vector3.up * liftHeight;
        transform.position = Vector3.MoveTowards(transform.position, target, liftSpeed * Time.deltaTime);
    }
}
