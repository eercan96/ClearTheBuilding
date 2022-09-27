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
        if (Input.GetKeyDown(KeyCode.Space) && OnGroundCheck())//Bir tuþa bastýðýmýz saniye çalýþýr 1 kez çalýþýr.(getkeydown)
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, Mathf.Clamp((jumpPower * 100) * Time.deltaTime, 0f, 15f), 0f);
        }

        if (Input.GetKey(KeyCode.A))//Bastýðýmda ve basýlý tuttuðumda çalýþýr.
        {
            //rigidbody.velocity.y dememizin nedini tekrardan 0 deðeri atarsak çapraz zýplama olmaz sadece düz zýplar.
            rigidbody.velocity = new Vector3(Mathf.Clamp((speed * 100) * Time.deltaTime, 0f, 15f), rigidbody.velocity.y, 0f);
            //transform.rotation = Quaternion.Euler(0f, 90f, 0f) ;//euler e sayýsýdýr. //Bu kod sayesinde istedðimiz tarafa dönme imkaný buluruz.
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 89.9f, 0f), turnSpeed * Time.deltaTime);//Bize çizgisel bir dönüþ saðlar .(Quaternion.Lerp)Dönme iþlemini yapraken neresi daha yakýn ise oradan yapar.O yüzden 89.9 yapalabilir. 



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
    private bool OnGroundCheck()//Bu metod ile altýmýzda zemin varsa zýpla dememiz gerek yoksa üst üste zýplama yapýlýr.
    {
      
        bool hit = false;
        for (int i = 0; i < rayStartPoints.Length; i++)
        {
            hit = Physics.Raycast(rayStartPoints[i].position, -rayStartPoints[i].transform.up, 0.25f);//ilk posiyon sonra yön sonra mesafe(..float mesafeye kadar zýplama demektir.)
           Debug.DrawRay(rayStartPoints[i].position, -rayStartPoints[i].transform.up * 0.25f, Color.red);//Bu kod ile debug mod da ýþýný görebiliriz.
            //Vector3.down ==>global açýda -1 verir buyüzden bütün raycastler ayný yere bakar çünkü raycastlerimizi biz local olarak deðiþtirdik.
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
