using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallParentScript : MonoBehaviour {

    public float speed;
    public ball1Script ball1, ball2;
    public bool division = false;
    bool clicked = false;
    public bool grounded, readyToDivision = true;
    public float gravity;
    public int coinsNumber, coinsCount;
    public Text coinsText,coinsWinText;
    // Use this for initialization
    void Start () {
        coinsCount = 0;
        ball2.gameObject.GetComponent<Rigidbody2D>().gravityScale = gravity;
        ball1.gameObject.GetComponent<Rigidbody2D>().gravityScale = gravity;
        coinsText.text = "Coins : " + coinsCount.ToString() + " / " + coinsNumber.ToString();

    }
	
	// Update is called once per frame
	void Update () {

        this.transform.position += new Vector3(Time.deltaTime * speed, 0, 0);

        CheckGrounded();

        if (Input.GetKeyDown(KeyCode.C) && !clicked && grounded)
        {
            Jump();
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            clicked = false;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            ChangeGravity();
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            Division();
        }
        


    }

    public void CheckGrounded()
    {
        if (division)
        {
            if (ball1.grounded && ball2.grounded)
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }
        }
        else
        {
            if (ball1.grounded)
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }
        }
    }

    public void Jump()
    {
        if (division)
        {
            ball1.Jump();
            ball2.Jump();
            clicked = true;
        }
        else
        {
            ball1.Jump();
            clicked = true;
        }
    }

    public void ButtonJumpUp()
    {
        clicked = false;
    }
    public void ChangeGravity()
    {
        if (division)
        {
            ball1.ChangeGravity();
            ball2.ChangeGravity();
        }
        else
        {
            ball1.ChangeGravity();
        }
    }
    
    public void Division()
    {
        if (readyToDivision)
        {
            division = !division;

            if (division)
            {
                
                ball2.gameObject.SetActive(true);
                ball2.reunion = true;
                ball2.gameObject.GetComponent<Transform>().position = ball1.gameObject.GetComponent<Transform>().position;
                ball2.gameObject.GetComponent<Rigidbody2D>().gravityScale = -1 * (ball1.gameObject.GetComponent<Rigidbody2D>().gravityScale);
            }
            else
            {
                if(ball1.gameObject.GetComponent<Transform>().position.y > ball2.gameObject.GetComponent<Transform>().position.y)
                {
                    ball2.desactivate = true;
                    readyToDivision = false;
                    ball2.gameObject.GetComponent<Rigidbody2D>().gravityScale = -gravity;
                    ball1.gameObject.GetComponent<Rigidbody2D>().gravityScale = gravity;
                }
                else
                {
                    ball2.desactivate = true;
                    readyToDivision = false;
                    ball2.gameObject.GetComponent<Rigidbody2D>().gravityScale = gravity;
                    ball1.gameObject.GetComponent<Rigidbody2D>().gravityScale = -gravity;
                }

                
                

            }
        }
        
    }

    public void Coinsupdate()
    {
        coinsCount++;
        coinsText.text = "Coins : " + coinsCount.ToString() + " / " + coinsNumber.ToString();
    }
    
    public void Win()
    {
        coinsWinText.text = "Coins : " + coinsCount.ToString() + " / " + coinsNumber.ToString();
    }
    //--------------
}
