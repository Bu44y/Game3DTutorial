using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    Transform target;
    NavMeshAgent nav;
    Animator anim;
    GameManager manager;

    void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (manager == null)
        {
            GameObject temp = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            manager = temp.GetComponent<GameManager>();
        }
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.destination = target.position;
        if (nav.remainingDistance <= nav.stoppingDistance)
        {
            anim.SetBool("isAttack", true);
        }
        else
        {
            anim.SetBool("isAttack", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon"))
        {
            Destroy(other.gameObject);
            nav.isStopped = transform;
            anim.SetTrigger("isDeath");
            manager.killEnemy();
            StartCoroutine(removeEnemy());
        }
    }

    IEnumerator removeEnemy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
