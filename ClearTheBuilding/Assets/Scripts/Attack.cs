using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject ammo;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private int ammoCount=5;
    [SerializeField] private float fireRate = 0.5f;//ne kadar s�rede bir ate� 
    private float currentFireRate = 0f;//�uanki at�� de�eri

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (currentFireRate > 0f)
        {
            currentFireRate -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))//mouse sol t�k 0 -orta t�k 2 - sa� t�k 1
        {
            if (currentFireRate <= 0&& ammoCount>0)
            {
                Fire();
                print("ate�");
            }

        }
        // print(transform.eulerAngles.y);//y a��s�n�n ka� derece oldu�unu yazd�r�r.
    }
    private void Fire()
    {
        float difference = 180f - transform.eulerAngles.y;//Burada objenin derece olarak y a��s�nda rotation�ndan 180 den ��kard�k.
        float targetRotation = -90f;
        if (difference >= 90f)//e�er 90 b�y�kse yani karakter sola d�n�k == karakter 0 ile 90 derecelik rotation a��s� aras�nda
        {//oldu�unda mermi z rotation�nda -90 derece d�ner
            targetRotation = -90f;
        }
        else if (difference < 90f)//e�er 90 k���kse yani karakter sa�a d�n�k == karakter 270 ile 360 derecelik rotation a��s� aras�nda
        {//mermi prefabi 90 dere odu�u i�in ayn� �ekilde �retilir.
            targetRotation = 90f;
        }
        currentFireRate = fireRate;
        Instantiate(ammo, fireTransform.position, Quaternion.Euler(0f, 0f, targetRotation));
        ammoCount--;


    }
}
