using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 0.5f;
    public Vector2 maxVelocity = new Vector2(3,5);
    public Vector2 moving = new Vector2();
    private Rigidbody2D rb;

    public bool idle;

    //private PlayerController controller;
    private Animator anim;

    void Start()
    {
        //controller = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var forceX = 0f;
        var forceY = 0f;
    
        var movingX = 0;
        var movingY = 0;

        var absVelX = Mathf.Abs(rb.velocity.x);
        var absVelY = Mathf.Abs(rb.velocity.y);

        if (absVelY < .2f){
            idle = true;
        }
        else{
            idle = false;
        }


        if (Input.GetKey ("right")) {
			movingX = 1;
            moving.x = 1;
		} else if (Input.GetKey ("left")) {
			movingX = -1;
            moving.x = -1;
	    }

		if (Input.GetKey ("up")) {
			movingY = 1;
            moving.y = 1;
		} else if (Input.GetKey ("down")) {
			movingY = -1;
            moving.y = -1;
		}


        if ( movingX != 0 ) {
            moving.x = movingX;
            if (absVelX < maxVelocity.x ) {
                forceX = speed * moving.x;
                //moving.x = movingX;
                transform.localScale = new Vector3(forceX > 0 ? 1 : -1 , 1 , 1);
            }
            anim.SetInteger ("isWalking" , 1);
        } else {
            anim.SetInteger ("isWalking" , 0);
        }
        
        if ( movingY > 0){
            moving.y = movingY;
            if (absVelY < maxVelocity.y ) {
                forceY = speed * moving.y;
                //controller.moving.y = movingY;
            }
            //anim.SetInteger ("isWalking" , 1);
        }
        else{
            //anim.SetInteger ("isWalking" , 0);
        }
        rb.AddForce (new Vector2 (forceX , forceY));
    }
}
