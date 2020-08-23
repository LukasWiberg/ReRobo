using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ReGrid : MonoBehaviour {
    public int gridX, gridY;
    public GameObject tile;
    private GameObject[] grid = null;
    private GameObject gridParent;

    public void Generate() {
        Debug.Log("Generating grid");
        if(transform.Find("Grid Parent")) {
            DestroyImmediate(transform.Find("Grid Parent").gameObject);
        }

        gridParent = new GameObject("Grid Parent");
        gridParent.transform.parent = transform;
        gridParent.transform.position = Vector3.zero;
        gridParent.transform.rotation = Quaternion.identity;


        grid = new GameObject[gridX * gridY];

        for(int y = 0; y < gridY; y++) {
            for(int x = 0; x < gridX; x++) {
                grid[x + (y * gridX)] = Instantiate(tile, new Vector3(x - (gridX / 2) + 0.5f, 0, y - (gridY / 2) + 0.5f), tile.transform.rotation, gridParent.transform);
                grid[x + (y * gridX)].name = "X: " + x + ", Y: " + y;
            }
        }
    }
}

[CustomEditor(typeof(ReGrid))]
public class GridEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        ReGrid grid = (ReGrid) target;

        if(GUILayout.Button("Generate")) {
            grid.Generate();
        }
    }
}