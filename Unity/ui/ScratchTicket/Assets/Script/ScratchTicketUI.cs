using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// �ι���
/// </summary>
public class ScratchTicketUI : MonoBehaviour,IPointerDownHandler, IPointerUpHandler
{
    private bool isScratch = false; // ��ǰ�Ƿ��ڽ��йζ�
    /// <summary>
    /// ����ͼƬ
    /// </summary>
    public RenderTexture renderTexture;
    

    public void Start()
    {
        
    }

    /// <summary>
    /// ��ʼ��RenderTexture������
    /// </summary>
    public void InitRenderTexture()
    {

    }

    /// <summary>
    /// ���µ�ǰ��RendererTexture״̬
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
