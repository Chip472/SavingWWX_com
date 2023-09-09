using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuControl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private TMP_Text button;
    [SerializeField] private AudioSource buttonSFX;
    [SerializeField] private int buttonIndex;
    [SerializeField] private GameObject menu, settings, credits;

    [SerializeField] private GameObject transition;
    [SerializeField] private Animator transiAnim;

    float r = 96f / 255.0f, g = 48f / 255.0f, b = 168f / 255.0f;
    float r2 = 180f / 255.0f, g2 = 35f / 255.0f, b2 = 36f / 255.0f;

    public void OnPointerDown(PointerEventData eventData)
    {
        switch (buttonIndex)
        {
            case 0:
                buttonSFX.Play();
                StartCoroutine(DelayLoadScene());
                break;
            case 1:
                buttonSFX.Play();
                menu.SetActive(false);
                settings.SetActive(true);
                break;
            case 2:
                buttonSFX.Play();
                menu.SetActive(false);
                credits.SetActive(true);
                break;
            case 3:
                Application.Quit();
                break;
            case 4:
                buttonSFX.Play();
                button.color = new Color(r, g, b);
                menu.SetActive(true);
                settings.SetActive(false);
                break;
            case 5:
                buttonSFX.Play();
                menu.SetActive(true);
                credits.SetActive(false);
                break;
        }
    }

    IEnumerator DelayLoadScene()
    {
        transition.SetActive(true);
        transiAnim.Play("WhiteTransiIn", 0);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.color = new Color(r2, g2, b2);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.color = new Color(r, g, b);
    }
}
