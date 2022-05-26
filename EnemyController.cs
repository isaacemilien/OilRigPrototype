using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region FIELDS
    // Characteristics
    [SerializeField] string[] vulnerabilities = {"Naive", "Over-agree"};
    [SerializeField] float strength;
    [SerializeField] string profession;
    [SerializeField] float trust;
    [SerializeField] float health;
    [SerializeField] float sanity;
     


    // Movement
    [SerializeField] float speed = 2.0f;

    [SerializeField] GameObject firstTarget;
    [SerializeField] GameObject secondTarget;

    GameObject currentTarget;

    #endregion

    #region MONOBEHAVIOUR METHODS 
    void Start()
    {
        currentTarget = firstTarget;
    }
	
    void Update()
    {
        float step = speed * Time.deltaTime;

        if(transform.position == firstTarget.transform.position)
        {
            currentTarget = secondTarget;
        }
        if (transform.position == secondTarget.transform.position)
        {
            currentTarget = firstTarget;
        }

        transform.position = Vector2.MoveTowards(transform.position, currentTarget.transform.position, step); 
    }
    #endregion

    #region METHODS 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Caught u lacking");
        }
    }
    #endregion
}
