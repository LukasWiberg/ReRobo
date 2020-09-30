using ReTD.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour {
    public GameObject window;
    public void ExitWindow() {
        Helpers.GetGameManager().HideUI(window);
    }
}
