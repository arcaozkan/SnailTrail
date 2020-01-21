using System.Collections;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{

    static bool hasclover = false;
    static bool hascolorclover = false;
    public CharacterController2D controller;
    public Animator animator;

    public Joystick joystick; //FOR MOBILE

    public float runSpeed = 40f;
    public GameObject gameoverUI;
    public GameObject levelcompleteUI;
    public GameObject Stars;
    public int posx=15;
    public int posy=-9;
    float horizontalMove = 0f;

    bool jump = false;
    bool flag = false;
    bool isStar = false;
    bool player_dead = false;
    bool stardisappear = false;
    float timer = 0;

    public GameObject cloverofthislevel;
    public GameObject colorcloverofthislevel;
    public GameObject UIClover;
    public GameObject UIColorClover;

    private float ScreenWidth; //FOR MOBILE
    void Start()
    {
        ScreenWidth = Screen.width; //FOR MOBILE
        if (hasclover == true)
        {
            UIClover.SetActive(true);
            Destroy(cloverofthislevel);
        }

        if (hascolorclover == true)
        {
            Destroy(colorcloverofthislevel);
            UIColorClover.SetActive(true);
        }

        if (SceneManager.GetActiveScene().buildIndex == 1 && PlayerStats.clover1)
        {
            Destroy(cloverofthislevel);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2 && PlayerStats.clover2)
        {
            Destroy(cloverofthislevel);
        }

        if (SceneManager.GetActiveScene().buildIndex == 2 && PlayerStats.colorclover1)
        {
            Destroy(colorcloverofthislevel);
        }
    }

    void Update()
    {

        if (stardisappear)
        {
            if (timer < 3)
            {
                timer += Time.deltaTime;
            }
            else
            {
                Stars.SetActiveRecursively(true);
            }
        }

        if (player_dead == false)
        {
            //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed; //FOR PC
            //if (Input.GetButtonDown("Jump")) //FOR PC

            //{
            //    jump = true;
            //    animator.SetBool("isJumping", true);

            //}

            if (joystick.Horizontal >= .2f) //FOR MOBILE
            {
                horizontalMove = runSpeed;
            }
            else if (joystick.Horizontal <= -.2f)
            {
                horizontalMove = -runSpeed;
            }
            else
            {
                horizontalMove = 0f;
            }

            int i = 0; //FOR MOBILE
            while (i < Input.touchCount)
            {
                if (Input.GetTouch(i).position.x > ScreenWidth / 2)
                {
                    jump = true;
                    animator.SetBool("isJumping", true);
                }
                ++i;
            } //

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));



        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("coinsound");
        }

        if (other.gameObject.CompareTag("enemy"))
        {
            player_dead = true;
            animator.SetBool("dead", true);
            gameoverUI.SetActive(true);
            FindObjectOfType<AudioManager>().Play("hitsound");
            CoinManager.coins = 0;
        }

        if (other.gameObject.CompareTag("flag") && player_dead == false)
        {
            player_dead = true;
            flag = true;
            animator.SetBool("flag", true);
            levelcompleteUI.SetActive(true);
            FindObjectOfType<AudioManager>().Play("victory");


            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                if (PlayerStats.coins1 < CoinManager.coins)
                {
                    PlayerStats.coins1 = CoinManager.coins;
                }
                if (hasclover)
                {
                    PlayerStats.clover1 = hasclover;
                }
            }
            else if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                if (PlayerStats.coins2 < CoinManager.coins)
                {
                    PlayerStats.coins2 = CoinManager.coins;
                }
                if (hasclover)
                {
                    PlayerStats.clover2 = hasclover;
                }
                if (hascolorclover)
                {
                    PlayerStats.colorclover1 = hascolorclover;
                }

            }

            PlayerStats.level += 1; //TEMPORARY SOLUTION!!
            if (PlayerStats.level > 2)
            {
                PlayerStats.level = 2;
            }
            hasclover = false;
            hascolorclover = false;
            CoinManager.coins = 0;
            PlayerStats.SavePlayer();
        }
        if (other.gameObject.CompareTag("star"))
        {
            timer = 0;
            other.gameObject.SetActive(false);
            isStar = true;
            stardisappear = true;
            FindObjectOfType<AudioManager>().Play("star");
        }
        if (other.gameObject.CompareTag("clover"))
        {
            Destroy(other.gameObject);
            UIClover.SetActive(true);
            transform.position = new Vector3(posx, posy, 0);
            FindObjectOfType<AudioManager>().Play("clover");
            hasclover = true;
        }

        if (other.gameObject.CompareTag("colorclover"))
        {
            Destroy(other.gameObject);
            UIColorClover.SetActive(true);
            transform.position = new Vector3(posx, posy, 0);
            FindObjectOfType<AudioManager>().Play("clover");
            hascolorclover = true;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }
    void FixedUpdate()

    {

        // Move our character

        controller.Move(horizontalMove * Time.fixedDeltaTime, jump,ref isStar,flag);


        jump = false;

    }

}