using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePresist : MonoBehaviour
{

    void Awake()
    {
        int numofScenePresist=FindObjectsOfType<ScenePresist>().Length;
        if(numofScenePresist>1){
            Destroy(gameObject);
        }  
        else{
            DontDestroyOnLoad(gameObject);
        }  
    }

    public void ResrstScenePresist(){
        Destroy(gameObject);
    }
    
}
