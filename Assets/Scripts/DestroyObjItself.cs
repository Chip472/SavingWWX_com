using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjItself : MonoBehaviour
{
    [SerializeField] private GameObject self;

    public void DestroyItself()
    {
        self.SetActive(false);
    }
}
