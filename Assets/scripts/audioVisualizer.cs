using UnityEngine;
using System.Collections;

public class audioVisualizer : MonoBehaviour {

    public GameObject prefab;
    public int numberOfObjects = 20;
    public float radius = 5f;
    public GameObject[] cubes;
    public int moveX;
    public int moveY;
    public int moveZ;

    void Start() {
        for (int i = 0; i < numberOfObjects; i++){
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 pos = new Vector3 (Mathf.Cos (angle), 0, Mathf.Sin (angle)) * radius;
            pos = pos + new Vector3 (moveX, moveY, moveZ);
            Instantiate (prefab, pos, Quaternion.identity);
        }
        cubes = GameObject.FindGameObjectsWithTag ("cubes");
    }
    void Update(){
        float[] spectrum = AudioListener.GetSpectrumData (1024, 0, FFTWindow.Hamming);
        for(int i = 0; i<numberOfObjects; i++){
            Vector3 previousScale = cubes[i].transform.localScale;
            previousScale.y = Mathf.Lerp (previousScale.y, spectrum[i] * 40, Time.deltaTime * 30);
            cubes[i].transform.localScale = previousScale;

        }
    }
}
