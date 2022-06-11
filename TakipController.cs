using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TakipController : MonoBehaviour
{

    NavMeshAgent agent;
    public Transform hedefPlayer;
    GameManager manager;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        agent.destination = hedefPlayer.position;
    }

    public void OnTriggerEnter(Collider other)//dusman'in üzerine gelince
    {

        Destroy(agent);
        manager.aiHasar(1);

    }
    void Update()
    {
         

    }
}
