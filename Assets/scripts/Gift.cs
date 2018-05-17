using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gift : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //Gift.SetTile(new Vector3Int(-7, 3, 0), null);
            GetComponent<AudioSource>().Play();
            //FindObjectOfType<PointsCounter>().IncrementPoints();
            //GetComponent<SpriteRenderer>().enabled = false;
            //Destroy(gameObject, 3f);
        }

    }

}
