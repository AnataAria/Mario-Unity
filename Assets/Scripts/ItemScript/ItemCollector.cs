using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cherryText;
    private int cherrys = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(collision.gameObject);
            cherrys++;
            cherryText.text = "Cherry: " + cherrys;
        }
    }
}
