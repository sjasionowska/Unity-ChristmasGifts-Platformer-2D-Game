using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsPlayer : MonoBehaviour {

    [SerializeField]
    GameObject Player;

    Vector3 updatedPlayerPosition;

	void Update ()
    {
        updatedPlayerPosition = Player.transform.position;
        transform.position = new Vector3(updatedPlayerPosition.x + 10.0f, 3.0f, -10.0f);

    }
}
