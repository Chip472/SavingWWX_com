using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class StartGameScript : MonoBehaviour
{
    [SerializeField] private Animator transiAnim;
    [SerializeField] private GameObject transition;
    [SerializeField] private TMP_Text disclaimerText;

    [SerializeField] private TMP_FontAsset engFont, vietFont;
    [SerializeField] private TMP_Dropdown languageDropDown;

    //menu texts
    [SerializeField] private TMP_Text[] gameTitle, playButton, settingsButton, creditsButton, exitButton;

    //settings texts
    [SerializeField] private TMP_Text[] settingsTitle, audioText, languageText, backText;
    [SerializeField] private TMP_Text languageTextBox, languageTextItem;

    //credits texts
    [SerializeField] private TMP_Text[] creditsTitle, sythePart, chipPart, musicPart;
    [SerializeField] private TMP_Text mxtxPart, sytheName, chipName;
    [SerializeField] private TMP_Text[] songs;

    public AudioMixer audioMixer;

    string languageStart;

    private void Awake()
    {
        languageStart = PlayerPrefs.GetString("language", "English");
    }

    // Start is called before the first frame update
    void Start()
    {
        if (languageStart == "English")
        {
            languageDropDown.value = 0;
            disclaimerText.font = engFont;
            disclaimerText.text = "All rights and characters belong to Mo Xiang Tong Xiu";
        }
        else if ((languageStart == "Vietnamese"))
        {
            languageDropDown.value = 1;
            disclaimerText.font = vietFont;
            disclaimerText.text = "Toàn bộ quyền và nhân vật đều thuộc về Mặc Hương Đồng Khứu";
        }
        StartCoroutine(TransiOut());
    }

    IEnumerator TransiOut()
    {
        yield return new WaitForSeconds(4f);
        transiAnim.SetBool("appear", false);

        yield return new WaitForSeconds(1f);
        transition.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        languageStart = PlayerPrefs.GetString("language");

        if (languageDropDown.value == 0)
        {
            PlayerPrefs.SetString("language", "English");
        }
        else if (languageDropDown.value == 1)
        {
            PlayerPrefs.SetString("language", "Vietnamese");
        }

        if(languageStart == "English")
        {
            gameTitle[0].text = "Saving Wei Wuxian";
            gameTitle[0].font = engFont;
            gameTitle[1].text = "Saving Wei Wuxian";
            gameTitle[1].font = engFont;

            playButton[0].text = "Play";
            playButton[0].font = engFont;
            playButton[1].text = "Play";
            playButton[1].font = engFont;

            settingsButton[0].text = "Settings";
            settingsButton[0].font = engFont;
            settingsButton[1].text = "Settings";
            settingsButton[1].font = engFont;

            creditsButton[0].text = "Credits";
            creditsButton[0].font = engFont;
            creditsButton[1].text = "Credits";
            creditsButton[1].font = engFont;

            exitButton[0].text = "Exit";
            exitButton[0].font = engFont;
            exitButton[1].text = "Exit";
            exitButton[1].font = engFont;

            settingsTitle[0].text = "Settings";
            settingsTitle[0].font = engFont;
            settingsTitle[1].text = "Settings";
            settingsTitle[1].font = engFont;

            audioText[0].text = "Volume";
            audioText[0].font = engFont;
            audioText[1].text = "Volume";
            audioText[1].font = engFont;

            languageText[0].text = "Language";
            languageText[0].font = engFont;
            languageText[1].text = "Language";
            languageText[1].font = engFont;

            languageTextBox.text = "English";
            languageTextBox.font = engFont;
            languageTextItem.font = engFont;
            languageDropDown.options[0].text = "English";
            languageDropDown.options[1].text = "Vietnamese";

            backText[0].text = "Back";
            backText[0].font = engFont;
            backText[1].text = "Back";
            backText[1].font = engFont;

            creditsTitle[0].text = "Credits";
            creditsTitle[0].font = engFont;
            creditsTitle[1].text = "Credits";
            creditsTitle[1].font = engFont;

            mxtxPart.text = "All rights and characters belong to Mo Xiang Tong Xiu";
            mxtxPart.font = engFont;

            sythePart[0].text = "Text and scenario:";
            sythePart[0].font = engFont;
            sythePart[1].text = "Text and scenario:";
            sythePart[1].font = engFont;
            sytheName.font = engFont;

            chipPart[0].text = "Design and programming:";
            chipPart[0].font = engFont;
            chipPart[1].text = "Design and programming:";
            chipPart[1].font = engFont;
            chipName.font = engFont;

            musicPart[0].text = "Musics:";
            musicPart[0].font = engFont;
            musicPart[1].text = "Musics:";
            musicPart[1].font = engFont;

            for (int i = 0; i < songs.Length; i++)
            {
                songs[i].font = engFont;
            }
        }
        else if(languageStart == "Vietnamese")
        {
            gameTitle[0].text = "Giải cứu Ngụy Vô Tiện";
            gameTitle[0].font = vietFont;
            gameTitle[1].text = "Giải cứu Ngụy Vô Tiện";
            gameTitle[1].font = vietFont;

            playButton[0].text = "Chơi";
            playButton[0].font = vietFont;
            playButton[1].text = "Chơi";
            playButton[1].font = vietFont;

            settingsButton[0].text = "Cài đặt";
            settingsButton[0].font = vietFont;
            settingsButton[1].text = "Cài đặt";
            settingsButton[1].font = vietFont;

            creditsButton[0].text = "Danh đề";
            creditsButton[0].font = vietFont;
            creditsButton[1].text = "Danh đề";
            creditsButton[1].font = vietFont;

            exitButton[0].text = "Thoát";
            exitButton[0].font = vietFont;
            exitButton[1].text = "Thoát";
            exitButton[1].font = vietFont;

            settingsTitle[0].text = "Cài đặt";
            settingsTitle[0].font = vietFont;
            settingsTitle[1].text = "Cài đặt";
            settingsTitle[1].font = vietFont;

            audioText[0].text = "Âm lượng";
            audioText[0].font = vietFont;
            audioText[1].text = "Âm lượng";
            audioText[1].font = vietFont;

            languageText[0].text = "Ngôn ngữ";
            languageText[0].font = vietFont;
            languageText[1].text = "Ngôn ngữ";
            languageText[1].font = vietFont;

            languageTextBox.text = "Tiếng Việt";
            languageTextBox.font = vietFont;
            languageTextItem.font = vietFont;
            languageDropDown.options[0].text = "Tiếng Anh";
            languageDropDown.options[1].text = "Tiếng Việt";

            backText[0].text = "Quay lại";
            backText[0].font = vietFont;
            backText[1].text = "Quay lại";
            backText[1].font = vietFont;

            creditsTitle[0].text = "Danh đề";
            creditsTitle[0].font = vietFont;
            creditsTitle[1].text = "Danh đề";
            creditsTitle[1].font = vietFont;

            mxtxPart.text = "Toàn bộ quyền và nhân vật đều thuộc về Mặc Hương Đồng Khứu";
            mxtxPart.font = vietFont;

            sythePart[0].text = "Văn bản và kịch bản:";
            sythePart[0].font = vietFont;
            sythePart[1].text = "Văn bản và kịch bản:";
            sythePart[1].font = vietFont;
            sytheName.font = vietFont;

            chipPart[0].text = "Thiết kế và lập trình:";
            chipPart[0].font = vietFont;
            chipPart[1].text = "Thiết kế và lập trình:";
            chipPart[1].font = vietFont;
            chipName.font = vietFont;

            musicPart[0].text = "Nhạc:";
            musicPart[0].font = vietFont;
            musicPart[1].text = "Nhạc:";
            musicPart[1].font = vietFont;

            for (int i = 0; i < songs.Length; i++)
            {
                songs[i].font = vietFont;
            }
        }
    }


    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
