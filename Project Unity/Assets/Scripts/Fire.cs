using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public LayerMask enemyMask;
    public float speed = 1; 
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth;
    float myHeight;

	// Use this for initialization
	void Start ()
    {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        SpriteRenderer mySprite = this.GetComponent<SpriteRenderer>();
        myWidth = mySprite.bounds.extents.x;
        myHeight = mySprite.bounds.extents.y;


    }

    private void FixedUpdate()
    {
        // check if there is ground infront
     Vector2 lineCastPosition = myTrans.position.toVector2() - myTrans.right.toVector2() * (myWidth/2) + Vector2.up /2;
        Debug.DrawLine(lineCastPosition, lineCastPosition + Vector2.down);
        bool isGrounded = Physics2D.Linecast(lineCastPosition, lineCastPosition + Vector2.down, enemyMask );
        Debug.DrawLine(lineCastPosition, lineCastPosition - myTrans.right.toVector2()* 0.05f);
        bool isBlocked = Physics2D.Linecast(lineCastPosition, lineCastPosition - myTrans.right.toVector2()* 0.05f, enemyMask);


        // if no ground or blocked by wall  turn around
        if (!isGrounded || isBlocked)
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

  //private void OnTriggerEnter2D(Collider2D collision)
  //  {
  //      FindObjectOfType<Player>().ChangeTimer(5f);
  //      Destroy(gameObject);
  //  }


}
