using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPickup : MonoBehaviour
{
    //    
    [SerializeField] AudioClip coinPicUp;
    [SerializeField]int coin=100;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Player")
        {      
            AudioSource.PlayClipAtPoint(coinPicUp,Camera.main.transform.position);  
            
            FindObjectOfType<GameSessiom>().AddScore(coin);  
            Destroy(gameObject);
          
        }
    }
}
