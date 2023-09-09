using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ClawPickControl : MonoBehaviour
{
    [SerializeField] private GameObject claw, allClaw, cover;
    [SerializeField] private Rigidbody2D allClawRigid;
    [SerializeField] private Animator clawAnim;
    [SerializeField] private float clawSpeed;
    [SerializeField] private GameObject[] coins;
    [SerializeField] private Scoring currentScore;

    [SerializeField] private AudioSource startPickSFX, endPickSFX;
    [SerializeField] private AudioSource startSFX, endSFX, dropSFX;

    [SerializeField] private GameObject transition;
    [SerializeField] private Animator transiAnim;

    [SerializeField] private TMP_Text scoreText, timeText;
    [SerializeField] private TMP_Text[] warningText;
    [SerializeField] private TMP_FontAsset engFont, vietFont;


    [SerializeField] private GameObject gameControl;

    [SerializeField] private Image imgJoystick;

    bool pickBool = false;
    bool pickDool = false;
    bool goUpBool = false;
    bool dropBool = false;

    public bool isPicked = false;

    public bool buttonSwitch = false;

    Vector3 allClawStartPos, clawStartUpPos;
    int countcoins = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("language") == "English")
        {
            scoreText.font = engFont;
            scoreText.text = "Score";

            timeText.font = engFont;
            timeText.text = "Timer";

            warningText[0].text = "Do you want to exit? The data won't be saved.";
            warningText[1].text = "Yes";
            warningText[2].text = "No";

            for (int i = 0; i < warningText.Length; i++)
            {
                warningText[i].font = engFont;
            }
        }
        else
        {
            scoreText.font = vietFont;
            scoreText.text = "Điểm số";

            timeText.font = vietFont;
            timeText.text = "Đếm giờ";

            warningText[0].text = "Bạn có chắc chắn muốn thoát? Dữ liệu sẽ không được lưu lại nếu bạn làm vậy.";
            warningText[1].text = "Có";
            warningText[2].text = "Không";

            for (int i = 0; i < warningText.Length; i++)
            {
                warningText[i].font = vietFont;
            }
        }

        allClawStartPos = allClaw.transform.position;
        StartCoroutine(DelayStart());
    }

    IEnumerator DelayStart()
    {
        transiAnim.SetBool("appear", false);
        yield return new WaitForSeconds(2f);
        transition.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pickBool)
        {
            claw.transform.Translate(Vector3.down * clawSpeed * Time.deltaTime);
        }

        if (goUpBool)
        {
            StartCoroutine(DelayPullUp());
        }

        if (dropBool)
        {
            StartCoroutine(DelayDrop());
            if (allClaw.transform.position.x == allClawStartPos.x)
            {
                endSFX.Play();
                StartCoroutine(DelayDrop2());
            }
        }

        if (currentScore.gameDone)
        {
            PlayerPrefs.SetInt("current score", currentScore.score);
            PlayerPrefs.SetInt("doll", currentScore.dollPoint);
            PlayerPrefs.SetInt("bomb", currentScore.bombPoint);
            PlayerPrefs.SetInt("wn", currentScore.wnPoint);
            PlayerPrefs.SetFloat("time left", currentScore.timer);


            if (currentScore.score > PlayerPrefs.GetInt("max score", 0))
            {
                PlayerPrefs.SetInt("max score", currentScore.score);
                Debug.Log(PlayerPrefs.GetInt("max score"));
            }
            StartCoroutine(DelayEndGame(3));
        }

        if (Input.GetKey(KeyCode.Return))
        {
            imgJoystick.transform.rotation = Quaternion.Euler(0, 0, 0);
            startPickSFX.Play();
            if (!isPicked)
            {
                if (allClaw.transform.position.x > allClawStartPos.x + 1.5f)
                {
                    gameControl.GetComponent<GameController>().enabled = false;
                    isPicked = true;
                    clawAnim.SetBool("pick", true);
                    clawAnim.Play("ClawAnimPickUp", 0);
                    cover.SetActive(true);
                    clawStartUpPos = claw.transform.position;
                    pickBool = true;
                    allClawRigid.constraints = RigidbodyConstraints2D.FreezeAll;

                    if (countcoins < 5)
                    {
                        coins[countcoins].SetActive(false);
                        countcoins++;
                    }
                }
            }
        }
    }

    IEnumerator DelayPullUp()
    {
        yield return new WaitForSeconds(0.5f);
        claw.transform.position = Vector3.MoveTowards(claw.transform.position, clawStartUpPos, clawSpeed * Time.deltaTime);

        yield return new WaitForSeconds(1f);
        dropBool = true;
        goUpBool = false;
        StartCoroutine(DelayPullUp2());
    }
    IEnumerator DelayPullUp2()
    {
        yield return new WaitForSeconds(0.5f);
        startSFX.Play();

    }

    IEnumerator DelayDrop()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("move back");
        allClaw.transform.position = Vector3.MoveTowards(allClaw.transform.position, allClawStartPos, clawSpeed * Time.deltaTime);
    }


    IEnumerator DelayDrop2()
    {
        dropBool = false;
        clawAnim.SetBool("pick", true);

        yield return new WaitForSeconds(1f);
        dropSFX.Play();

        yield return new WaitForSeconds(0.5f);
        clawAnim.SetBool("pick", false);

        yield return new WaitForSeconds(1.5f);
        clawAnim.Play("ClawAnimStay", 0);
        cover.SetActive(false);
        pickDool = false;
        isPicked = false;
        gameControl.GetComponent<GameController>().enabled = true;

        if (countcoins == 5)
        {
            currentScore.gameDone = true;
            PlayerPrefs.SetInt("current score", currentScore.score);
            PlayerPrefs.SetInt("doll", currentScore.dollPoint);
            PlayerPrefs.SetInt("bomb", currentScore.bombPoint);
            PlayerPrefs.SetInt("wn", currentScore.wnPoint);
            PlayerPrefs.SetFloat("time left", currentScore.timer);


            if (currentScore.score > PlayerPrefs.GetInt("max score", 0))
            {
                PlayerPrefs.SetInt("max score", currentScore.score);
                Debug.Log(PlayerPrefs.GetInt("max score"));
            }
            StartCoroutine(DelayEndGame(3));
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!pickDool)
        {
            if (collision.gameObject.tag == "doll" || collision.gameObject.tag == "bomb" || collision.gameObject.tag == "wall")
            {
                StartCoroutine(DelayPick());
            }
        }
        else
        {
            if (collision.gameObject.tag == "doll" || collision.gameObject.tag == "bomb")
            {
                //do nothing
            }
        }
    }

    IEnumerator DelayPick()
    {
        //allClaw.enabled = false;
        pickDool = true;

        yield return new WaitForSeconds(0.2f);
        pickBool = false;


        yield return new WaitForSeconds(1f);
        clawAnim.SetBool("pick", false);

        yield return new WaitForSeconds(0.2f);
        endPickSFX.Play();

        yield return new WaitForSeconds(1f);
        clawAnim.Play("ClawAnimStay", 0);
        goUpBool = true;
        //claw.transform.position = Vector3.MoveTowards(claw.transform.position, clawStartUpPos, 20 * Time.deltaTime);

        //yield return new WaitForSeconds(3f);
        //claw.transform.position = Vector3.MoveTowards(claw.transform.position, clawStartPos, 20 * Time.deltaTime);

    }


    IEnumerator DelayEndGame(int scene)
    {
        transition.SetActive(true);
        transiAnim.Play("WhiteTransiIn", 0);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(scene);
    }
}
