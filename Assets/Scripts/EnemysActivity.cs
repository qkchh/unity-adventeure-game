using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemysActivity : MonoBehaviour
{
    private GameObject Player;
    private GameObject enemySuper;
    private bool isActivity=true;
    public bool IsActivity {
        get { return isActivity; }
        set { isActivity = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        enemySuper = gameObject.GetComponentInChildren<EnemySuper>().gameObject;
        Player =GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.x > 53&& isActivity)
        {
            enemySuper.SetActive(true);
           
        }
        if (Player.transform.position.x > 60 && isActivity)
        {
            enemySuper.GetComponent<EnemySuper>().enabled = true;
            isActivity = false;
        }
    }
}
