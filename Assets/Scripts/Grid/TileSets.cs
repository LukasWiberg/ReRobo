using ReTD.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class TileSets : MonoBehaviour {
    public KeyValuePair<TileType, GameObject[]> standard;
    public KeyValuePair<TileType, GameObject[]> grass = new KeyValuePair<TileType, GameObject[]> { };
    public int a = 5;

    public KeyValuePair<TileType, GameObject[]> GetTileSet(TileSet set) {
        switch(set) {
            case TileSet.Standard:
                return standard;
            case TileSet.Grass:
                return grass;

            default:
                return standard;
        }
    }
}

[CustomEditor(typeof(TileSets))]
public class TileSetsEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();

        var m_object = new SerializedObject(target);
        Debug.Log(((TileSets) target).a);
        Debug.Log(m_object.FindProperty("a"));
        EditorGUI.PropertyField(new Rect(0, 60, 550, 60), m_object.FindProperty("a"));
        //GUILayout.MinHeight(500);
        //GUILayout.BeginArea(new Rect(0, 60, 550, 40));
        //if(GUILayout.Button("Generate")) {
            //targetk;
        //}
        //GUILayout.EndArea();

    }
}

[CustomPropertyDrawer(typeof(TileSets))]
public class TileSetsDrawer : PropertyDrawer {
    public override VisualElement CreatePropertyGUI(SerializedProperty property) {
        // Create property container element.
        var container = new VisualElement();

        // Create property fields.
        Debug.Log(property.FindPropertyRelative("stanard"));
        var amountField = new PropertyField(property.FindPropertyRelative("stanard"));
        //var unitField = new PropertyField(property.FindPropertyRelative("unit"));
        //var nameField = new PropertyField(property.FindPropertyRelative("name"), "Fancy Name");

        // Add fields to the container.
        container.Add(amountField);
        //container.Add(unitField);
        //container.Add(nameField);

        return container;
    }
}

public enum TileSet {
    Standard = 0,
    Grass = 1,
}