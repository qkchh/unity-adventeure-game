using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall02Down : MonoBehaviour
{
    public GameObject Room;
    private bool isCreatRoom;
    // Start is called before the first frame update
    void Start()
    {
        isCreatRoom = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= 11 && !isCreatRoom)
        {
            GameObject.Instantiate(Room).transform.position=new Vector3(83.5f,13.5f,0);
            isCreatRoom = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(transform.position.y <= 11))
        {
            transform.position += new Vector3(0, -0.5f, 0);
        }
    }
}
