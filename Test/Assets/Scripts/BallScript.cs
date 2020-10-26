using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    [SerializeField] private Text gameOverText;

    void Update()
    {
        if (transform.position.y < -1000) {
            GetComponent<Rigidbody>().useGravity = false;
            gameOverText.text = "Красиво падает. Кнопка перезапуска сверху справа ↗";
        }
    }
}