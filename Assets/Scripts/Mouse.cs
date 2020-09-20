using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class Mouse : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        agent = transform.GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        agent.SetDestination(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0) {
            agent.SetDestination(player.transform.position);
        }
        else {
            timer -= Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag.Equals("trap")) {
            GameObject.Find(collision.gameObject.name).GetComponent<mouseTrap>().hit();
            timer = 5;
            agent.SetDestination(transform.position);
        }
    }
}
