using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float yurumeHiziCarpani; //karakter y�r�me durumu hareket h�z� i�in
    float kosmaHiziCarpani;  //Karakter ko�ma durumu hareket h�z� i�in
    Vector3 karakterHareket; //karakterimizin position bilgisi de�i�imi i�in
    float aktifHizCarpani;//tu�a bas�nca ve basmay�nca aktif h�z i�in
    CharacterController charController; //characterController componenti kullan�m� i�in
    float yerCekimiSabiti; //yer �ekimi ayarlamas� i�in
    float zemindeYerCekimiSabiti; //yer �ekimi ayarlamas� i�in
    float maksimumSicramaYuksekligi; //yukseklik ayarlamas� i�in
    float maksimumSicramaSuresi;//karakter z�plamay� ne kadar s�rede tamamlayacak onun kullan�m� i�in
    float baslangicSicramaHizi;//karakterin s��ramaya ba�lamadan �nceki h�z�
    

    Animator animator; //karakter animasyonlar� i�in
    public bool yuruyormu; //Animator'de olu�turdu�um animasyon y�r�me de�i�kenim
    public bool kosuyormu; //Animator'de olu�turdu�um animasyon ko�ma de�i�kenim
    void Start()
    {
        charController = GetComponent<CharacterController>(); //CharacterController component'imi tan�mlad�m.
        animator = GetComponent<Animator>();
        yurumeHiziCarpani = 2.0f;
        kosmaHiziCarpani = yurumeHiziCarpani * 3.0f;
        aktifHizCarpani = yurumeHiziCarpani;
        maksimumSicramaYuksekligi = 2.0f;
        maksimumSicramaSuresi = 1.0f;
        
        zemindeYerCekimiSabiti = -0.05f; //sicrama form�l

        float karakterinZirveyeSicramaSuresi = maksimumSicramaSuresi / 2.0f; //sicrama form�l
        yerCekimiSabiti = (-2.0f * maksimumSicramaYuksekligi) / (karakterinZirveyeSicramaSuresi * karakterinZirveyeSicramaSuresi); //sicrama form�l
        baslangicSicramaHizi = 2 * maksimumSicramaYuksekligi / karakterinZirveyeSicramaSuresi;//sicrama form�l
        
        

    }

    void hiz()//karakter h�z fonksiyonum
    {

        yuruyormu = false;//ba�lang�� de�erini false atad�m
        kosuyormu = false;//ba�lang�� de�erini false atad�m
        float oncekiYhizi = karakterHareket.y;//Eski y de�erini tutmad���mda karakterim yava� yava� yere do�ru iniyor. Ben oyun ba�lang�c�nda direk inmesini istiyorum.

        if(Input.GetKeyDown(KeyCode.LeftShift)) //ko�ma
        {
            aktifHizCarpani = kosmaHiziCarpani;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))//ko�may� b�rakma
        {
            aktifHizCarpani = yurumeHiziCarpani;
        }

    Vector3 ileriHareket = transform.forward.normalized * Input.GetAxis("Vertical") * aktifHizCarpani;//ileri tu�u ve w i�in "pozitif", geri ve s tu�u i�in "negatif" de�er verir.
    Vector3 sagHareket = transform.right.normalized * Input.GetAxis("Horizontal") * aktifHizCarpani;//sag tu�u ve d i�in "pozitif", sol ve a tu�u i�in "negatif" de�er verir.
                                                                                                    //1'e indirgenen yer.

    karakterHareket = ileriHareket + sagHareket; //toplam hareket vekt�r�

    if (aktifHizCarpani== kosmaHiziCarpani)
        {
            kosuyormu = true;
        }
    else
    {
        if(karakterHareket.x !=0|| karakterHareket.z!=0)
        {
            yuruyormu = true;
        }
    }

        
      
        karakterHareket.y = oncekiYhizi; // yukar�daki toplam vekt�r�nde x de�i�imi var. y=0 d�r. �imdi y de�i�imini katm�� oldum.
    

    }
   
    void sicrama()
    {
        if(Input.GetKeyDown(KeyCode.Space)) //space tu�una bas�ld�ysa
        {
            if(charController.isGrounded) //bu ko�ul ile karakterin havadayken tekrar s��ramas�n� engelledim
            {
                karakterHareket.y = baslangicSicramaHizi;
            }
        }
    }

    void yerCekimi()
    {
        if(charController.isGrounded) //CharakterController zeminde mi kontrol edelim
        {
            karakterHareket.y += zemindeYerCekimiSabiti; //zemindeyse ekleme yap
        }
        else//karakter havadaysa
        {
            karakterHareket.y += yerCekimiSabiti*Time.deltaTime;
        }
    }
    
    void animasyonDegisimi() //Animator'de olu�turdu�um animasyon yurume ve ko�ma de�i�kenleri
    {
       animator.SetBool("yuruyormu",yuruyormu);
       animator.SetBool("kosuyormu", kosuyormu);


    }

    void Update()
    {
        hiz(); //karakter h�z fonksiyonumu �a��rd�m.
        yerCekimi();//karakterimin yer�ekimi fonksiyonunu �a��rd�m.
        sicrama();//karakterimin sicrama fonksiyonunu �a��rd�m.
        animasyonDegisimi(); //karakterimin animasyon de�i�imini fonksiyonunu �a��rd�m.
        charController.Move(karakterHareket*Time.deltaTime); //Art�k karakterin konumu(position de�eri) tu�lara bas�ld�k�a de�i�ecek.
                                                             //Time.deltaTime ile �arparak h�zla �arp�lan de�erlerimi zamana g�re k�s�tlad�m. B�ylece karakterim yava�lad�.
                                                             //"transform.position+=karakterHareket*Time.deltaTime" yerine "charController.Move(karakterHareket*Time.deltaTime);" kulland�m
    }
}
