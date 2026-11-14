using UnityEngine;
using UnityEngine.InputSystem;

public class NoiseTerrainGrid : MonoBehaviour {
    public int width = 30;
    public int depth = 30;
    public float scale = 8f;
    public float heightMultiplier = 8f;
    public float seed = 0f;
    public float waterLevel = 0.40f;
    public float grassLevel = 0.55f;
    public float rockLevel = 0.70f;
    public float detailScale = 3f;
    public float detailWeight = 0.3f;
    private GameObject container;

    void Start() { Generate(); }

    void Generate() {
        if (container == null) {
            container = new GameObject("Terrain Container");
            container.transform.SetParent(transform);
        }
        foreach (Transform child in container.transform) Destroy(child.gameObject);

        for (int x = 0; x < width; x++) {
            for (int z = 0; z < depth; z++) {
                float broad = Mathf.PerlinNoise((x + seed) / scale, (z + seed) / scale);
                float detail = Mathf.PerlinNoise((x + seed) / detailScale, (z + seed) / detailScale);
                float noiseValue = (broad + detail * detailWeight) / (1f + detailWeight);
                
                float shapedNoise = Mathf.Max(noiseValue, waterLevel);
                float height = Mathf.Round(shapedNoise * heightMultiplier);

                GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
                block.name = "Block " + x + "," + z;
                block.transform.SetParent(container.transform);
                block.transform.position = new Vector3(x, height, z);

                Renderer rend = block.GetComponent<Renderer>();
                if (noiseValue < waterLevel) rend.material.color = new Color(0.15f, 0.40f, 0.85f);
                else if (noiseValue < grassLevel) rend.material.color = new Color(0.25f, 0.65f, 0.25f);
                else if (noiseValue < rockLevel) rend.material.color = new Color(0.50f, 0.50f, 0.50f);
                else rend.material.color = Color.white;
            }
        }
        Debug.Log("Generated terrain with seed " + seed.ToString("F1"));
    }

    void Update() {
        if (Keyboard.current == null) return;
        if (Keyboard.current.rKey.wasPressedThisFrame) {
            seed = Random.Range(0f, 1000f);
            Generate();
        }
    }
}
