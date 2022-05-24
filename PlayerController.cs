using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    #region FIELDS
    Rigidbody2D rb;
    [SerializeField] float moveSlowness = 60;

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

        gameObject.transform.position = new Vector2(currentPos.x + Input.GetAxis("Horizontal") / moveSlowness, currentPos.y + Input.GetAxis("Vertical") / moveSlowness);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            itemGrabbed = true;
            collision.gameObject.SetActive(false);

            Debug.Log("Item Collected");
        }
    }
    #endregion

    #region METHODS 

    #endregion
}
