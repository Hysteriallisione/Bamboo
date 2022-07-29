using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    (Serializedfield) private Transform groundCheckTransform = null; 
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        { 
             jumpKeyWasPressed = true;
        }  
        horizontalInput = Input.GetAxis("Horizontal");     
    }

    // fixed update for physics update
    private void FixedUpdate()
    {
      if(Physics.OverlapSphere(groundCheckTransform.position, 0.1f).Lengh == 0)
      {
            return; 
      }
        
        if(jumpKeyWasPressed)
        {
             // on demande à la touche space de multiplier par 5 la force du saut par la vélocité
            rigidbodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);
    }

}
 

