using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    Vector3 targetLastPos;
    Tweener tweener;
    void Start()
    {
        tweener = transform.DOMove(target.position, 2).SetAutoKill(false);
        targetLastPos = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == targetLastPos) return;
        tweener.ChangeEndValue(target.position, true).Restart();
        targetLastPos = target.position;
    }
}
