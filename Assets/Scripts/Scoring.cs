using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    [SerializeField] public int score = 0;
    [SerializeField] public float timer = 5;
    [SerializeField] private TMP_Text scoreDisplay, timeDisplay;

    [SerializeField] public int dollPoint, bombPoint, wnPoint;
    [SerializeField] private AudioSource obtainSFX, bombSFX;
    [SerializeField] public bool gameDone = false;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        dollPoint = 0;
        bombPoint = 0;
        wnPoint = 0;
        timer = 101;
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = score.ToString();
        timeDisplay.text = ((int)timer).ToString();

        if (timer > 0)
        {
            timer -= 1 * Time.deltaTime;
        }
        else
        {
            timer = 0;
            gameDone = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "doll")
        {
            score += 5;
            dollPoint++;
            obtainSFX.Play();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "bomb")
        {
            score -= 1;
            bombPoint++;
            bombSFX.Play();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "wen ning")
        {
            wnPoint++;
            bombSFX.Play();
            Destroy(collision.gameObject);
        }
    }
}
