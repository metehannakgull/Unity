using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yem4Controller : MonoBehaviour
{
    GameManager manager;

    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnTriggerEnter(Collider other)//yem'in üzerine gelince
    {
        Destroy(gameObject);
        manager.yenilensabitYemSayisi(1);
    }
        void Update()
    {
         
    }
}
