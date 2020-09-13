using ReTD.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tile : MonoBehaviour {
    public TileType tileType;
    public ReGrid grid;
    public Vector2Int position;

    public GameObject ToggleTileType(TileType nextTileType) {
        return grid.ToggleTileType(gameObject, nextTileType);
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
            if(nextTileType == TileType.Base && (targets.Length>1 || tile.grid.defenseBase)) {
                nextTileType+=1;
            }


            if(GUILayout.Button("Switch to " + nextTileType.ToString())) {
                List<GameObject> newSelection = new List<GameObject>();
                foreach(Tile t in targets) {
                    newSelection.Add(t.ToggleTileType(nextTileType));
                }
                Selection.objects = newSelection.ToArray();
            }
        }

        if(targets.Length < 2 && !tile.grid.defenseBase) {
            if(GUILayout.Button("Make Tile Into Base")) {
                Selection.activeGameObject = tile.grid.MakeTileBase(tile.gameObject);
            }
        }
    }
}