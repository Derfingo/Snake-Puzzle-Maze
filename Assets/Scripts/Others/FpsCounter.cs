using UnityEngine;

public class FpsCounter : MonoBehaviour
{
    private float deltaTime;

    private readonly GUIStyle style = new GUIStyle();

    private void Awake()
    {
        var h = Screen.height;

        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 3 / 100;
        style.normal.textColor = new Color(0.5f, 0.5f, 0.5f, 1f);
    }

    private void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    private void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        var rect = new Rect(20, 20, w, h * 2f / 100f);
        var msec = deltaTime * 1000.0f;
        var fps = 1.0f / deltaTime;
        var text = $"{msec:0.0} ms({fps:0.} fps)";

        GUI.Label(rect, text, style);
    }
}
