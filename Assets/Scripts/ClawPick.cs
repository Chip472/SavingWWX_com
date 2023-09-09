using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawPick : MonoBehaviour
{
    [SerializeField] private GameObject buttonUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            buttonUp.SetActive(false);
        }
        else
        {
            buttonUp.SetActive(true);
        }
    }
}
