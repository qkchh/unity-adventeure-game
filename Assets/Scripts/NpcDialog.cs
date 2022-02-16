using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NpcDialog : MonoBehaviour
{
    private GameObject Canvas;
    // Start is called before the first frame update

    private float showTimer;
    void Start()
    {
        showTimer = 31;
        Canvas = GetComponentInChildren<Canvas>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (showTimer >= 0 && showTimer<=3)
        {
            showTimer -= Time.deltaTime;
        }
        if (showTimer < 0)
        {
            Canvas.SetActive(false);
        }
    }

    public void ShowDialog()
    {
        if (!Canvas.activeSelf)
        {
            showTimer = 3;
            Canvas.SetActive(true);
            GetComponentInChildren<Text>().text = "开始你的冒险吧！";
        }
       
    }
}
