using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlageSave : MonoBehaviour
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
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            GameObject.Find("GameSave").GetComponent<SavesGame>().SaveGame();
            Destroy(gameObject);
        }
    }
}
