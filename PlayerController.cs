using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    #region FIELDS
    Rigidbody2D rb;
    [SerializeField] float lol = 180f;
    [SerializeField] float speed = 1;

    bool itemGrabbed = false;
    

    #endregion

    #region MONOBEHAVIOUR METHODS 
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
	
    void Update()
    {
        Vector2 currentPos = gameObject.transform.position;

        // gameObject.transform.position = new Vector2(currentPos.x + Input.GetAxis("Horizontal") / moveSlowness, currentPos.y + Input.GetAxis("Vertical") / moveSlowness);

        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(rb.position + Vector2.up * speed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.MovePosition(rb.position + Vector2.left * speed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(rb.position + Vector2.down * speed * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(rb.position + Vector2.right * speed * Time.fixedDeltaTime);
        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)){
            rb.MovePosition(rb.position + VectorFromAngle(lol) * speed * Time.fixedDeltaTime);
        }

        // Debug.Log(Math.Abs(VectorFromAngle(60).x) + " " + Math.Abs(VectorFromAngle(60).y));
        Debug.Log(VectorFromAngle(lol));


    }
    #endregion

    #region METHODS 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Item")
        {
            itemGrabbed = true;
            collision.gameObject.SetActive(false);

            Debug.Log("Item Collected");
        }
    }

    Vector2 VectorFromAngle(float theta)
    {
        return new Vector2(Mathf.Cos(theta), Mathf.Sin(theta)); // Trig is fun
    }

    Vector2 AbsVector2(Vector2 v2){
        return new Vector2(Math.Abs(VectorFromAngle(60).x), Math.Abs(VectorFromAngle(60).y));
    }
    #endregion
}
