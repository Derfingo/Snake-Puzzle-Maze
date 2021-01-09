using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCycler : MonoBehaviour
{
    [SerializeField] protected Color[] colors;
    [SerializeField] private float speed = 5;
    [SerializeField] private Camera mainCamera;
    private int numberColors = 0;
    private bool shouldChange = false;

    private void Start()
    {
        mainCamera = GetComponent<Camera>();
        numberColors = 0;
        SetColor(colors[numberColors]);
    }

    public void SetColor(Color color)
    {
        mainCamera.backgroundColor = color;
    }

    public void Cycle()
    {
        shouldChange = true;
    }

    private void Update()
    {
        if (shouldChange)
        {
            var startColor = mainCamera.backgroundColor;

            var endColor = colors[0];
            if (numberColors + 1 < colors.Length)
            {
                endColor = colors[numberColors + 1];
            }

            var newColor = Color.Lerp(startColor, endColor, Time.deltaTime * speed);
            SetColor(newColor);

            if (newColor == endColor)
            {
                shouldChange = false;
                if (numberColors + 1 < colors.Length)
                {
                    numberColors++;
                }
                else
                {
                    numberColors = 0;
                }
            }
        }
    }
}
