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

    public float fireRate = 0.4f;
    public float nextFire = 0.0f;

    public GameObject spawnPoint,weapon;

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
            playerAttack();
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

    void playerAttack()
    {
        if (Input.GetMouseButton(0) && Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            shootWeapon();
        }
    }

    void shootWeapon()
    {
        anim.SetBool("isAttack",true);
        StartCoroutine(resetAttack());
    }

    IEnumerator resetAttack()
    {
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("isAttack", false);
    }

    void createArrow()
    {
        Instantiate(weapon, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }
}
