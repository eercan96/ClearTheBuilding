using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 13f;
    [SerializeField] private float turnSpeed = 15f;
    [SerializeField] private Transform[] rayStartPoints;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        TakeInput();
        //print(OnGroundCheck());
        

    }
    private void TakeInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnGroundCheck())//Bir tu�a bast���m�z saniye �al���r 1 kez �al���r.(getkeydown)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, Mathf.Clamp((jumpPower * 100) * Time.deltaTime, 0f, 15f), 0f);
        }

        if (Input.GetKey(KeyCode.A))//Bast���mda ve bas�l� tuttu�umda �al���r.
        {
            //rigidbody.velocity.y dememizin nedini tekrardan 0 de�eri atarsak �apraz z�plama olmaz sadece d�z z�plar.
            rigidbody.velocity = new Vector3(Mathf.Clamp((speed * 100) * Time.deltaTime, 0f, 15f), rigidbody.velocity.y, 0f);
            //transform.rotation = Quaternion.Euler(0f, 90f, 0f) ;//euler e say�s�d�r. //Bu kod sayesinde isted�imiz tarafa d�nme imkan� buluruz.
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 89.9f, 0f), turnSpeed * Time.deltaTime);//Bize �izgisel bir d�n�� sa�lar .(Quaternion.Lerp)D�nme i�lemini yapraken neresi daha yak�n ise oradan yapar.O y�zden 89.9 yapalabilir. 



        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector3(Mathf.Clamp((-speed * 100) * Time.deltaTime, -15f, 0f), rigidbody.velocity.y, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, -89.9f, 0f), turnSpeed * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(0f, -90f, 0f);

        }
        else
        {
            rigidbody.velocity = new Vector3(0f, rigidbody.velocity.y, 0f);
        }
    }
    private bool OnGroundCheck()//Bu metod ile alt�m�zda zemin varsa z�pla dememiz gerek yoksa �st �ste z�plama yap�l�r.
    {
      
        bool hit = false;
        for (int i = 0; i < rayStartPoints.Length; i++)
        {
            hit = Physics.Raycast(rayStartPoints[i].position, -rayStartPoints[i].transform.up, 0.25f);//ilk posiyon sonra y�n sonra mesafe(..float mesafeye kadar z�plama demektir.)
           Debug.DrawRay(rayStartPoints[i].position, -rayStartPoints[i].transform.up * 0.25f, Color.red);//Bu kod ile debug mod da ���n� g�rebiliriz.
            //Vector3.down ==>global a��da -1 verir buy�zden b�t�n raycastler ayn� yere bakar ��nk� raycastlerimizi biz local olarak de�i�tirdik.
        }
        
        if (hit)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
