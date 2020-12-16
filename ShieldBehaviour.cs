using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{
    private AuraSpellController controller;
    public float health = 100;
    private void OnEnable()
    {
        controller = gameObject.GetComponent<AuraSpellController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((controller.spell.targetLayers.value & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            try
            {
                Rigidbody2D mass = collision.gameObject.GetComponent<Rigidbody2D>();
                Vector3 direction = collision.transform.right;
                mass.AddForce(500 * Vector3.Scale(direction, new Vector3(-1, -1, -1)));
            }
            catch (MissingComponentException error) {
            }
        }
    }

    public void TakeHit(float amount) {
        health -= amount;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
