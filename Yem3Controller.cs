using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yem3Controller : MonoBehaviour
{
    GameManager manager;
    void Start()
    {
        manager=GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnTriggerEnter(Collider other)//yem'in �zerine gelince
    {
       // Debug.Log(other.name); //yem'in �zerine gelince mesaj yaz
        Destroy(gameObject);
        manager.yenilenYemSayisi(1);
     

    }
    public void OnTriggerExit(Collider other) //yem'in �zerinden ayr�l�nca
    {

         
    }

    void Update()
    {
        
    }
}
