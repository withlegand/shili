using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnemyMovement : MonoBehaviour
{
    public float speed = 2f; // 敌人的移动速度  
    public float minX = 10f; // 区域的最小x坐标  
    public float maxX = 30f; // 区域的最大x坐标  
    private bool isMovingRight = true; // 初始向右移动 
    private SpriteRenderer sprite; 
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingRight)  
        {  
            sprite.flipX=false;
            transform.Translate(Vector3.right * speed * Time.deltaTime);  
            // 检查是否到达右边界  
            if (transform.position.x >= maxX)  
            {  
                isMovingRight = false;  
                // 可以在这里添加到达右边界时的动作，如改变动画状态等  
            }  
        }  
        else  
        {  
            sprite.flipX=true;
            transform.Translate(Vector3.left * speed * Time.deltaTime);  
            // 检查是否到达左边界  
            if (transform.position.x <= minX)  
            {  
                isMovingRight = true;  
                // 可以在这里添加到达左边界时的动作，如改变动画状态等  
            }  
        }  
    }
}
