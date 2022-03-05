using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MovmentEnemy : MonoBehaviour
{
    [SerializeField] float MoveSpeed=1f;
    Rigidbody2D MyEnemy;
    // Start is called before the first frame update
    void Start()
    {

        MyEnemy=GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MyEnemy.velocity=new Vector2(MoveSpeed,0f);

    }

   private void OnTriggerExit2D(Collider2D other) {
        MoveSpeed=-MoveSpeed;
        FlipEmamyFacing();
   }

   void FlipEmamyFacing(){
      
            transform.localScale = new Vector2 (-(Mathf.Sign(MyEnemy.velocity.x)), 1f);
       
   }
}
