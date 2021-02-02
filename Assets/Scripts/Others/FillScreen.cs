using UnityEngine;

public class FillScreen : MonoBehaviour
{
    public float perspectiveCompensation = 0.95f;

    private void Start()
    {
        Camera camera = Camera.main;
        Bounds bounds = GetComponent<MeshRenderer>().bounds;
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);

        //Get the position on screen.
        Vector2 screenPosition = camera.WorldToScreenPoint(bounds.center);

        //Get the position on screen from the position + the bounds of the object.
        Vector2 sizePosition = camera.WorldToScreenPoint(bounds.center + bounds.size);

        //By subtracting the screen position from the size position, we get the size of the object on screen.
        Vector2 objectSize = sizePosition - screenPosition;

        //Calculate how many times the object can be scaled up.
        Vector2 scaleFactor = screenSize / objectSize;

        //The maximum scale is the one form the longest side, with the lowest scale factor.
        float maximumScale = Mathf.Min(scaleFactor.x, scaleFactor.y);

        if (camera.orthographic)
        {
            //Scale the orthographic size.
            camera.orthographicSize /= maximumScale;
        }
        else
        {
            //Set the scale of the object.
            transform.localScale *= maximumScale * perspectiveCompensation;
        }
    }
}
