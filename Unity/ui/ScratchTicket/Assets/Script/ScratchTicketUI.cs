using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 刮刮乐
/// </summary>
public class ScratchTicketUI : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    private bool isScratch = false; // 当前是否在进行刮动
    /// <summary>
    /// 绘制图片
    /// </summary>
    public RenderTexture renderTexture;
    

    public void Start()
    {
        
    }

    /// <summary>
    /// 初始化RenderTexture的数据
    /// </summary>
    public void InitRenderTexture()
    {

    }

    /// <summary>
    /// 更新当前的RendererTexture状态
    /// </summary>
    public void UpdateRenderText()
    {
        if ( false == isScratch)
        {
            return;
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        isScratch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isScratch = false;
    }
}
