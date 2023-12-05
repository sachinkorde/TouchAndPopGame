using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Plus" || collision.gameObject.tag == "Miuns")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
