using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomActivate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("player"))
        {
            Destroy(this.gameObject);
            GameObject player= GameObject.Find("player");
            player.transform.localScale = new Vector3((float)1.5, (float)1.5, 1);
            player.GetComponent<Player>().Size = new Vector2((float)0.3, (float)1.6);
        }
    }
}
