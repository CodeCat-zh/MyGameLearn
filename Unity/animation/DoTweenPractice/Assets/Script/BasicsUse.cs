using System.Collections;
using UnityEngine;
using DG.Tweening;
public class BasicsUse : MonoBehaviour
{
    public Transform redCube, greenCube, blueCube, purpleCube;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        // 在2秒内移动0,4,0的位置
        redCube.DOMove(new Vector3(0, 4, 0), 2);
        // 从当前位置0,4,0位置移动到动画开始前的位置
        greenCube.DOMove(new Vector3(0, 4, 0), 2).From();
        // 移动距离 0,4,0 停止
        blueCube.DOMove(new Vector3(0, 4, 0),2).SetRelative();
        // 
        purpleCube.DOMove(new Vector3(6, 0, 0), 2).SetRelative();

        purpleCube.GetComponent<Renderer>().material.DOColor(Color.yellow, 2).SetLoops(-1, LoopType.Yoyo);

    }

}
