using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;  
  
    // 假设你有两个Sprite资源，一个表示关闭的宝箱，一个表示打开的宝箱  
    public Sprite closedSprite;  
    public Sprite openSprite;  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)  
    {  
        // 检查是否碰到了玩家（或其他能够打开宝箱的对象）  
        if (other.CompareTag("Player")) // 假设玩家带有"Player"标签  
        {  
            // 如果宝箱当前是关闭的，就打开它  
             
             
                OpenChest();  
             
        }  
    }  
    private void OpenChest()  
    {  
        // 切换宝箱的贴图到打开的贴图  
        spriteRenderer.sprite = openSprite;  
  
        // 标记宝箱为已打开  
        
  
        // 在这里可以添加其他逻辑，比如播放音效、掉落物品等  
    }  
}
