using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float yurumeHiziCarpani; //karakter yürüme durumu hareket hýzý için
    float kosmaHiziCarpani;  //Karakter koþma durumu hareket hýzý için
    Vector3 karakterHareket; //karakterimizin position bilgisi deðiþimi için
    float aktifHizCarpani;//tuþa basýnca ve basmayýnca aktif hýz için
    CharacterController charController; //characterController componenti kullanýmý için
    float yerCekimiSabiti; //yer çekimi ayarlamasý için
    float zemindeYerCekimiSabiti; //yer çekimi ayarlamasý için
    float maksimumSicramaYuksekligi; //yukseklik ayarlamasý için
    float maksimumSicramaSuresi;//karakter zýplamayý ne kadar sürede tamamlayacak onun kullanýmý için
    float baslangicSicramaHizi;//karakterin sýçramaya baþlamadan önceki hýzý
    

    Animator animator; //karakter animasyonlarý için
    public bool yuruyormu; //Animator'de oluþturduðum animasyon yürüme deðiþkenim
    public bool kosuyormu; //Animator'de oluþturduðum animasyon koþma deðiþkenim
    void Start()
    {
        charController = GetComponent<CharacterController>(); //CharacterController component'imi tanýmladým.
        animator = GetComponent<Animator>();
        yurumeHiziCarpani = 2.0f;
        kosmaHiziCarpani = yurumeHiziCarpani * 3.0f;
        aktifHizCarpani = yurumeHiziCarpani;
        maksimumSicramaYuksekligi = 2.0f;
        maksimumSicramaSuresi = 1.0f;
        
        zemindeYerCekimiSabiti = -0.05f; //sicrama formül

        float karakterinZirveyeSicramaSuresi = maksimumSicramaSuresi / 2.0f; //sicrama formül
        yerCekimiSabiti = (-2.0f * maksimumSicramaYuksekligi) / (karakterinZirveyeSicramaSuresi * karakterinZirveyeSicramaSuresi); //sicrama formül
        baslangicSicramaHizi = 2 * maksimumSicramaYuksekligi / karakterinZirveyeSicramaSuresi;//sicrama formül
        
        

    }

    void hiz()//karakter hýz fonksiyonum
    {

        yuruyormu = false;//baþlangýç deðerini false atadým
        kosuyormu = false;//baþlangýç deðerini false atadým
        float oncekiYhizi = karakterHareket.y;//Eski y deðerini tutmadýðýmda karakterim yavaþ yavaþ yere doðru iniyor. Ben oyun baþlangýcýnda direk inmesini istiyorum.

        if(Input.GetKeyDown(KeyCode.LeftShift)) //koþma
        {
            aktifHizCarpani = kosmaHiziCarpani;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))//koþmayý býrakma
        {
            aktifHizCarpani = yurumeHiziCarpani;
        }

    Vector3 ileriHareket = transform.forward.normalized * Input.GetAxis("Vertical") * aktifHizCarpani;//ileri tuþu ve w için "pozitif", geri ve s tuþu için "negatif" deðer verir.
    Vector3 sagHareket = transform.right.normalized * Input.GetAxis("Horizontal") * aktifHizCarpani;//sag tuþu ve d için "pozitif", sol ve a tuþu için "negatif" deðer verir.
                                                                                                    //1'e indirgenen yer.

    karakterHareket = ileriHareket + sagHareket; //toplam hareket vektörü

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

        
      
        karakterHareket.y = oncekiYhizi; // yukarýdaki toplam vektöründe x deðiþimi var. y=0 dýr. Þimdi y deðiþimini katmýþ oldum.
    

    }
   
    void sicrama()
    {
        if(Input.GetKeyDown(KeyCode.Space)) //space tuþuna basýldýysa
        {
            if(charController.isGrounded) //bu koþul ile karakterin havadayken tekrar sýçramasýný engelledim
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
    
    void animasyonDegisimi() //Animator'de oluþturduðum animasyon yurume ve koþma deðiþkenleri
    {
       animator.SetBool("yuruyormu",yuruyormu);
       animator.SetBool("kosuyormu", kosuyormu);


    }

    void Update()
    {
        hiz(); //karakter hýz fonksiyonumu çaðýrdým.
        yerCekimi();//karakterimin yerçekimi fonksiyonunu çaðýrdým.
        sicrama();//karakterimin sicrama fonksiyonunu çaðýrdým.
        animasyonDegisimi(); //karakterimin animasyon deðiþimini fonksiyonunu çaðýrdým.
        charController.Move(karakterHareket*Time.deltaTime); //Artýk karakterin konumu(position deðeri) tuþlara basýldýkça deðiþecek.
                                                             //Time.deltaTime ile çarparak hýzla çarpýlan deðerlerimi zamana göre kýsýtladým. Böylece karakterim yavaþladý.
                                                             //"transform.position+=karakterHareket*Time.deltaTime" yerine "charController.Move(karakterHareket*Time.deltaTime);" kullandým
    }
}
