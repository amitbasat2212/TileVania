using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    PlayerMovment player;
    Rigidbody2D Myrigirbody;
    [SerializeField] float BulletSpeed=20f;

    float Xspeed;



    // Start is called before the first frame update
    void Start()
    {
        Myrigirbody=GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovment>();
        Xspeed = player.transform.localScale.x*BulletSpeed;
    
    }

    // Update is called once per frame
    void Update()
    {
        Myrigirbody.velocity=new Vector2(Xspeed,0f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Enemy"){
           Destroy(other.gameObject);     
          
        }
         Destroy(gameObject);
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
