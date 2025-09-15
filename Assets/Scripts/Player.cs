using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController character;
    public float speed = 6f;
    private Vector3 moveDirction;

    Animator anim;

    void Start()
    {
        character = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (character.isGrounded)
        {
            anim.SetBool("isWalk", false);
            moveDirction = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirction *= speed;
            if (Input.GetAxis("Horizontal") !=0 || Input.GetAxis("Vertical") != 0)
            {
                anim.SetBool("isWalk", true);
            }
            character.Move(moveDirction * Time.deltaTime);
            rotatePlayer();
        }
    }

    void rotatePlayer()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, -90f, 0.0f);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 90f, 0.0f);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, -180f, 0.0f);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        }
    }
}
