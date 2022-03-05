using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSessiom : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI LIVEStEXT;
     public TextMeshProUGUI ScoreText;
    [SerializeField] int plaerLives=4;
    [SerializeField] int Score =0;

    // Start is called before the first frame update
    void Awake()
    {
        int numGameSessions=FindObjectsOfType<GameSessiom>().Length;
        if(numGameSessions>1){
            Destroy(gameObject);
        }  
        else{
            DontDestroyOnLoad(gameObject);
        }  
    }

    private void Start() {
        LIVEStEXT.text = plaerLives.ToString();
        ScoreText.text = Score.ToString();

    }

    
    public void ProcessPlayerDeath(){
        if(plaerLives>1){
           TakeLives();     
        }else{
            ResttGameAll();
        }
    }

    public void AddScore(int PointScore){
        Score+=PointScore;
        ScoreText.text = Score.ToString();
    }

    private void TakeLives()
    {
      plaerLives--;
      int CureentScene = SceneManager.GetActiveScene().buildIndex;
      SceneManager.LoadScene(CureentScene);
      LIVEStEXT.text = plaerLives.ToString();
     
    }

    private void ResttGameAll()
    {
         FindObjectOfType<ScenePresist>().ResrstScenePresist(); 
        SceneManager.LoadScene(0);
         Destroy(gameObject);
        
    }
}
