using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCherry : MonoBehaviour
{
    public Text totalCherry;
    public int cherry;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cherry")) {
            Destroy (collision.gameObject);
            cherry++;
            totalCherry.text = cherry.ToString();
        }
    }

    public void AdjustValue(int number) {
        cherry+=number;
        totalCherry.text = cherry.ToString();
    }
}
