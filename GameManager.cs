using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int yemPuani;
    public int yemPuani2;
    public Text textYemMiktari;
   
    public int sabitYemMiktari;
    public int dusmanYemAzalt;
    public int ai;


    void Start()
    {
        textYemMiktari = GameObject.Find("yemPuani").GetComponent<Text>(); //yemMiktari UI'yini tanýttýk. yani canvas'ý tanýttýk
        
    }

   public void yenilenYemSayisi(int yemPuani)
    {
        this.yemPuani += yemPuani;
        yemPuani2 += yemPuani;
        textYemMiktari.text = " Yem Puani:" + this.yemPuani; //Yenilen yem sayýsýný ekranda yazdýrdýk.
    }
    public void yenilensabitYemSayisi(int sabitYemMiktari)
    {
        this.sabitYemMiktari += sabitYemMiktari;
        this.yemPuani = this.yemPuani - sabitYemMiktari;
        textYemMiktari.text = " Yem Puani:" + this.yemPuani;
    }
    public void dusmanTemasiYemAzalmaSayisi(int dusmanYemAzalt)
    {
        this.dusmanYemAzalt += dusmanYemAzalt;
        this.yemPuani = this.yemPuani - dusmanYemAzalt;
        textYemMiktari.text = " Yem Puani:" + this.yemPuani;
    }

    public void aiHasar(int ai)
    {
        this.ai += ai;
        this.yemPuani = this.yemPuani - ai;
        textYemMiktari.text = " Yem Puani:" + this.yemPuani;
    }
   
    void Update()
    {
        
       
    }
}
