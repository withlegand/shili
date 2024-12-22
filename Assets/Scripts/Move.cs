using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator animator;    
    public Rigidbody2D rb2d; 
    // Start is called before the first frame update
    void Start()
    {
       animator = GetComponent<Animator>();  
        rb2d = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey(KeyCode.D))    
        {      
            // 向右移动，设置固定速度  
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);  
            
        }    
        else  
        {  
            
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
        }   
    }
}
