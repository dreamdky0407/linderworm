

using UnityEngine;

public class playermotor : MonoBehaviour
{

    private Vector3 velo = Vector3.zero;
    private Vector3 rot = Vector3.zero;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
   public  void Move(Vector3 _velo )
    {
        velo = _velo;

    }

    public void Rotate(Vector3 _rot)
    {
        rot  = _rot;

    }

    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation(); 

    }
    void PerformMovement()
    {
        if (velo != Vector3.zero)
        {
            rb.MovePosition(rb.position + velo * Time.fixedDeltaTime);
        }
    }
    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rot));
    }

}
