using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWallActivate : MonoBehaviour
{
    private bool isActivity;

    public bool IsActivity
    {
        get{ return isActivity; }
        set { isActivity = value; }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        IsActivity = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null && !isActivity)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            isActivity = true;
        }
    }
}
