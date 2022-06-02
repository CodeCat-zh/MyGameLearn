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
        // ��ȡ��ǰ�����zֵ
        float distance = mainCamera.WorldToScreenPoint(owner.position).z;
        // ����ֵ������x,y������������
        Vector3 currentPos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));

        offset = owner.position - currentPos;
    }

    private void OnMouseDrag()
    {

        // ��ȡ��ǰ�����zֵ
        float distance = mainCamera.WorldToScreenPoint(owner.position).z;
        // ����ֵ������x,y������������
        Vector3 currentPos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
        //���µ�ǰ�����zֵ
        owner.position = currentPos + offset;
    }
}
