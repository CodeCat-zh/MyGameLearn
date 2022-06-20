using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ObjectEnum
{

}
/// <summary>
/// 对象池
/// </summary>
public class ObjectPool : MonoBehaviour
{

   private Dictionary<ObjectEnum, List<GameObject>> pool;
    /// <summary>
    /// 获取对应类型的对象池
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
