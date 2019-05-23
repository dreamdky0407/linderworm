using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anime : MonoBehaviour
{
    public Animator animator;
    public float InputX;
    public float InputY;
    float X;
    

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        InputY = Input.GetAxis("Vertical") / 2;
        InputX = Input.GetAxis("Horizontal") ;
        animator.SetFloat("InputY", InputY);
        animator.SetFloat("InputX", InputX);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            InputY = Input.GetAxis("Vertical");
            
            animator.SetFloat("InputY", InputY);
            
        }
        
    }
}