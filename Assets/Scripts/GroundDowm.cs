using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDowm : MonoBehaviour
{
    private bool isGravity;

    public bool IsGravity
    {
        get { return isGravity; }
        set { isGravity = value; }
    }

    private Vector3 Local;
    private Rigidbody2D GroudDwon;
    private float Timer;
    // Start is called before the first frame update
    void Start()
    {
        GroudDwon = GetComponent<Rigidbody2D>();
        Local = transform.position;
        isGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -2)
        {
            gameObject.SetActive(false);
        }

        if (GroudDwon.drag != 0)
        {
            Timer -= Time.deltaTime;
            if (Timer < 0)
            {
                GroudDwon.drag = 0;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null && !isGravity)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            isGravity = true;
        }
    }

    public void Back()
    {
        gameObject.SetActive(true);
        GroudDwon.drag = 1000;
        GetComponent<Rigidbody2D>().gravityScale = 0;
        transform.position = Local;
        Timer = 0.3f;
      
    }
}
