using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMove : MonoBehaviour
{
    Transform owner;
    Camera mainCamera;
    Vector3 offset;

    private void Start()
    {
        owner = this.transform;
        mainCamera = Camera.main;

    }
    private void OnMouseDown()
    {
        // 获取当前物体的z值
        float distance = mainCamera.WorldToScreenPoint(owner.position).z;
        // 根据值和鼠标的x,y生成世界坐标
        Vector3 currentPos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));

        offset = owner.position - currentPos;
    }

    private void OnMouseDrag()
    {

        // 获取当前物体的z值
        float distance = mainCamera.WorldToScreenPoint(owner.position).z;
        // 根据值和鼠标的x,y生成世界坐标
        Vector3 currentPos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
        //更新当前物体的z值
        owner.position = currentPos + offset;
    }
}
