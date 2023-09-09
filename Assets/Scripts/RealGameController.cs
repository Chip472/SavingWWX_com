using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RealGameController : MonoBehaviour
{
    [SerializeField] private GameObject warningBox, tutorial;
    [SerializeField] private AudioSource buttonSFX, buttonSFX2;

    [SerializeField] private GameObject transition;
    [SerializeField] private Animator transiAnim;

    public void ExitGame()
    {
        warningBox.SetActive(true);
        Time.timeScale = 0;
        buttonSFX2.Play();
    }

    public void ExitYes()
    {
        Time.timeScale = 1;
        StartCoroutine(DelayYes(0));
    }

    public void ExitNo()
    {
        warningBox.SetActive(false);
        buttonSFX.Play();
        Time.timeScale = 1;
    }

    public void TutorDone()
    {
        buttonSFX.Play();
        tutorial.SetActive(false);
    }

    IEnumerator DelayYes(int scene)
    {
        transition.SetActive(true);
        transiAnim.Play("WhiteTransiIn", 0);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(scene);
    }
}
