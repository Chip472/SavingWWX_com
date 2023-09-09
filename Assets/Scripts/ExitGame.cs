using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ExitGame : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private TMP_Text play1, play2;
    float r = 181f / 255.0f, g = 81f / 255.0f, b = 74f / 255.0f;

    public void OnPointerDown(PointerEventData eventData)
    {
        Application.Quit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        play1.color = new Color(1, 1, 1);
        play2.color = new Color(r, g, b);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        play2.color = new Color(1, 1, 1);
        play1.color = new Color(r, g, b);
    }
}
