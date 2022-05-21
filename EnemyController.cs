using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region FIELDS
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
    #endregion
}
