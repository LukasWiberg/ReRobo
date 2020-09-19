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

        public static T GetTypeInParents<T>(Transform transform) {
            T ret = transform.GetComponent<T>(); 
            if(ret == null) {
                if(!transform.parent) {
                    throw new Exception("Could not find object of type: " + typeof(T));
                }
                ret = GetTypeInParents<T>(transform.parent);
            }
            return ret;
        }
    }
}
