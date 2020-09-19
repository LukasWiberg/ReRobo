using Assets.Scripts.General;
using ReTD.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTileUIScript : MonoBehaviour {
    public InteractableUI interactableUI;
    private Tile tile;
    private TileType nextTileType;

    private void Start() {
        tile = Helpers.GetTypeInParents<Tile>(interactableUI.target.transform);
        UpdateText();
    }

    public void Invoke() {
        tile.ToggleTileType(nextTileType);
        UpdateText();
    }

    private void UpdateText() {
        nextTileType = Enum.IsDefined(typeof(TileType), tile.tileType + 1) ? (tile.tileType + 1) : TileType.Buildable;
        if(nextTileType == TileType.Base && tile.grid.defenseBase) {
            nextTileType += 1;
        }
        interactableUI.text.text = "Switch to " + nextTileType.ToString();
    }
}
