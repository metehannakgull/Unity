using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform kameraHedefi;//karakterim
    public Transform yardimci; //Kamerayý dönerken karakterim dönmesin istiyorum.
    public float kameraMesafe;//Karaktere mouse tekerleði ile zoom yapabilmek için
    void Start()
    {
        kameraHedefi = GameObject.Find("Player").transform; //karakterimi position deðerini tanýmladým.
        yardimci = GameObject.Find("yardimci").transform; //yardimci'nin position deðerini tanýmladým.

        yardimci.position = kameraHedefi.position; //Bu sayede oyun baþladýðýnda yardimci'miz playerla ayný konumda olduðunda kamera takibi daha saðlýklý oldu.
        yardimci.parent = kameraHedefi;//yardimci'nin Parent'ýnýn konumuna, karakterimin konumunu atadým.

        kameraMesafe = 2.0f; //kameranýn karaktere göre uzaklýðý
    }

    
    void LateUpdate() //Bütün update fonksiyonlarý çaðrýldýktan sonra lateupdate fonksiyonu çaðrýlýr.
    {
        float kameraYatayHareketAcisi = Input.GetAxis("Mouse X")*2; //Mouse'u x ekseninde hareket ettirdiðimde, kamera karakter açýsýnýn y eksenine göre dönmesi için tanýmladým.
        float kameraDikeyHareketAcisi = Input.GetAxis("Mouse Y")*2; // Mouse'u y ekseninde hareket ettirdiðimde, kamera karakter açýsýnýn x eksenine göre dönmesi için tanýmladým.

        kameraMesafe+= Input.GetAxis("Mouse ScrollWheel")*2;//kamerayý mouse tekerliði ile yakýnlaþtýrýp uzaklaþtýrabilmek için ekledim

        kameraHedefi.Rotate(0.0f, kameraYatayHareketAcisi,0.0f); //Kamerayý y ekseninde döndürme metotu
        yardimci.Rotate(kameraDikeyHareketAcisi, 0.0f, 0.0f); //Kamerayý x ekseninde döndürme metodu

        transform.position = yardimci.position - kameraHedefi.forward.normalized * kameraMesafe; //hareket halindeki karakterimin bulunduðu her konumdan çýkarma iþlemi yapýlarak,
                                                                                          //kameranýn karakter takibini saðladým.
        transform.position += yardimci.up.normalized * 3;//kameranýn 3 birim yukarda takip etmesi için
        transform.LookAt(yardimci);//Kamera'nýn bakacaðý yeri karakterimim konumu olarak ayarladým.
    }
}
