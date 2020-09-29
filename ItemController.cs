using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    public Item itemData;
    public string triggerBy = "Player";

    private void Update()
    {
        
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(triggerBy))
        {
            Debug.Log(gameObject.name + " collided with player.");
            collision.gameObject.SendMessage("PickUp", itemData);
            PlaySound(transform.position, itemData);
            Destroy(gameObject);
        }
    }

    /**
     * Plays a sound when you recieve the object.
     */
    public virtual void PlaySound(Vector3 location, Item item)
    {
        if (item.retrieveSound != null)
        {
            AudioSource.PlayClipAtPoint(item.retrieveSound, location);
        }
    }
}
