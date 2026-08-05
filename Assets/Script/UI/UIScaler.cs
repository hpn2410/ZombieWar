using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;


public class UIScaler : MonoBehaviour
{
    [SerializeField] CanvasScaler m_canvasScaler;
    private Canvas m_canvas { set; get; }
    public static int ScreenWidth { set; get; }
    public static int ScreenHeight { set; get; }
    public static bool IsScreenSquare { set; get; }

    private void Awake()
    {
        m_canvas = GetComponent<Canvas>();
    }

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => (Screen.height > 100 && Screen.width != Screen.height));
        AdjustScaler();
        AdjustCamera();
    }

    public void AdjustScaler()
    {
        float ratio = (float)Screen.height / (float)Screen.width;
        ScreenWidth = Screen.width;
        ScreenHeight = Screen.height;

        if (ratio < 0.56f)
        {
            IsScreenSquare = false;
        }
        else
        {
            IsScreenSquare = true;
        }

        if(IsScreenSquare)
        {
            m_canvasScaler.matchWidthOrHeight = 1f;
        }
        else
        {
            m_canvasScaler.matchWidthOrHeight = 0;
        }

        Debug.Log($"[UIScaler] Adjust Scaler ratio = {ratio}  width = {Screen.width}  height = {Screen.height}  MatchWidthOrHeight = {m_canvasScaler.matchWidthOrHeight}");
    }

    public void AdjustCamera()
    {
        m_canvas.renderMode = RenderMode.ScreenSpaceCamera;
    }
}