using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    public static Player instance;

    //config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float JumpSpeed = 15f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(1f,15f) ;
    [SerializeField] GameObject inputs;
    [SerializeField] GameObject scoreCheck;
    [SerializeField] GameObject arrow;
    [SerializeField] GameObject cameraShake;


    //State
    bool isAlive = true;

    //Cached components
    [SerializeField] Rigidbody2D rbArrow;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBody;
    BoxCollider2D myfeet;
    float gravityScaleStart;
    sccreChecker scorechecker;

    //methods
    void Start()
    {
        rbArrow = arrow.GetComponent<Rigidbody2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBody = GetComponent<CapsuleCollider2D>();
        myfeet = GetComponent<BoxCollider2D>();
        gravityScaleStart = myRigidbody.gravityScale;
        //scorechecker = GameObject.Find("ScoreChecker").GetComponent<sccreChecker>();
        scorechecker = FindObjectOfType<sccreChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }

        Run();
        ClimbLadder();
        //Jump();
        flipSprite();
        Die();
        //shoot();
        
    }
    void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow*runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        bool playerHasHorizontal = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontal);
    }
    void ClimbLadder()
    {
        if (!myfeet.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myAnimator.SetBool("Climbing", false);
            myRigidbody.gravityScale = gravityScaleStart;
            return;
        }

        float controlThrow = CrossPlatformInputManager.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, controlThrow * climbSpeed);
        myRigidbody.velocity = climbVelocity;
        myRigidbody.gravityScale = 0f;

        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("Climbing",playerHasVerticalSpeed);
        
    }

    public void Jump()
    {
        if (!myfeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        //if (CrossPlatformInputManager.GetButtonDown("Jump"))
        //{
            Vector2 jumpVelocityAdd = new Vector2(0f, JumpSpeed);
            myRigidbody.velocity += jumpVelocityAdd;
        //}
              
    }
    void Die()
    {
        if (myBody.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            cameraShake.SetActive(true);
            Vibration.Vibrate(300);
            //tartCoroutine(Dies());
            scorechecker.checker = true;
            Destroy(scoreCheck);
            isAlive = false;
            myAnimator.SetTrigger("Dying");
            inputs.SetActive(false);
            GetComponent<Rigidbody2D>().velocity = deathKick;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
            scorechecker.checker = true;
            AdsForLosing.instance.CalculatingScene();
        }
    }
    /*IEnumerator Dies()
    {
        myAnimator.SetTrigger("Dying");
        yield return new WaitForSeconds(1f);
        scorechecker.checker = true;
        Destroy(scoreCheck);
        isAlive = false;
        
        inputs.SetActive(false);
        GetComponent<Rigidbody2D>().velocity = deathKick;
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
        scorechecker.checker = true;
    }*/

    public void shoot()
    {
        myAnimator.SetBool("Shooting", true);
        StartCoroutine(shooting());
        //return;

    }
    IEnumerator shooting()
    {
       
        //GameObject instiateArrow = Instantiate(arrow, transform.position, transform.rotation);
        //instiateArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(-1.0f, 0.0f);

        yield return new WaitForSeconds(0.4f);
        myAnimator.SetBool("Shooting", false);
    }

    void flipSprite()
    {
        bool playerHasHorizontal = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontal)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }
}
