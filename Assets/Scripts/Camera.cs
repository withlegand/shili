using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float cameraOffsetX = 0f; // 摄像机相对于角色的X轴偏移量  
    [SerializeField] private float cameraOffsetY = 0f; // 摄像机相对于角色的Y轴偏移量  
    [SerializeField] private float leftBoundary = 0f; // 地图左边界  
    [SerializeField] private float rightBoundary = 10f; // 地图右边界  
    [SerializeField] private float bottomBoundary = -5f; // 地图下边界  
    [SerializeField] private float topBoundary = 5f; // 地图上边界  
    [SerializeField] private float cameraWidth = 5f; // 摄像机视野宽度  
    [SerializeField] private float cameraHeight = 3f; // 摄像机视野高度  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float targetX = player.position.x + cameraOffsetX;  
        // 计算摄像机目标位置的Y坐标  
        float targetY = player.position.y + cameraOffsetY;  
  
        // 限制摄像机的X位置在地图边界内  
        targetX = Mathf.Clamp(targetX, leftBoundary + cameraWidth / 2f, rightBoundary - cameraWidth / 2f);  
        // 限制摄像机的Y位置在地图边界内  
        targetY = Mathf.Clamp(targetY, bottomBoundary + cameraHeight / 2f, topBoundary - cameraHeight / 2f);
        Vector3 cameraPosition = new Vector3(targetX, targetY, transform.position.z);  
        transform.position = cameraPosition;  
    }
}
