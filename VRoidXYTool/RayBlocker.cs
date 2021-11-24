using System.Collections;
using UnityEngine;
using UnityEngine.UI;



namespace VRoidXYTool
{
    public class RayBlocker
    {
        public Rect blockArea;

        GameObject rayblocker;
        GameObject rayblockerCanva;
        public RayBlocker()
        {
            rayblockerCanva = new GameObject();
            rayblockerCanva.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            rayblockerCanva.AddComponent<GraphicRaycaster>();

            rayblocker = new GameObject();
            rayblocker.transform.parent = rayblockerCanva.transform;
            Image rbImage = rayblocker.AddComponent<Image>();
            rbImage.color = Color.clear;
            rbImage.raycastTarget = true;
        }

        public void Update()
        {
            RectTransform rbRect = rayblocker.GetComponent<RectTransform>();
            rbRect.pivot = new Vector2(0, 1);
            rbRect.sizeDelta = blockArea.size;
            rbRect.position = new Vector2(blockArea.position.x, Screen.height - blockArea.position.y);
        }

        public void OpenBlocker(Rect _blockArea)
        {
            blockArea = _blockArea;
            rayblockerCanva.SetActive(true);
        }

        public void CloseBlocker()
        {
            rayblockerCanva.SetActive(false);
        }
    }
}