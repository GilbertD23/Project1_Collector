using UnityEngine;

public class NoiseTerrainRow : MonoBehaviour {
    public int width = 20;
    public float scale = 5f;
    public float heightMultiplier = 6f;

    void Start() {
        for (int x = 0; x < width; x++) {
            float noiseValue = Mathf.PerlinNoise(x / scale, 0f);
            Debug.Log("x = " + x + "  noise = " + noiseValue.ToString("F3"));
            float height = noiseValue * heightMultiplier;
            GameObject block = GameObject.CreatePrimitive(PrimitiveType.Cube);
            block.name = "Block " + x;
            block.transform.SetParent(transform);
            block.transform.position = new Vector3(x, height, 0f);
        }
    }
}
