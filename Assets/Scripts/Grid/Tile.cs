using ReTD.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tile : MonoBehaviour {
    public TileType tileType;
    public ReGrid grid;
    public Vector2 position;

    public void ToggleTileType(TileType nextTileType) {
        grid.ToggleTileType(gameObject, nextTileType);
    }
}

[CanEditMultipleObjects]
[CustomEditor(typeof(Tile))]
public class TileEditor : Editor {

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        Tile tile = (Tile) target;

        bool sameTileType = true;
        TileType currentTileType = ((Tile) target).tileType;
        foreach(Tile t in targets) {
            if(t.tileType != currentTileType) {
                sameTileType = false;
                break;
            }
        }

        if(sameTileType) {
            TileType nextTileType = Enum.IsDefined(typeof(TileType), tile.tileType + 1) ? (tile.tileType + 1) : TileType.Buildable;
            if(GUILayout.Button("Switch to " + nextTileType.ToString())) {
                foreach(Tile t in targets) {
                    t.ToggleTileType(nextTileType);
                }
            }
        }

        if(targets.Length < 2) {
            if(GUILayout.Button("Make Tile Into Base")) {
                tile.grid.MakeTileBase(tile.gameObject);
            }
        }
    }
}