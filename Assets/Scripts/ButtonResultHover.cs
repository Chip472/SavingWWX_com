using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonResultHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image button;
    [SerializeField] private Sprite buttonSpr1, buttonSpr2;
    [SerializeField] private TMP_Text buttonText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.sprite = buttonSpr1;
        buttonText.color = new Color(247f / 255f, 207f / 255f, 178f / 255f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.sprite = buttonSpr2;
        buttonText.color = new Color(247f / 255f, 207f / 255f, 178f / 255f);
    }
}
