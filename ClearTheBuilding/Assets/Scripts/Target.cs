using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int maxHealth = 2;
    private int currentHealth;
    public int GetHealth {
        get 
        {
            return currentHealth;
        } 
        set 
        {
            currentHealth = value;
            if (currentHealth>maxHealth)
            {
                currentHealth = maxHealth;
            }
        } 
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.gameObject.GetComponent<Bullet>();
        if (bullet)//Box a temas eden cismin componentinde bullet scripti var m�?
        {
            if (bullet && bullet.owner !=gameObject)//E�er mermiyi ate�leyen scriptin gameobjesi ile ayn� de�ilse kodu oku
            {
                currentHealth--;
                if (currentHealth <= 0)
                {
                    Die();
                }
                Destroy(other.gameObject);
            }
            
        }
    }
    private void Die()//Tak�l� oldu�u objeyi yok eder.
    {
        Destroy(gameObject);
    }
}
