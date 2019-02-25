using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    public float moveSpeed;
    private bool isMoving;
    private Vector2 lastMove;
    private Animator anim;
    private Rigidbody2D rb;

    public GameObject curObj = null;


    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        isMoving = false;

        //GetAxisRaw will return a value of -1 for left, 0 for none, and 1 for right.
        float moveHorizontal = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        float moveVertical = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

        //Multiplying by deltaTime didn't change the direction
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            isMoving = true;
            lastMove = new Vector2(moveHorizontal, moveVertical);
        }

        //Vector3 is made of 3 values: x, y, z. Z-axis isn't used in a 2D game thus can be left blank or have 0f.
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, Input.GetAxisRaw("Vertical") * moveSpeed);
        //transform.Translate(new Vector3(moveHorizontal, moveVertical, 0f));

        //Set the animator's MoveX and MoveY parameters to the player's input, also update the playing moving boolean
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("IsMoving", isMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

        //On the press of the Interact button (Default: E), interact with object if possible
        if (Input.GetButtonDown("Interact") && curObj && curObj.GetComponent<Furnace>().isInteractable)
        {
            curObj.SendMessage("Interact");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");

        if(collision.gameObject.tag.Equals("Interactable"))
        {
            Debug.Log("Interactable");
            curObj = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == curObj)
        {
            Debug.Log("Left the range");
            curObj = null;
        }
    }
}
