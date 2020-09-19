using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.General {
    class Helpers {
        public static GameManager GetGameManager() {
            return GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        }
    }
}
