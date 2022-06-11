using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform kameraHedefi;//karakterim
    public Transform yardimci; //Kameray� d�nerken karakterim d�nmesin istiyorum.
    public float kameraMesafe;//Karaktere mouse tekerle�i ile zoom yapabilmek i�in
    void Start()
    {
        kameraHedefi = GameObject.Find("Player").transform; //karakterimi position de�erini tan�mlad�m.
        yardimci = GameObject.Find("yardimci").transform; //yardimci'nin position de�erini tan�mlad�m.

        yardimci.position = kameraHedefi.position; //Bu sayede oyun ba�lad���nda yardimci'miz playerla ayn� konumda oldu�unda kamera takibi daha sa�l�kl� oldu.
        yardimci.parent = kameraHedefi;//yardimci'nin Parent'�n�n konumuna, karakterimin konumunu atad�m.

        kameraMesafe = 2.0f; //kameran�n karaktere g�re uzakl���
    }

    
    void LateUpdate() //B�t�n update fonksiyonlar� �a�r�ld�ktan sonra lateupdate fonksiyonu �a�r�l�r.
    {
        float kameraYatayHareketAcisi = Input.GetAxis("Mouse X")*2; //Mouse'u x ekseninde hareket ettirdi�imde, kamera karakter a��s�n�n y eksenine g�re d�nmesi i�in tan�mlad�m.
        float kameraDikeyHareketAcisi = Input.GetAxis("Mouse Y")*2; // Mouse'u y ekseninde hareket ettirdi�imde, kamera karakter a��s�n�n x eksenine g�re d�nmesi i�in tan�mlad�m.

        kameraMesafe+= Input.GetAxis("Mouse ScrollWheel")*2;//kameray� mouse tekerli�i ile yak�nla�t�r�p uzakla�t�rabilmek i�in ekledim

        kameraHedefi.Rotate(0.0f, kameraYatayHareketAcisi,0.0f); //Kameray� y ekseninde d�nd�rme metotu
        yardimci.Rotate(kameraDikeyHareketAcisi, 0.0f, 0.0f); //Kameray� x ekseninde d�nd�rme metodu

        transform.position = yardimci.position - kameraHedefi.forward.normalized * kameraMesafe; //hareket halindeki karakterimin bulundu�u her konumdan ��karma i�lemi yap�larak,
                                                                                          //kameran�n karakter takibini sa�lad�m.
        transform.position += yardimci.up.normalized * 3;//kameran�n 3 birim yukarda takip etmesi i�in
        transform.LookAt(yardimci);//Kamera'n�n bakaca�� yeri karakterimim konumu olarak ayarlad�m.
    }
}
