﻿using ReTD.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ReGrid : MonoBehaviour {
    public int gridX, gridY;
    public GameObject tile;
    public GameObject[] grid = null;
    public GameObject gridParent;
    public GameObject defenseBase;
    public Dictionary<TileType, GameObject> tiles;
    public TileSets tileSets;
    public TileSet set;

    public void Generate() {
        Debug.Log("Generating grid");
        Vector3 oldScale = transform.parent.localScale;
        transform.parent.localScale = Vector3.one;
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
                Tile currentTile = grid[x + (y * gridX)].GetComponent<Tile>();
                currentTile.grid = this;
                currentTile.position = new Vector2Int(x, y);
                ToggleTileType(grid[x + (y * gridX)], TileType.Buildable);
            }
        }
        transform.parent.localScale = oldScale;
    }

    public GameObject ToggleTileType(GameObject oldGo, TileType newTileType) {
        Tile oldTile = oldGo.GetComponent<Tile>();
        Debug.Log(tiles);
        GameObject newGo = grid[oldTile.position.x + (oldTile.position.y * gridX)] = Instantiate(tiles[newTileType], oldGo.transform.position, oldGo.transform.rotation, gridParent.transform);
        newGo.name = oldGo.name;
        Tile newTile = newGo.GetComponent<Tile>();

        if(newTileType == TileType.Base) {
            defenseBase = newGo;
        } else if(oldTile.tileType == TileType.Base && newTileType != TileType.Base) {
            defenseBase = null;
        }

        newTile.grid = this;
        newTile.tileType = newTileType;
        DestroyImmediate(oldGo);
        return newGo;
    }

    public GameObject MakeTileBase(GameObject oldGo) {
        return ToggleTileType(oldGo, TileType.Base);
    }

    public void Validate() {
        tiles = tileSets.GetTileSet(set);
        tile = tiles[TileType.Buildable];
    }

    private void OnValidate() {
        Validate();
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(ReGrid))]
public class GridEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        ReGrid grid = (ReGrid) target;

        if(GUILayout.Button("Generate")) {
            grid.Validate();
            grid.Generate();
        }
    }
}
#endif