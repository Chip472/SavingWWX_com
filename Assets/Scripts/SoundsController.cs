using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsController : MonoBehaviour
{

    [SerializeField] private GameObject onSoundButton, offSoundButton;

    // Start is called before the first frame update
    void Start()
    {
        if (AudioListener.volume == 0)
        {
            onSoundButton.SetActive(false);
            offSoundButton.SetActive(true);
        }
        else
        {
            onSoundButton.SetActive(true);
            offSoundButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OffSound()
    {
        AudioListener.volume = 0;
        onSoundButton.SetActive(false);
        offSoundButton.SetActive(true);
    }

    public void OnSound()
    {
        onSoundButton.SetActive(true);
        offSoundButton.SetActive(false);
        AudioListener.volume = 1;
    }
}
