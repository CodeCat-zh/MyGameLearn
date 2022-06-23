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

    /// <summary>
    /// 空白图 纯黑色图 RGBA(0,0,0,0)
    /// </summary>
    public Texture blankTexture;

    /// <summary>
    /// 笔刷 纯白图（1，1，1，1）
    /// </summary>
    public Texture brushTexture;
   /// <summary>
   /// 
   /// </summary>
    public RectTransform rectTransform;

    /// <summary>
    /// 画布
    /// </summary>
    public Canvas canvas;
    public void Start()
    {
        InitRenderTexture();
    }

    /// <summary>
    /// 初始化RenderTexture的数据
    /// </summary>
    public void InitRenderTexture()
    {
        // 激活rt
        RenderTexture.active = renderTexture;
        // 保存当前界面的状态
        GL.PushMatrix();
        //设置矩阵
        GL.LoadPixelMatrix(0, renderTexture.width, renderTexture.height, 0);

        //绘制贴图
        Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
        Graphics.DrawTexture(rect, blankTexture);

        GL.PopMatrix();

        RenderTexture.active = null;
    }

    public void Update()
    {
        UpdateRenderText();
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
        OnMouseMove(Input.mousePosition);
    }
    /// <summary>
    /// 计算当前鼠标对应的Graphics坐标，并绘制
    /// </summary>
    /// <param name="position"></param>
    private void OnMouseMove(Vector2 position)
    {
        // 获取刮的位置的ui局部坐标
        var uiLocalPos = ScreenPosToUiLocalPos(position, rectTransform, canvas.worldCamera);
        // 将局部坐标转为uv坐标
        var uvX = (rectTransform.sizeDelta.x / 2f + uiLocalPos.x) / rectTransform.sizeDelta.x;
        var uvY = (rectTransform.sizeDelta.y / 2f + uiLocalPos.y) / rectTransform.sizeDelta.y;
        //将uv转为Graphics的坐标，注意uv坐标与Graphics坐标的y轴方向相反
        var x = (int)(uvX * renderTexture.width);
        var y = (int)(renderTexture.height - uvY * renderTexture.height);
        Draw(x, y);
    }
    /// <summary>
    /// 鼠标坐标 ->摄影机坐标->mask的本地坐标
    /// </summary>
    /// <param name="position">鼠标点击的屏幕坐标</param>
    /// <param name="rectTransform">遮罩的RT</param>
    /// <param name="worldCamera">摄影机</param>
    /// <returns></returns>
    private Vector2 ScreenPosToUiLocalPos(Vector2 position, RectTransform rectTransform, Camera worldCamera)
    {
        Vector2 uiLocalPos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform,position,worldCamera,out uiLocalPos))
        {
            return uiLocalPos;
        }
        return Vector2.zero;
    }

    /// <summary>
    /// 以x,y为中心，将笔刷写进RT中
    /// </summary>
    /// <param name="x">在Graphics坐标下的x</param>
    /// <param name="y">在Graphics坐标下的y</param>
    private void Draw(int x,int y)
    {
        RenderTexture.active = renderTexture;

        GL.PushMatrix();
        GL.LoadPixelMatrix(0, renderTexture.width, renderTexture.height, 0);

        // 绘制笔刷
        x -= (int)(brushTexture.width * 0.5f);
        y -= (int)(brushTexture.height * 0.5f);

        Rect rect = new Rect(x, y, brushTexture.width, brushTexture.height);
        Graphics.DrawTexture(rect, brushTexture);

        GL.PopMatrix();

        RenderTexture.active = null;
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
