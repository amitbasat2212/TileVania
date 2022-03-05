using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
   [SerializeField] float LevelLoadDealy=1f;    
  private void OnTriggerEnter2D(Collider2D other) 
  {
      if(other.tag=="Player"){
        StartCoroutine(LoadNextLevel()); 
      }

    
  }

  IEnumerator LoadNextLevel(){
     
     yield return new WaitForSecondsRealtime(LevelLoadDealy);
      int CureentScene = SceneManager.GetActiveScene().buildIndex;
      int nextSceneIndex =CureentScene+1;
       if(nextSceneIndex==SceneManager.sceneCountInBuildSettings){
           nextSceneIndex=0;
       }

        FindObjectOfType<ScenePresist>().ResrstScenePresist(); 
      SceneManager.LoadScene(nextSceneIndex);
  }
    

}
