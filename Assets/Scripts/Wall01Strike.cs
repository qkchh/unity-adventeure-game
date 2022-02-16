using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall01Strike : MonoBehaviour
{
    public Sprite Wall;
    public Sprite WallNull;
    public GameObject Mushroom;
    private bool isTigger;

    public bool IsTigger
    {
        get { return isTigger; }
        set { isTigger = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        isTigger = true;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    // 碰撞检测

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null && isTigger)
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (GetComponent<Wall01Strike>()!=null)
            {
                GameObject mushroom = GameObject.Instantiate(Mushroom);
                mushroom.name = "mushroom";
                mushroom.transform.position = transform.position;
                sr.sprite = WallNull;
                isTigger = false;
            }
        }
    }

    public void Back()
    {
        if (isTigger)
        {
            GetComponent<SpriteRenderer>().sprite=Wall;
            GameObject mr= GameObject.Find("mushroom");
            if (mr != null)
            {
                Destroy(mr);
            }

        }
    }
}
