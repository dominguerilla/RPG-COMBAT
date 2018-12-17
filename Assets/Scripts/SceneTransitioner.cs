using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// Executes the transition between the field and a battle.
/// Initializes battle 'stage', instantiates the combatant models, destroys stage after battle ends.
/// </summary>
public class SceneTransitioner : MonoBehaviour {
    
    public Transform scenePosition;
    [SerializeField]
    Image battleStartFadeImage;
    [SerializeField]
    Image battleEndFadeImage;
    
    /// <summary>
    /// Called when the scene STARTS to fade in FROM black, during the transition from field to battle.
    /// </summary>
    public UnityEvent BeginTransitionStarted;

    /// <summary>
    /// Called when the scene STARTS to fade TO black, during the transition from battle to field.
    /// </summary>
    public UnityEvent EndTransitionStarted;

    [SerializeField]
    float fadeSpeed = 1.0f;

    GameObject activeBattleScene;
    Camera battleCam, returnCam;
    Light battleLight, returnLight;

    private void Awake() {
        BeginTransitionStarted = new UnityEvent();
        EndTransitionStarted = new UnityEvent();
    }

    public void CreateBattleScene(Combatant[] leftParty, Combatant[] rightParty, GameObject battleScene, Camera returnCam = null, Light returnLight = null){
        StartCoroutine(InitializeBattleScene(leftParty, rightParty, battleScene, returnCam, returnLight));
    }

    // TODO Make it so that it initializes a battle scene that already exists in the Scene.
    // That way, we don't have to instantiate a new one every battle
    IEnumerator InitializeBattleScene(Combatant[] leftParty, Combatant[] rightParty, GameObject battleScene, Camera returnCam = null, Light returnLight = null){
        yield return StartCoroutine(FadeImage(battleStartFadeImage, 1.0f));
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

        Transform[] leftPositions = GetPositions(leftPartyParent);
        SpawnParty(leftParty, leftPositions, leftPartyParent.transform);

        Transform[] rightPositions = GetPositions(rightPartyParent);
        SpawnParty(rightParty, rightPositions, rightPartyParent.transform);

        BeginTransitionStarted.Invoke();
        yield return StartCoroutine(FadeImage(battleStartFadeImage, 0.0f));
    }

    public void DestroyBattleScene(){
        StartCoroutine(TakeDownBattleScene());
    }

    IEnumerator TakeDownBattleScene(){
        EndTransitionStarted.Invoke();
        BeginTransitionStarted.RemoveAllListeners();
        yield return StartCoroutine(FadeImage(battleEndFadeImage, 1.0f));
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
        EndTransitionStarted.RemoveAllListeners();
        yield return StartCoroutine(FadeImage(battleEndFadeImage, 0.0f));
    }

    IEnumerator FadeImage(Image image, float alpha){
        if(image != null){
            if(image.color.a < alpha){
                while(image.color.a < alpha){
                    var tempColor = image.color;
                    tempColor.a += Time.deltaTime * fadeSpeed;
                    image.color = tempColor;
                    yield return new WaitForEndOfFrame();
                }
            }else if(image.color.a > alpha){
                while(image.color.a > alpha){
                    var tempColor = image.color;
                    tempColor.a -= Time.deltaTime * fadeSpeed;
                    image.color = tempColor;
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
            Combatant combatant = party[i];
            GameObject newObj = GameObject.Instantiate<GameObject>(
                combatant.GetData().GetModel(), 
                positions[i].transform.position,
                positions[i].transform.rotation,
                parent );
            combatant.SetGameObject(newObj);
            combatant.InitializeCombatantComponents();
            BeginTransitionStarted.AddListener(delegate { combatant.PlayAnimation("OnSpawn"); });
            EndTransitionStarted.AddListener(delegate { combatant.PlayAnimation("OnDeath"); });
        }
    }
}
