using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanController : MonoBehaviour
{
    GameManager manager;

    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnTriggerEnter(Collider other)//dusman'in �zerine gelince
    {
        Destroy(gameObject);
        manager.dusmanTemasiYemAzalmaSayisi(1);
    }
    void Update()
    {
        
    }
}
