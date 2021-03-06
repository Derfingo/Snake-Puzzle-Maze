﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class SafeAreaSetter : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        private RectTransform panelSafeArea;

        Rect currentSaveArea = new Rect();
        ScreenOrientation currentOrientation = ScreenOrientation.AutoRotation;

        private void Start()
        {
            panelSafeArea = GetComponent<RectTransform>();

            //store current values
            currentOrientation = Screen.orientation;

            ApplySafeArea();
        }

        private void ApplySafeArea()
        {
            if (panelSafeArea == null)
                return;

            Rect safeArea = Screen.safeArea;

            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = safeArea.position + safeArea.size;

            anchorMin.x /= canvas.pixelRect.width;
            anchorMin.y /= canvas.pixelRect.height;

            anchorMax.x /= canvas.pixelRect.width;
            anchorMax.y /= canvas.pixelRect.height;

            panelSafeArea.anchorMin = anchorMin;
            panelSafeArea.anchorMax = anchorMax;

            currentOrientation = Screen.orientation;
            currentSaveArea = Screen.safeArea;
        }

        private void Update()
        {
            if ((currentOrientation != Screen.orientation) || (currentSaveArea != Screen.safeArea))
            {
                ApplySafeArea();
            }
        }
    }
}
