using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */

[RequireComponent(typeof(TextMeshPro))]

public class DestroyOnTrigger2D : MonoBehaviour
{

    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    public int hitPoints = 3;
    public TextMeshPro hitPointsText;

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
        }
        else
        {
            hitPointsText.text = "Hit Points: " + hitPoints;
        }
    }

    private void Update()
    {
        /* Just to show the enabled checkbox in Editor */
    }
}
