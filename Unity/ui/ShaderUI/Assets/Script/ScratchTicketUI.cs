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

    /// <summary>
    /// �հ�ͼ ����ɫͼ RGBA(0,0,0,0)
    /// </summary>
    public Texture blankTexture;

    /// <summary>
    /// ��ˢ ����ͼ��1��1��1��1��
    /// </summary>
    public Texture brushTexture;
   /// <summary>
   /// 
   /// </summary>
    public RectTransform rectTransform;

    /// <summary>
    /// ����
    /// </summary>
    public Canvas canvas;
    public void Start()
    {
        InitRenderTexture();
    }

    /// <summary>
    /// ��ʼ��RenderTexture������
    /// </summary>
    public void InitRenderTexture()
    {
        // ����rt
        RenderTexture.active = renderTexture;
        // ���浱ǰ�����״̬
        GL.PushMatrix();
        //���þ���
        GL.LoadPixelMatrix(0, renderTexture.width, renderTexture.height, 0);

        //������ͼ
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
    /// ���µ�ǰ��RendererTexture״̬
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
    /// ���㵱ǰ����Ӧ��Graphics���꣬������
    /// </summary>
    /// <param name="position"></param>
    private void OnMouseMove(Vector2 position)
    {
        // ��ȡ�ε�λ�õ�ui�ֲ�����
        var uiLocalPos = ScreenPosToUiLocalPos(position, rectTransform, canvas.worldCamera);
        // ���ֲ�����תΪuv����
        var uvX = (rectTransform.sizeDelta.x / 2f + uiLocalPos.x) / rectTransform.sizeDelta.x;
        var uvY = (rectTransform.sizeDelta.y / 2f + uiLocalPos.y) / rectTransform.sizeDelta.y;
        //��uvתΪGraphics�����꣬ע��uv������Graphics�����y�᷽���෴
        var x = (int)(uvX * renderTexture.width);
        var y = (int)(renderTexture.height - uvY * renderTexture.height);
        Draw(x, y);
    }
    /// <summary>
    /// ������� ->��Ӱ������->mask�ı�������
    /// </summary>
    /// <param name="position">���������Ļ����</param>
    /// <param name="rectTransform">���ֵ�RT</param>
    /// <param name="worldCamera">��Ӱ��</param>
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
    /// ��x,yΪ���ģ�����ˢд��RT��
    /// </summary>
    /// <param name="x">��Graphics�����µ�x</param>
    /// <param name="y">��Graphics�����µ�y</param>
    private void Draw(int x,int y)
    {
        RenderTexture.active = renderTexture;

        GL.PushMatrix();
        GL.LoadPixelMatrix(0, renderTexture.width, renderTexture.height, 0);

        // ���Ʊ�ˢ
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
