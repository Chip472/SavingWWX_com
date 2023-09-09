using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ContextController : MonoBehaviour
{
    [SerializeField] private GameObject transition, arrow, context, tutorial;
    [SerializeField] private Animator transiAnim, blackCoverAnim, arrowAnim;

    [SerializeField] private TMP_Text introPoem;
    [SerializeField] private TMP_Text[] introText;
    [SerializeField] private TMP_FontAsset engFont, vietFont;
    [SerializeField] private int engFontSize, vietFontSize;

    [SerializeField] private Image tutorImg;
    [SerializeField] private Sprite engTutorSpr, vietTutorSpr;
    [SerializeField] private TMP_Text startGameButton;

    [SerializeField] private AudioSource buttonSFX;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DelaySomething());
    }

    IEnumerator DelaySomething()
    {
        yield return new WaitForSeconds(4.5f);
        transiAnim.SetBool("appear", false);

        yield return new WaitForSeconds(1f);
        transition.SetActive(false);

        yield return new WaitForSeconds(0.5f);
        blackCoverAnim.Play("TransiShadow", 0);

        yield return new WaitForSeconds(1f);
        context.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        arrow.SetActive(true);
        arrowAnim.Play("WhiteTransiIn", 0);
    }
    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetString("language") == "English")
        {
            tutorImg.sprite = engTutorSpr;
            startGameButton.text = "Start!";
            startGameButton.font = engFont;

            introPoem.fontSize = engFontSize;
            introPoem.font = engFont;
            introPoem.text = "Longing for you who I cannot follow. Thinking of when you will return.";

            introText[0].text = "Rejoice, Hanguang Jun.";
            introText[1].text = "A miracle is bestowed on you.";
            introText[2].text = "By the wishes of millions who adore you, a chance is at hand for you to save your beloved.";
            introText[3].text = "Behold this miracle machine!";
            introText[4].text = "Within it lie the many fragments of Wei Wuxian’s soul.";
            introText[5].text = "Collect enough of these fragments, and he will be returned to you.";
            introText[6].text = "But beware the resentment energy that clings to him, as well as the ferocious Wen Ning who guards his master against all.";

            for(int i = 0; i < introText.Length; i++)
            {
                introText[i].fontSize = engFontSize;
                introText[i].font = engFont;
            }
        }
        else
        {
            tutorImg.sprite = vietTutorSpr;
            startGameButton.text = "Bắt đầu!";
            startGameButton.font = vietFont;

            introPoem.fontSize = vietFontSize;
            introPoem.font = vietFont;
            introPoem.text = "Tư Quân Bất Khả Truy. Niệm Quân Hà Thì Quy.";

            introText[0].text = "Hãy vui mừng, Hàm Quang Quân.";
            introText[1].text = "Một phép màu được ban tặng cho ngài.";
            introText[2].text = "Nhờ vào ước nguyện của hàng triệu người yêu quý ngài, ngài sẽ có một cơ hội cứu được ái nhân.";
            introText[3].text = "Hãy nhìn xem cỗ máy kỳ diệu này!";
            introText[4].text = "Bên trong nó là những mảnh linh hồn của Ngụy Vô Tiện.";
            introText[5].text = "Thu thập đủ những mảnh vỡ này, ngài sẽ cứu được người yêu dấu.";
            introText[6].text = "Nhưng coi chừng oán khí quấn lấy y. Còn có Ôn Ninh hung dữ, luôn bảo vệ chủ nhân của mình khỏi tất cả.";

            for (int i = 0; i < introText.Length; i++)
            {
                introText[i].fontSize = vietFontSize;
                introText[i].font = vietFont;
            }
        }
    }

    public void NextToTutor()
    {
        context.SetActive(false);
        arrow.SetActive(false);
        tutorial.SetActive(true);
    }

    public void NextToGame()
    {
        StartCoroutine(DelayToNextScene());
    }

    IEnumerator DelayToNextScene()
    {
        buttonSFX.Play();
        yield return new WaitForSeconds(0.5f);
        transition.SetActive(true);
        transiAnim.Play("WhiteTransiIn", 0);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
}
