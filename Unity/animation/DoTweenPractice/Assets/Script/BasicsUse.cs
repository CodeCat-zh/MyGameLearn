using System.Collections;
using UnityEngine;
using DG.Tweening;
public class BasicsUse : MonoBehaviour
{
    public Transform redCube, greenCube, blueCube, purpleCube;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        // ��2�����ƶ�0,4,0��λ��
        redCube.DOMove(new Vector3(0, 4, 0), 2);
        // �ӵ�ǰλ��0,4,0λ���ƶ���������ʼǰ��λ��
        greenCube.DOMove(new Vector3(0, 4, 0), 2).From();
        // �ƶ����� 0,4,0 ֹͣ
        blueCube.DOMove(new Vector3(0, 4, 0),2).SetRelative();
        // 
        purpleCube.DOMove(new Vector3(6, 0, 0), 2).SetRelative();

        purpleCube.GetComponent<Renderer>().material.DOColor(Color.yellow, 2).SetLoops(-1, LoopType.Yoyo);

    }

}
