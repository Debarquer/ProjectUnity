using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public LayerMask enemyMask;
    public float speed = 1; 
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth;

	// Use this for initialization
	void Start ()
    {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;
        

	}

    private void FixedUpdate()
    {
        // check if there is ground infront
     Vector2 lineCastPosition = myTrans.position - myTrans.right * (myWidth/2);
        Debug.DrawLine(lineCastPosition, lineCastPosition + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPosition, lineCastPosition + Vector2.down, enemyMask );

        // if no ground turn around
        if (!isGrounded)
        {
            Vector3 currentRotation = myTrans.eulerAngles;
            currentRotation.y += 180;
            myTrans.eulerAngles = currentRotation; 
        }

        // always move forward
     Vector2 myVol = myBody.velocity;
     myVol.x = - myTrans.right.x * speed;
     myBody.velocity = myVol;

    }

    // Update is called once per frame
    void Update () {
		
	}

  private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<Player>().ChangeTimer(5f);
        Destroy(gameObject);
    }


}
