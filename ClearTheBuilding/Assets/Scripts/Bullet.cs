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
        transform.position += transform.up * speed * Time.deltaTime;// local y açýsý ile iþlem yaptýk.
    }
    private void OnTriggerEnter(Collider other)//eðer mermi target componenti olmayan bir yere çarparsa yok et.Örn duvar
    {
        if (other.gameObject.GetComponent<Target>()==false)
        {
            Destroy(gameObject);
        }
    }
}
