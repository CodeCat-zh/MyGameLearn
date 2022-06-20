using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 启动地图生成，水果的更新，当前得分情况，退出序列化得分，历史最高，游戏的结束
/// </summary>
public class GameManager : MonoBehaviour
{
    

    /// <summary>
    /// 开始游戏，读取配置，生成地图，显示历史最高得分，当前游戏的难度
    /// </summary>
    void StartGame()
    {
        
    }
  
    /// <summary>
    /// 是否可以进行消除
    /// </summary>
    public bool CheckIsEliminateFruite()
    {
        return false;
    }
    
    /// <summary>
    /// 序列化当前分数，是否更新历史最高，结束游戏
    /// </summary>
    void EndGame()
    {

    }
    /// <summary>
    /// 游戏是否结束
    /// </summary>
    /// <returns></returns>
    public bool IsEndGame()
    {
        return false;
    }

   
}
