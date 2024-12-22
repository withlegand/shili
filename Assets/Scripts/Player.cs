using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
  
public class Player : MonoBehaviour  
{    
    private Animator animator;    
    public Rigidbody2D rb2d; // 引用Rigidbody2D组件   
    public float jumpForce = 0.0000005f; // 设置为public，以便在Inspector中调整  
    public float moveSpeed = 5f; // 角色的移动速度   // 角色的移动速度
    private bool isJumping = false; // 使用isJumping代替IsJump，以避免大小写混淆  
    private bool isGrounded = true;  
  
    void Start()    
    {    
        // 获取Animator组件    
        animator = GetComponent<Animator>();  
        rb2d = GetComponent<Rigidbody2D>();   
        // 移除这些行，因为你没有使用它们，并且它们会覆盖类的成员变量  
        // bool IsAction = animator.GetBool("IsAction");  
        // bool IsRun = animator.GetBool("IsRun");  
        // bool IsJump = animator.GetBool("IsJump"); // 这里不应该再次声明IsJump  
    }    
    
    void Update()    
    {    
        



        // 检测D键是否被按下    
        if (Input.GetKey(KeyCode.D))    
        {      
            animator.SetBool("IsRun", true); 
            // 向右移动，设置固定速度  
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);  
            
        }    
        else  
        {  
            animator.SetBool("IsRun", false);  
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
        }  
  
        if (isGrounded && !isJumping && Input.GetKeyDown(KeyCode.W))  // 使用isGrounded和isJumping  
        {    
            animator.SetBool("IsRun", false);  
            animator.SetBool("IsJump", true);  
            isJumping = true; // 更新isJumping的状态  
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);  
        }    
    }    
      
    private void OnCollisionEnter2D(Collision2D collision)    
    {    
        // 假设您已经给地面碰撞器设置了一个特定的标签，例如"Ground"    
        if (collision.collider.CompareTag("Ground"))    
        {    
            isGrounded = true;    
            if (isJumping) // 使用isJumping  
            {    
                animator.SetBool("IsJump", false);    
                isJumping = false; // 更新isJumping的状态  
            }    
        }    
    }    
      
    // 当玩家与地面分离时触发    
    private void OnCollisionExit2D(Collision2D collision)    
    {    
        // 假设您已经给地面碰撞器设置了一个特定的标签，例如"Ground"    
        if (collision.collider.CompareTag("Ground"))    
        {    
            isGrounded = false;    
            // 如果玩家在跳跃时离开地面，你可以在这里开始跳跃动画（如果需要的话）  
        }    
    }    
}