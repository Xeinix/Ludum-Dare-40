using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour {
    


    #region Player vars

    public float moveForceY = 0.5f;
    public float moveForceX = 0.5f;
    public float charWeight = 5;

    public Rigidbody2D rb;

    #endregion

    void Start () {
        Debug.Log("Player Controller Loaded.");
	}
	
	void FixedUpdate () {

        rb.mass = charWeight;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "nuggGold")
        {
            Debug.Log("Add in nugget pickup.");
        }
        if (collision.gameObject.tag == "nuggBlack")
        {
            Debug.Log("Add in nugget pickup.");
        }
    }
}
