using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Health Settings")]
    public bool healthPowerUp = false;
    public int healthAmount = 1;
    [Header("Ammo Settings")]
    public bool ammoPowerUp = false;
    public int ammoAmount = 5;
    [Header("Transform Settings")]
    [SerializeField] Vector3 turnVector = Vector3.zero;
    [Header("Scale Setting")]
    [SerializeField] private float period = 2f;
    [SerializeField] Vector3 scaleVektor;
    private float scaleFactor;
    private Vector3 startVektor;
    void Start()
    {
        startVektor = transform.localScale;//B�y�kl�k de�erlerini vekt�rler tutar
        if (healthPowerUp==true&&ammoPowerUp==true)
        {
            healthPowerUp = false;
            ammoPowerUp = false;
        }
        else if (healthPowerUp==true)
        {
            ammoPowerUp = false;
        }
        else if (ammoPowerUp)
        {
            healthPowerUp = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(turnVector);//D�nme i�lemi
        SinusWave();
    }

    private void SinusWave()//Buraya bak
    {
        if (period<=0f)
        {
            period = 0.1f;
        }
        float cycle = Time.timeSinceLevelLoad / period;

        const float piX2 = Mathf.PI * 2;//De�i�meyecek de�er

        float sinusWave = Mathf.Sin(cycle * piX2);
        scaleFactor = sinusWave / 2 + 0.5f;
        Vector3 offset = scaleFactor * scaleVektor;
        transform.localScale = startVektor + offset;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;//E�er gelen gameobje player de�ilse kodun devam�n� okumaz geri d�ner.
        }
        if (healthPowerUp)
        {
            other.gameObject.GetComponent<Target>().GetHealth += healthAmount;
        }
        else if (ammoPowerUp)
        {
            other.gameObject.GetComponent<Attack>().GetAmmo += ammoAmount;
        }
        Destroy(gameObject);
    }
}
