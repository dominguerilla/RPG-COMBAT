using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LIMB {
    public class Equipment : ScriptableObject {
        public List<StatBuff> StatBuffs;

        public void AddBuff(StatBuff buff) {
            if(StatBuffs == null)
                StatBuffs = new List<StatBuff>();

            StatBuffs.Add(buff);
        }
    }
}
