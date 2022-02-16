using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerOne : MonoBehaviour
{

    public GameObject Canvas;
    public Text text;
    private GameObject Player;
    private int IQ;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        IQ = 250;
        isDead = true;
    }

    private void Update()
    {
        if (!Player.activeSelf && isDead)
        {
            Canvas.SetActive(true);
            IQ -= 50;
            text.text = "智商 " + IQ;
            isDead = false;
            Time.timeScale = 0;
        }
    }


    // 重新游戏
    public void ResGame()
    {
        if (!Player.activeSelf)
        {
            IsBig();
            Canvas.SetActive(false);
            GameObject.Find("GameSave").GetComponent<SceneOneSave>().Load();
            Player.SetActive(true);
            Time.timeScale = 1;
        }
    }
    // 结束游戏
    public void QuiteGame()
    {
        Application.Quit();
    }

    // 变回原来大小
    private void IsBig()
    {
        if (Player.transform.localScale.x > 1)
        {
            Player.transform.localScale = new Vector3(1, 1, 1);
        }
    }

}
