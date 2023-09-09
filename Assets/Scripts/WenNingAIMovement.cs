using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WenNingAIMovement : MonoBehaviour
{
    [SerializeField] private GameObject allClaw;
    [SerializeField] private Animator enemyAnim;
    [SerializeField] private float enemySpeed;

    Vector3 allClawStartPos;
    float currentXScale;

    // Start is called before the first frame update
    void Start()
    {
        allClawStartPos = allClaw.transform.position;
        currentXScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (allClaw.transform.position.x > allClawStartPos.x + 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, allClaw.transform.position, enemySpeed * Time.deltaTime);
            enemyAnim.SetBool("walk", true);
        }
        else
        {
            enemyAnim.SetBool("walk", false);
        }

        if ((allClaw.transform.position.x - transform.position.x) <= 0)
        {
            transform.localScale = new Vector3(currentXScale, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(currentXScale * -1f, transform.localScale.y, transform.localScale.z);
        }
    }
}
