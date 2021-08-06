using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball1Script : MonoBehaviour {

    Rigidbody2D rb;
    public string color;
    public float force;
    public bool grounded;
    public bool reunion = false,desactivate = false;
    public bool isBall2 = false;
    public Transform ball1;
    public BallParentScript ballParent;
    public GameUi gameUi;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (isBall2)
        {
            

            if (Mathf.Abs(this.transform.position.y-ball1.position.y) < 0.3f && reunion && desactivate)
            {
                reunion = false;
                desactivate = false;
                ballParent.readyToDivision = true;
                ball1.gameObject.GetComponent<Rigidbody2D>().gravityScale = Mathf.Abs(ball1.gameObject.GetComponent<Rigidbody2D>().gravityScale);
                this.gameObject.SetActive(false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ground"))
        {
            grounded = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("destroy"))
        {
            gameUi.GameOver();
        }else if (col.gameObject.CompareTag("coins") && col.gameObject.GetComponent<coinScript>().color == color)
        {
            ballParent.Coinsupdate();
            Destroy(col.gameObject);
        }
        else if (col.gameObject.CompareTag("target"))
        {
            if (color == "blue")
            {
                ballParent.Win();
                gameUi.Win();
            }
            
        }
        else if (col.gameObject.CompareTag("button"))
        {
            col.gameObject.GetComponent<buttonScript>().PlayAnimation();
            Destroy(col.gameObject);

        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        
    }

    public void ChangeGravity()
    {
        rb.gravityScale *= -1;
    }

    public void Jump()
    {
        if (grounded)
        {
            if (rb.gravityScale > 0)
            {
                rb.AddForce(new Vector2(0, force));
                
            }
            else
            {
                rb.AddForce(new Vector2(0, -force));
                
            }
        }
        
    }


    //---------------------------
}
