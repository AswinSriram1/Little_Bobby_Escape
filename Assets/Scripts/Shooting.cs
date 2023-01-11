using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject arrowRight;
    [SerializeField] GameObject arrowLeft;
    [SerializeField] float leftspeed = -5.5f;
    [SerializeField] float rightSpeed = 5.5f;
    Rigidbody2D myRigidbody;

    /*Vector3 fp;
    Vector3 lp;
    float dragDistance;*/

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        //dragDistance = Screen.height * 10 / 100;
    }

    // Update is called once per frame
    void Update()
    {
        //ShootingArrow();
        /*if(Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                lp = touch.position;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                lp = touch.position;
                if(Mathf.Abs(lp.x-fp.x)>dragDistance||Mathf.Abs(lp.y - fp.y) > dragDistance)
                {
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {
                        if (lp.x > fp.x)
                        {
                            Debug.Log("right swipe");
                        }
                        else
                        {
                            Debug.Log("left swipe");
                        }
                    }
                    else
                    {
                        if (lp.y > fp.y)
                        {
                            Debug.Log("swipe up");
                        }
                        else
                        {
                            Debug.Log("down swipe");
                        }
                    }
                }
                else
                {
                    Debug.Log("tap");
                }
            }
        }*/
    }
    public void ShootLeft()
    {

        GameObject instiateLeftArrow = Instantiate(arrowLeft, transform.position, transform.rotation);
        instiateLeftArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(leftspeed, 0.0f);

    }
    public void shootRight()
    {
        GameObject instiaterightArrow = Instantiate(arrowRight, transform.position, transform.rotation);
        instiaterightArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(rightSpeed, 0.0f);
    }
}
