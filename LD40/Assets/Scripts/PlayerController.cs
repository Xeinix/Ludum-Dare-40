using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    #region Scene Vars

    public int goldReqired;
    private int sceneScore = 0;

    public GameObject uiDeath;
    public GameObject uiLose;
    public GameObject uiWin;

    #endregion

    #region Player vars

    private bool isPlaying = false;
    private bool isDead = false;

    public float moveForceY = 0.5f;
    public float moveForceX = 0.5f;
    public float charWeight = 5;

    public Rigidbody2D rb;

    #endregion

    #region Sound Vars

    public AudioClip goldPickup;
    public AudioClip blackPickup;

    public AudioSource audioS;

    #endregion

    void Start()
    {
        Debug.Log("Player Controller Loaded.");

        rb.gravityScale = 0;
    }

    void FixedUpdate()
    {
        if (!isPlaying && !isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.Mouse0)){
                rb.gravityScale = 1;

                Vector2 vec2 = new Vector2(0, moveForceY);
                rb.velocity = vec2;
                isPlaying = true;
            }
        }

        if (isPlaying)
        {
            rb.gravityScale = charWeight;

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("Move Character Up.");
                Vector2 vec2 = new Vector2(0, moveForceY);

                rb.velocity = vec2;
            }
            else
            {
                Vector2 vec2 = new Vector2(moveForceX, rb.velocity.y);
                rb.velocity = vec2;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "nuggGold")
        {
            sceneScore += 1;
            audioS.PlayOneShot(goldPickup);
            Destroy(collision.gameObject);
            Debug.Log("Golden Nuggets Collected: " + sceneScore);
        }
        if (collision.gameObject.tag == "nuggBlack")
        {
            charWeight += .3f;
            audioS.PlayOneShot(blackPickup);
            Destroy(collision.gameObject);
            Debug.Log("Player weight now:" + charWeight);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "walls") Debug.Log("Player Died");  Death();

        if (collision.gameObject.tag == "end")
        {
            if (goldReqired <= sceneScore)
            {
                Win();
            }
            else
            {
                Lose();
            }
        }
    }

    void Death()
    {
        rb.gravityScale = 0;
        isPlaying = false;
        isDead = true;
        rb.velocity = new Vector2(0, 0);

        uiDeath.SetActive(true);

        // SceneManager.LoadScene(0);
    }

    void Win()
    {
        rb.gravityScale = 0;
        isPlaying = false;
        isDead = true;
        rb.velocity = new Vector2(0, 0);

        uiLose.SetActive(true);
    }
    void Lose()
    {
        rb.gravityScale = 0;
        isPlaying = false;
        isDead = true;
        rb.velocity = new Vector2(0, 0);

        uiWin.SetActive(true);

    }
}
