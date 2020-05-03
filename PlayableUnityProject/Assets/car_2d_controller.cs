using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_2d_controller : MonoBehaviour
{
    // Start is called before the first frame update

    float speedForce = 10f;
    float torqueForce = 200f;
    float driftFactorSticky = 0.1f;
    float driftFactorSlippy = 0.999f;
    float maxStickyVelocity = 2.5f;
    float maxSlippyVelocity = 1.5f;

    void Start()
    {
        
    }

    void Update(){

    }

    // Update is called once per frame
 
    void FixedUpdate(){
    	Rigidbody2D rb = GetComponent<Rigidbody2D>();

    	float driftFactor = driftFactorSlippy;
    	
    	rb.velocity = ForwardVelocity() + RightVelocity()*driftFactorSticky;
    	if (RightVelocity().magnitude > maxStickyVelocity){
    		driftFactor = driftFactorSlippy;
    	}

        if (Input.GetButton("Accelerate"))
        {
            rb.AddForce( transform.up * speedForce);
        }

        rb.angularVelocity = ( Input.GetAxis("Horizontal") * torqueForce);
    }

    Vector2 ForwardVelocity(){
    	return transform.up * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.up);
    }

    Vector2 RightVelocity(){
    	return transform.right * Vector2.Dot(GetComponent<Rigidbody2D>().velocity, transform.right);
    }
}
  