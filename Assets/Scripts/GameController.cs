using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Image imgJoystickBg;
    [SerializeField] private Image imgJoystick;
    [SerializeField] private Vector2 posInput;
    [SerializeField] private float joystickSpeed;

    [SerializeField] private GameObject claw, clawRotate;
    [SerializeField] private float clawSpeed;
    [SerializeField] private float minClawValue, maxClawValue;

    [SerializeField] private Animator clawAnim;

    [SerializeField] private AudioSource startSFX, duringSFX, duringSFX2, endSFX;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        KeyboardMovement();

    }

    public void KeyboardMovement()
    {
            if (Input.GetKey(KeyCode.A))
            {
                imgJoystick.transform.rotation = Quaternion.Euler(0, 0, -2 * joystickSpeed * (-1.0f));
                //claw.transform.Translate(Vector3.left * clawSpeed * Time.deltaTime);
                claw.GetComponent<Rigidbody2D>().AddForce(new Vector2(clawSpeed * -1 * Time.deltaTime, 0));

                clawAnim.Play("ClawAnimLeft", 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                imgJoystick.transform.rotation = Quaternion.Euler(0, 0, 2 * joystickSpeed * (-1.0f));
                //claw.transform.Translate(Vector3.right * clawSpeed * Time.deltaTime);
                claw.GetComponent<Rigidbody2D>().AddForce(new Vector2(clawSpeed * Time.deltaTime, 0));

                clawAnim.Play("ClawAnimRight", 0);
            }


            if (Input.GetKeyUp(KeyCode.D))
            {
                imgJoystick.transform.rotation = Quaternion.Euler(0, 0, 0);
                clawAnim.Play("ClawAnimRightEnd", 0);

                claw.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                endSFX.Play();
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                imgJoystick.transform.rotation = Quaternion.Euler(0, 0, 0);
                clawAnim.Play("ClawAnimLeftEnd", 0);

                claw.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                endSFX.Play();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                claw.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                StartCoroutine(DelayFreeze());
                startSFX.Play();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                claw.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                StartCoroutine(DelayFreeze());
                startSFX.Play();
            }
        

        
    }

    IEnumerator DelayFreeze()
    {
        yield return new WaitForSeconds(0.1f);
        claw.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

}
