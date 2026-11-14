using UnityEngine;
using UnityEngine.InputSystem;

public class SimpleLevelGenerator : MonoBehaviour {
    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public int gridSize = 20;
    public float scale = 4f;
    public float wallThreshold = 0.55f;
    public float seed = 0f;
    private GameObject container;

    void Start() { Generate(); }

    void Generate() {
        if (container == null) {
            container = new GameObject("Level Container");
            container.transform.SetParent(transform, false);
        }
        foreach (Transform child in container.transform) Destroy(child.gameObject);

        int walls = 0;
        int floors = 0;
        for (int x = 0; x < gridSize; x++) {
            for (int z = 0; z < gridSize; z++) {
                float noise = Mathf.PerlinNoise((x + seed) / scale, (z + seed) / scale);
                GameObject prefab = noise > wallThreshold ? wallPrefab : floorPrefab;
                if (noise > wallThreshold) walls++; else floors++;

                GameObject tile = Instantiate(prefab, container.transform);
                tile.transform.localPosition = new Vector3(x, 0f, z);
            }
        }
        Debug.Log("Level built with seed " + seed.ToString("F1") + ". Walls: " + walls + "  Floors: " + floors);
    }

    void Update() {
        if (Keyboard.current == null) return;
        if (Keyboard.current.rKey.wasPressedThisFrame) {
            seed = Random.Range(0f, 1000f);
            Generate();
        }
    }
}
