using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    public Transform ladder; // 假设你有一个指向梯子的Transform引用  
    public float climbSpeed = 5f; // 攀爬速度  
  
    private bool isOnLadder = false; // 是否在梯子上  
    private Vector3 climbDirection = Vector3.zero; // 攀爬方向  
    private BoxCollider2D boxCollider;  
    public Rigidbody2D rb; // 引用角色的Rigidbody2D组件  
    public Collider2D[] obstacleCollidersToIgnore; // 存储需要忽略的障碍物碰撞体 

    private void OnTriggerEnter2D(Collider2D collision)  
    {  
        // 假设梯子有一个特定的标签，如"Ladder"  
        if (collision.gameObject.CompareTag("Ladder"))  
        {  
            isOnLadder = true;  
            rb.gravityScale = 0f; // 当在梯子上时，禁用重力 
            foreach (Collider2D obstacleCollider in obstacleCollidersToIgnore)  
        {  
            if (obstacleCollider != null)  
            {  
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), obstacleCollider, true);  
            }  
        }   
        }  
    }  
  
    private void OnTriggerExit2D(Collider2D collision)  
    {  
        if (collision.gameObject.CompareTag("Ladder"))  
        {  
            isOnLadder = false;  
            climbDirection = Vector3.zero; // 重置攀爬方向  
            rb.gravityScale = 1f; // 当离开梯子时，重新启用重力 
            foreach (Collider2D obstacleCollider in obstacleCollidersToIgnore)  
        {  
            if (obstacleCollider != null)  
            {  
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), obstacleCollider, false);  
            }  
        }   
        }  
    }  
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>(); 
        rb = GetComponent<Rigidbody2D>(); // 获取Rigidbody2D组件  
    }

    // Update is called once per frame
    private void Update()
    {
        if (isOnLadder)  
        {  
            // 检测W和S键的输入  
            if (Input.GetKey(KeyCode.E))  
            {  
                climbDirection = Vector3.up; // 向上攀爬  
            }  
            else if (Input.GetKey(KeyCode.S))  
            {  
                climbDirection = Vector3.down; // 向下攀爬  
            }  
            else  
            {  
                climbDirection = Vector3.zero; // 不按任何键时停止攀爬  
            }  
  
            // 根据攀爬方向和速度移动角色  
            Vector2 velocity = rb.velocity;  
            velocity.y = (Input.GetKey(KeyCode.E) ? climbSpeed : 0) - (Input.GetKey(KeyCode.S) ? climbSpeed : 0);  
            rb.velocity = velocity; 
  
            // 这里可以添加代码来确保角色保持在梯子上，例如通过射线投射或检查角色的Y坐标是否在梯子的范围内  
        }  
    }  
    
}

