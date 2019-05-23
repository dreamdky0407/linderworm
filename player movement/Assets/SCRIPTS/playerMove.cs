
using UnityEngine;

public class playerMove : MonoBehaviour
{
   
    private float speed = 1f;
    private playermotor motor;
    private float looksens = 2f;

    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<playermotor>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {


            float xmov = Input.GetAxisRaw("Horizontal");
            float zmov = Input.GetAxisRaw("Vertical");

            Vector3 movX = transform.right * xmov;
            Vector3 movZ = transform.forward * zmov;

            Vector3 velo = (movX + movZ).normalized * speed * 2;
            motor.Move(velo);

            float yRot = Input.GetAxisRaw("Mouse X");
            Vector3 rotation = new Vector3(0f, yRot, 0f) * looksens;

            motor.Rotate(rotation);
        }
         else if(Input.GetKey(KeyCode.LeftControl))
        {
            float xmov = Input.GetAxisRaw("Horizontal");
            float zmov = Input.GetAxisRaw("Vertical");

            Vector3 movX = transform.right * xmov;
            Vector3 movZ = transform.forward * zmov;

            Vector3 velo = (movX + movZ).normalized * speed/3;
            motor.Move(velo);

            float yRot = Input.GetAxisRaw("Mouse X");
            Vector3 rotation = new Vector3(0f, yRot, 0f) * looksens;

            motor.Rotate(rotation);
        }
        else  
        {
            float xmov = Input.GetAxisRaw("Horizontal");
            float zmov = Input.GetAxisRaw("Vertical");

            Vector3 movX = transform.right * xmov;
            Vector3 movZ = transform.forward * zmov;

            Vector3 velo = (movX + movZ).normalized * speed ;
            motor.Move(velo);

            float yRot = Input.GetAxisRaw("Mouse X");
            Vector3 rotation = new Vector3(0f, yRot, 0f) * looksens;

            motor.Rotate(rotation);
        }
      

    }
}
