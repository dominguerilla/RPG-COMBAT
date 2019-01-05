using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private static CameraController _instance;
    public static CameraController Instance { get {return _instance; } }

    Camera mainCamera, currentCamera;

    private void Awake() {
        if(_instance != null && _instance != this){
            Destroy(this);
        }else{
            _instance = this;
        }

        mainCamera = Camera.main;    
    }
    
    /// <summary>
    /// Sets the active camera to the specified one. 
    /// </summary>
    public void SetActiveCamera(Camera cam){
        if(this.currentCamera){
            this.currentCamera.enabled = false;
        }
        this.currentCamera = cam;
        this.currentCamera.enabled = true;
    }

    /// <summary>
    /// Disables the currentCamera and re-enables the main camera.
    /// </summary>
    public void ResetActiveCamera(){
        if(this.currentCamera){
            this.currentCamera.enabled = false;
        }
        this.currentCamera = mainCamera;
        this.currentCamera.enabled = true;
    }

}
