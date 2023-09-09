using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultControl : MonoBehaviour
{
    [SerializeField] private TMP_Text dollP, bombP, totalP, timeLeft, wnP;
    [SerializeField] private Sprite[] endings;
    [SerializeField] private Image endingDisplay;
    [SerializeField] private AudioSource buttonSFX;

    [SerializeField] private TMP_Text[] scoreText;

    [SerializeField] private AudioSource[] endingThemes;
    [SerializeField] private GameObject[] endingPoems;
    [SerializeField] public TMP_Text[] endingPoemsText;
    [SerializeField] private TMP_FontAsset engFont, vietFont;
    [SerializeField] private int engFontSize, vietFontSize;

    [SerializeField] private GameObject transition;
    [SerializeField] private Animator transiAnim;

    [SerializeField] private GameObject scoreTable, explainTable;
    [SerializeField] private TMP_Text explainText, nextText;

    int score, wenNing;
    float timeL;

    int indexEnd;

    IEnumerator TransiIn()
    {
        transiAnim.SetBool("appear", false);
        yield return new WaitForSeconds(2f);
        transition.SetActive(false);
    }

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("current score");
        wenNing = PlayerPrefs.GetInt("wn");
        timeL = PlayerPrefs.GetFloat("time left");

        StartCoroutine(TransiIn());

        dollP.text = PlayerPrefs.GetInt("doll").ToString();
        bombP.text = PlayerPrefs.GetInt("bomb").ToString();
        wnP.text = PlayerPrefs.GetInt("wn").ToString();
        totalP.text = PlayerPrefs.GetInt("current score").ToString();
        timeLeft.text = ((int)PlayerPrefs.GetFloat("time left")).ToString();
        //maxP.text = PlayerPrefs.GetInt("max score").ToString();

        if (PlayerPrefs.GetString("language") == "English")
        {
            explainText.font = engFont;
            nextText.text = "Next";
            nextText.font = engFont;

            scoreText[0].text = "Score";
            scoreText[1].text = "Wei Wuxian:";
            scoreText[2].text = "Resentment energy:";
            scoreText[3].text = "Wen Ning:";
            scoreText[4].text = "Total point:";
            scoreText[5].text = "Time left:";

            scoreText[6].text = "Go back";
            scoreText[7].text = "Play again";

            endingPoemsText[0].text = "Wangxian, one song echoes the distance.";
            endingPoemsText[1].text = "The song ends, the lover remains.";

            endingPoemsText[2].text = "One duet of joy and agony with you";
            endingPoemsText[3].text = "We pass by one thousand sails yet untainted";
            endingPoemsText[4].text = "Let’s start over, you and I.";

            endingPoemsText[5].text = "Journeying through adversity, love, and hate";
            endingPoemsText[6].text = "with no regrets, to stay by your side for all eternity.";

            endingPoemsText[7].text = "Yunmeng Twin Heroes";
            endingPoemsText[8].text = "Never Forget";
            endingPoemsText[9].text = "Never Regret";

            endingPoemsText[10].text = "Never Forget. Never Forget. Never Forget";
            endingPoemsText[11].text = "Have you forgotten";
            endingPoemsText[12].text = "The Promise we made";
            endingPoemsText[13].text = "In Yunshen, among the crowd?";
            endingPoemsText[14].text = "Where have you gone?";
            endingPoemsText[15].text = "I am here. I have never forgotten.";

            endingPoemsText[16].text = "The song ends, the lover gone.";
            endingPoemsText[17].text = "A chill breeze glides over river water.";

            for (int i = 0; i < endingPoemsText.Length; i++)
            {
                endingPoemsText[i].font = engFont;
                endingPoemsText[i].fontSize = engFontSize;
            }
            for (int i = 0; i < scoreText.Length; i++)
            {
                scoreText[i].font = engFont;
            }
        }
        else
        {
            explainText.font = vietFont;
            nextText.text = "Tiếp";
            nextText.font = vietFont;

            scoreText[0].text = "Điểm số";
            scoreText[1].text = "Ngụy Vô Tiện:";
            scoreText[2].text = "Oán khí:";
            scoreText[3].text = "Ôn Ninh:";
            scoreText[4].text = "Tổng điểm:";
            scoreText[5].text = "Thời gian còn lại:";

            scoreText[6].text = "Quay về";
            scoreText[7].text = "Chơi lại";

            endingPoemsText[0].text = "Vong Tiện Nhất Khúc Viễn.";
            endingPoemsText[1].text = "Khúc Chung Nhân Bất Tán.";

            endingPoemsText[2].text = "Cùng người thổi một khúc thấu triệt vui và hận,";
            endingPoemsText[3].text = "Đi qua ngàn cánh buồm vẫn còn thiên chân.";
            endingPoemsText[4].text = "Ta và người, cùng nhau làm lại lần nữa.";

            endingPoemsText[5].text = "Bước qua lữ trình ái hận vô hối";
            endingPoemsText[6].text = "Chỉ cần được ở bên người mãi thôi";

            endingPoemsText[7].text = "Vân Mộng Song Kiệt.";
            endingPoemsText[8].text = "Nhất Thế Bất Vong.";
            endingPoemsText[9].text = "Nhất Sinh Bất Hối.";

            endingPoemsText[10].text = "Bất vong bất vong bất vong";
            endingPoemsText[11].text = "Người còn nhớ không";
            endingPoemsText[12].text = "Lời thề thốt ở chốn Vân Thâm";
            endingPoemsText[13].text = "Mà chúng ta đã trao";
            endingPoemsText[14].text = "Quân ở nơi nào";
            endingPoemsText[15].text = "Mãi nhớ không quên";

            endingPoemsText[16].text = "Khúc Chung Nhân Bất Kiến.";
            endingPoemsText[17].text = "Giang Thượng Thụ Thanh Phong.";

            for (int i = 0; i < endingPoemsText.Length; i++)
            {
                endingPoemsText[i].font = vietFont;
                endingPoemsText[i].fontSize = vietFontSize;
            }
            for (int i = 0; i < scoreText.Length; i++)
            {
                scoreText[i].font = vietFont;
            }
        }

        //ending: 0_PerfectE; 1_SpecialE; 2_WenNing; 3_JiangCheng; 4_Amnesia; 5_ForeverLost
        if (score >= 25)
        {
            if (timeL >= 20)
            {
                switch (wenNing)
                {
                    case 0:
                        indexEnd = 0;
                        break;
                    case 1:
                        indexEnd = 1;
                        break;
                    case 2:
                        indexEnd = 2;
                        break;
                }
            }
            else
            {
                switch (wenNing)
                {
                    case 0:
                        indexEnd = 3;
                        break;
                    case 1:
                        indexEnd = 3;
                        break;
                    case 2:
                        indexEnd = 2;
                        break;
                }
            }
        }
        else if (score < 25 && score >= 15)
        {
            if (timeL >= 20)
            {

                switch (wenNing)
                {
                    case 0:
                        indexEnd = 3;
                        break;
                    case 1:
                        indexEnd = 2;
                        break;
                    case 2:
                        indexEnd = 2;
                        break;
                }
            }
            else
            {

                switch (wenNing)
                {
                    case 0:
                        indexEnd = 3;
                        break;
                    case 1:
                        indexEnd = 3;
                        break;
                    case 2:
                        indexEnd = 4;
                        break;
                }
            }
        }
        else
        {
            if (timeL >= 10)
            {
                indexEnd = 4;
            }
            else
            {

                switch (wenNing)
                {
                    case 0:
                        indexEnd = 4;
                        break;
                    case 1:
                        indexEnd = 4;
                        break;
                    case 2:
                        indexEnd = 5;
                        break;
                }
            }
        }

        switch (indexEnd)
        {
            case 0:
                if (PlayerPrefs.GetString("language") == "English")
                {
                    explainText.text = "Rejoice, Love and Beloved! Rejoice, Lan Zhan and Wei Ying! A miracle has occurred! Your wish has come true! Wei Wuxian is returned to you, whole and alive! He has watched your journey, has witnessed your efforts! He knows your heart now, and you know his! Your love is unrequited no more! Come! The day is yours! The future is yours! The road ahead is open, for you and for him.";
                }
                else if (PlayerPrefs.GetString("language") == "Vietnamese")
                {
                    explainText.text = "Vui lên, kẻ yêu và được yêu! Vui lên, Lam Trạm và Ngụy Anh! Một phép màu đã hiện ra! Ước nguyện của ngài đã thành sự thật! Ngụy Vô Tiện đã được trả về cho ngài, nguyên vẹn và an ổn! Y đã dõi theo toàn bộ hành trình của ngài, đã chứng kiến nỗ lực thật nhiều của ngài! Y đã biết tấm lòng của ngài rồi, và ngài cũng biết lòng y! Tình yêu của ngài không đơn phương! Đi thôi! Ngày hôm nay là của hai người! Tương lai cũng của hai người! Con đường phía trước rộng mở, cho cả ngài và y!";
                };
                break;
            case 1:
                if (PlayerPrefs.GetString("language") == "English")
                {
                    explainText.text = "Dearest Hanguan Jun, your efforts were almost perfect, but for a single Wen Ning clinging fast to Wei Wuxian. The result is that Wei Wuxian seems to have reverted back to when he first met you at 15 years old. But this is not necessarily a bad thing. This may very well be a blessing in disguise. Leave all painful memories in the past, and start over once more. A bright future awaits both of you.";
                }
                else if (PlayerPrefs.GetString("language") == "Vietnamese")
                {
                    explainText.text = "Hàm Quang Quân thân mến, nỗ lực của ngài gần như hoàn hảo nếu không có một Ôn Ninh bám chắc vào Ngụy Vô Tiện. Kết quả là Ngụy Vô Tiện dường như là đã nhỏ lại như lần đầu gặp mặt ngài vào năm 15 tuổi. Nhưng đây cũng không hẳn là một chuyện xấu. Đây rất có thể là một phép lành ngụy trang. Hãy để lại tất cả nhữn ký ức đau đớn trong quá khứ và bắt đầu lại lần nữa. Một tương lai tươi sáng đang chờ đợi hai người.";

                };
                break;
            case 2:
                if (PlayerPrefs.GetString("language") == "English")
                {
                    explainText.text = "Alas and alack, Hanguang Jun. Though you have tried your best, Wen Ning’s fierce love for his master proved greater. He has taken Wei Wuxian from your hands now. Is this where it ends? Will you let it end like this?";
                }
                else if (PlayerPrefs.GetString("language") == "Vietnamese")
                {
                    explainText.text = "Chao ôi, Hàm Quang Quân. Mặc dù ngài đã cố gắng hết sức, nhưng Ôn Ninh vì bảo vệ chủ nhân của mình lại càng cố gắng hơn nhiều. Hắn đã cuỗm Ngụy Vô Tiện từ tay ngài rồi. Kết cục là như thế này sao? Ngài sẽ để cho mọi thứ kết thúc như vậy sao?";

                };
                break;
            case 3:
                if (PlayerPrefs.GetString("language") == "English")
                {
                    explainText.text = "Alas an alack, Hanguang Jun. Your efforts were valiant, and you did manage to bring Wei Wuxian back. But you also took too long. The result is that a certain leader of a certain House has caught wind of what you were doing. He harbors complicated feelings for your Wei Wuxian and has come to reclaim what he thinks is his due. Will you let it end like this?";
                }
                else if (PlayerPrefs.GetString("language") == "Vietnamese")
                {
                    explainText.text = "Chao ôi Hàm Quang Quân. Ngài đã thật nỗ lực và đã thành công đưa Ngụy Vô Tiện trở về. Nhưng ngài đã dùng quá nhiều thời gian. Kết quả là một vị tông chủ nào đó của thế gia nào đó đã phát hiện ra ngài đang muốn làm gì. Tình cảm của hắn đối với Ngụy Vô Tiện của ngài thật phức tạp. Cho nên hắn đã đến để đòi lại thứ mà hắn cho là của hắn. Ngài sẽ để mọi chuyện kết thúc như vậy sao?";

                };
                break;
            case 4:
                if (PlayerPrefs.GetString("language") == "English")
                {
                    explainText.text = "Alas and alack, Hanguang Jun. Your efforts were valiant, and you did manage to bring Wei Wuxian back. But you allowed too much resentment energy to cling to him. The result is that he seems to have forgotten everything, including you. He’s gone now, to seek a past that’s no longer there, and seek ones who aren’t you. Will you let it end like this?";
                }
                else if (PlayerPrefs.GetString("language") == "Vietnamese")
                {
                    explainText.text = "Chao ôi, Hàm Quang Quân, ngài đã nỗ lực thật nhiều và thành công đưa Ngụy Vô Tiện trở về. Nhưng ngài đã để cho quá nhiều oán khí quấn lấy y. Kết quả là y dường như đã quên hết tất cả, kể cả ngài. Y đi rồi. Đi tìm một quá khứ không còn nữa, tìm người không phải ngài. Ngài sẽ để cho mọi thứ kết thúc như vậy sao?";

                };
                break;
            case 5:
                if (PlayerPrefs.GetString("language") == "English")
                {
                    explainText.text = "Than ôi, Hàm Quang Quân. Những nỗ lực của ngài đã vô ích. Tàn hồn của Ngụy Vô Tiện tản ra nơi tứ phong. Y đã không còn rồi, đã mãi mãi mất đi rồi.";
                }
                else if (PlayerPrefs.GetString("language") == "Vietnamese")
                {
                    explainText.text = "Alas and alack Hanguang Jun. Your efforts were in vain. The shards of Wei Wuxian's soul scattered to the four winds. He is no more now, forever lost to you.";

                };
                break;
        }

        endingDisplay.sprite = endings[indexEnd];
        endingThemes[indexEnd].Play();

        Debug.Log(indexEnd);
    }

    public void BackToMenu()
    {
        StartCoroutine(MenuDelay(0));
    }

    public void PlayAgain()
    {
        StartCoroutine(MenuDelay(2));
    }

    IEnumerator MenuDelay(int scene)
    {

        buttonSFX.Play();
        transition.SetActive(true);
        transiAnim.Play("WhiteTransiIn", 0);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(scene);
    }

    public void NextScene()
    {
        buttonSFX.Play();
        scoreTable.SetActive(true);
        explainTable.SetActive(false);

        endingPoems[indexEnd].SetActive(true);
    }
}
