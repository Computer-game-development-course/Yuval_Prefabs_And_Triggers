using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[RequireComponent(typeof(TextMeshPro))]

public class HitPoints : MonoBehaviour
{
    [SerializeField] string triggeringTag;
    public int hitPoints = 3;
    public TextMeshPro hitPointsText;

    void Start()
    {
        hitPointsText.text = "Hit Points: " + hitPoints;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            Hit(1);
            Destroy(other.gameObject);
        }
    }

    private void Hit(int damage)
    {
        hitPoints -= damage;

        if (hitPoints <= 0)
        {
            Destroy(this.gameObject);
            hitPointsText.text = "Game Over";
            Application.Quit();
        }
        else
        {
            hitPointsText.text = "Hit Points: " + hitPoints;
        }
    }
}
