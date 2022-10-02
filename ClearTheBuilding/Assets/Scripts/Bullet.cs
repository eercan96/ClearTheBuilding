using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 8;
    public GameObject owner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;// local y a��s� ile i�lem yapt�k.
    }
    private void OnTriggerEnter(Collider other)//e�er mermi target componenti olmayan bir yere �arparsa yok et.�rn duvar
    {
        if (other.gameObject.GetComponent<Target>()==false)
        {
            Destroy(gameObject);
        }
    }
}
