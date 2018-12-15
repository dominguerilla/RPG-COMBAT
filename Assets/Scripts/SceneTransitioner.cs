using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Executes the transition between the field and a battle.
/// Initializes battle 'stage', instantiates the combatant models, destroys stage after battle ends.
/// </summary>
public class SceneTransitioner : MonoBehaviour {
    
    public Transform scenePosition;
    public Image battleFadeImage;
    [SerializeField]
    float fadeSpeed = 1.0f;

    GameObject activeBattleScene;
    Camera battleCam, returnCam;
    Light battleLight, returnLight;

    public void CreateBattleScene(Combatant[] leftParty, Combatant[] rightParty, GameObject battleScene, Camera returnCam = null, Light returnLight = null){
        StartCoroutine(InitializeBattleScene(leftParty, rightParty, battleScene, returnCam, returnLight));
    }

    // TODO Make it so that it initializes a battle scene that already exists in the Scene.
    // That way, we don't have to instantiate a new one every battle
    IEnumerator InitializeBattleScene(Combatant[] leftParty, Combatant[] rightParty, GameObject battleScene, Camera returnCam = null, Light returnLight = null){
        yield return StartCoroutine(FadeImage(1.0f));
        GameObject newScene = Instantiate(battleScene, scenePosition.position, scenePosition.rotation) as GameObject;
        activeBattleScene = newScene;

        GameObject leftPartyParent = newScene.transform.Find("LeftParty").gameObject;
        GameObject rightPartyParent = newScene.transform.Find("RightParty").gameObject;
        
        // Initialize camera
        this.battleCam = newScene.GetComponentInChildren<Camera>();
        this.battleCam.enabled = true;
        this.returnCam = returnCam;
        if(this.returnCam){
            this.returnCam.enabled = false;
        }

        // Initialize lights
        // Assumes there's only one light in battleScene, and one return light
        this.battleLight = newScene.GetComponentInChildren<Light>();
        if(this.battleLight){
            this.battleLight.enabled = true;
        }
        this.returnLight = returnLight;
        if(this.returnLight){
            this.returnLight.enabled = false;
        }

        yield return StartCoroutine(FadeImage(0.0f));
        Transform[] leftPositions = GetPositions(leftPartyParent);
        SpawnParty(leftParty, leftPositions, leftPartyParent.transform);

        Transform[] rightPositions = GetPositions(rightPartyParent);
        SpawnParty(rightParty, rightPositions, rightPartyParent.transform);
        yield return null;
    }

    public void DestroyBattleScene(){
        StartCoroutine(TakeDownBattleScene());
    }

    IEnumerator TakeDownBattleScene(){
        yield return StartCoroutine(FadeImage(1.0f));
        if(returnCam){
            returnCam.enabled = true;
            returnCam = null;
        }
        if(returnLight){
            returnLight.enabled = true;
            returnLight = null;
        }

        if(battleCam){
            battleCam.enabled = false;
            battleCam = null;
        }

        if(battleLight){
            battleLight.enabled = false;
            battleLight = null;
        }

        Destroy(activeBattleScene);
        activeBattleScene = null;
        yield return StartCoroutine(FadeImage(0.0f));
        yield return null;
    }

    IEnumerator FadeImage(float alpha){
        if(battleFadeImage != null){
            if(battleFadeImage.color.a < alpha){
                while(battleFadeImage.color.a < alpha){
                    var tempColor = battleFadeImage.color;
                    tempColor.a += Time.deltaTime * fadeSpeed;
                    battleFadeImage.color = tempColor;
                    yield return new WaitForEndOfFrame();
                }
            }else if(battleFadeImage.color.a > alpha){
                while(battleFadeImage.color.a > alpha){
                    var tempColor = battleFadeImage.color;
                    tempColor.a -= Time.deltaTime * fadeSpeed;
                    battleFadeImage.color = tempColor;
                    yield return new WaitForEndOfFrame();
                }

            }
        }
    }

    Transform[] GetPositions(GameObject parentObj){
        List<Transform> positions = new List<Transform>();
        foreach (Transform t in parentObj.transform){
            if(t.gameObject.name.StartsWith("Position")){
                positions.Add(t);
            }
        }
        return positions.ToArray();
    }

    void SpawnParty(Combatant[] party, Transform[] positions, Transform parent = null){
        for(int i = 0; i < party.Length; i++){
            if(i >= positions.Length){
                break;
            }
            GameObject.Instantiate<GameObject>(
                party[i].GetData().GetModel(), 
                positions[i].transform.position,
                positions[i].transform.rotation,
                parent );
        }
    }
}
