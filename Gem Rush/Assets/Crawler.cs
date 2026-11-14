using UnityEngine;

// Goes on the Beetle. Patrols left and right using numbers from its CrawlerStats asset.
public class Crawler : MonoBehaviour
{
    [SerializeField] CrawlerStats traits;
    [SerializeField] float roamRange = 2f;

    private Vector3 homeSpot;
    private float direction = 1f;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = traits.tint;
        homeSpot = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector3.right * direction * traits.walkSpeed * Time.deltaTime, Space.World);

        if (transform.position.x > homeSpot.x + roamRange) direction = -1f;
        else if (transform.position.x < homeSpot.x - roamRange) direction = 1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Miner"))
            other.GetComponent<MinerController>().ReturnToStart();
    }
}
