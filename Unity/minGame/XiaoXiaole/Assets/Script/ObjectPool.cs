using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ObjectEnum
{

}
/// <summary>
/// �����
/// </summary>
public class ObjectPool : MonoBehaviour
{

   private Dictionary<ObjectEnum, List<GameObject>> pool;
    /// <summary>
    /// ��ȡ��Ӧ���͵Ķ����
    /// </summary>
    /// <param name="objectEnum"></param>
    /// <returns></returns>
   public GameObject GetGameObject(ObjectEnum objectEnum)
   {
        return null;
   }
/// <summary>
/// 
/// </summary>
/// <param name="objectEnum"></param>
/// <param name="gameObject"></param>
   public void CacheGameObject(ObjectEnum objectEnum,GameObject gameObject)
   {

   }
}
