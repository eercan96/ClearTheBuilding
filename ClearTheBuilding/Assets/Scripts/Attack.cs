using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject ammo;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private int maxAmmo = 5;
    private int ammoCount = 0;
    public int GetAmmo { get { return ammoCount; }
        set { ammoCount = value;
            if (ammoCount > maxAmmo) { ammoCount = maxAmmo; } } }

    [SerializeField] private float fireRate = 0.5f;//ne kadar sürede bir ateþ 
    private float currentFireRate = 0f;//þuanki atýþ deðeri

    void Start()
    {
        ammoCount = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentFireRate > 0f)
        {
            currentFireRate -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))//mouse sol týk 0 -orta týk 2 - sað týk 1
        {
            if (currentFireRate <= 0&& ammoCount>0)
            {
                Fire();
                print("ateþ");
            }

        }
        // print(transform.eulerAngles.y);//y açýsýnýn kaç derece olduðunu yazdýrýr.
    }
    private void Fire()
    {
        float difference = 180f - transform.eulerAngles.y;//Burada objenin derece olarak y açýsýnda rotationýndan 180 den çýkardýk.
        float targetRotation = -90f;
        if (difference >= 90f)//eðer 90 büyükse yani karakter sola dönük == karakter 0 ile 90 derecelik rotation açýsý arasýnda
        {//olduðunda mermi z rotationýnda -90 derece döner
            targetRotation = -90f;
        }
        else if (difference < 90f)//eðer 90 küçükse yani karakter saða dönük == karakter 270 ile 360 derecelik rotation açýsý arasýnda
        {//mermi prefabi 90 dere oduðu için ayný þekilde üretilir.
            targetRotation = 90f;
        }
        currentFireRate = fireRate;
        GameObject bulletClone = Instantiate(ammo, fireTransform.position, Quaternion.Euler(0f, 0f, targetRotation));
        bulletClone.GetComponent<Bullet>().owner = gameObject;//Amaç mermiyi kim oluþturduðunu bulmak. Takýlý olan scriptin game objesini owner içine attýk.
        ammoCount--;


    }
}
