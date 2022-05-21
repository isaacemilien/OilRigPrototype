using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region FIELDS
    Rigidbody2D rb;

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
    #endregion
}
