using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LIMB {
    /// <summary>
    /// Uses Singleton pattern.
    /// </summary>
    public class BattleManager : MonoBehaviour {
        
        private static BattleManager _instance;
        public static BattleManager Instance { get { return _instance; } }

        SceneTransitioner transitioner;
        bool inBattle;
        Combatant[] lCombatants, rCombatants;

        private void Awake() {
            if(_instance != null && _instance != this) {
                Destroy(this);
            }else {
                _instance = this;
            }

            transitioner = GetComponent<SceneTransitioner>();
        }

        public void StartBattle(NPCParty leftParty, NPCParty rightParty, GameObject battleScenePrefab){
            if(!inBattle){
                inBattle = true;
                lCombatants = GenerateCombatants(leftParty);
                rCombatants = GenerateCombatants(rightParty);

                Debug.Log("Battle started!");
                transitioner.CreateBattleScene(lCombatants, rCombatants, battleScenePrefab);
            }
        }

        public void EndBattle(){
            if(inBattle){
                inBattle = false;
                Debug.Log("Battle ended!");
                transitioner.DestroyBattleScene();
                lCombatants = null;
                rCombatants = null;
            }
        }

        Combatant[] GenerateCombatants(NPCParty party){
            CombatantData[] data = party.GetData();
            Combatant[] combatants = new Combatant[data.Length];
            for (int i = 0; i < combatants.Length; i++){
                
                Combatant combatant = new Combatant(data[i]);
                combatants[i] = combatant;
            }
            return combatants;
        }

        public Combatant[] GetLeftCombatants() {
            return this.lCombatants;
        }

        public Combatant[] GetRightCombatants() {
            return this.rCombatants;
        }
    }
}
