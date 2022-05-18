using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Text text;
    public float healthBarOffset;
    public GameObject player;

    private void Start()
    {
        text.text = "100";
        player = GameObject.Find("Player");
    }
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + healthBarOffset, 0);
    }
    public void SetHealth(int health)
    {
        text.text = health.ToString();
    }
}

