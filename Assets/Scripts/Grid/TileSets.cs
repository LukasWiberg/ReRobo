using ReTD.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class TileSets : MonoBehaviour {
    public GameObject[] standard = new GameObject[Enum.GetNames(typeof(TileType)).Length];
    public GameObject[] grass = new GameObject[Enum.GetNames(typeof(TileType)).Length];
    public GameObject[] metal = new GameObject[Enum.GetNames(typeof(TileType)).Length];

    public Dictionary<TileType, GameObject> GetTileSet(TileSet set) {
        switch(set) {
            case TileSet.Standard:
                return GenerateTileSet(standard);
            case TileSet.Grass:
                return GenerateTileSet(grass);
            case TileSet.Metal:
                return GenerateTileSet(metal);

            default:
                return GenerateTileSet(standard);
        }
    }

    private Dictionary<TileType, GameObject> GenerateTileSet(GameObject[] tiles) {
        Dictionary<TileType, GameObject> ret = new Dictionary<TileType, GameObject>();
        int i = 0;
        foreach(TileType tt in Enum.GetValues(typeof(TileType))) {
            ret.Add(tt, tiles[i]);
            i++;
        }
        return ret;
    }
}

public enum TileSet {
    Standard = 0,
    Grass = 1,
    Metal = 2
}