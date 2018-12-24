using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balloon : MonoBehaviour {

    [SerializeField] public float thrustMultiplier = 1;
    [SerializeField] private SpriteRenderer flames;

    public float maxSpeed = 2f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)) {
            GetComponent<Rigidbody2D>().AddForce(transform.up * thrustMultiplier);
            flames.enabled = true;
        } else {
            flames.enabled = false;
        }

        if (GetComponent<Rigidbody2D>().velocity.magnitude > maxSpeed)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude((GetComponent<Rigidbody2D>().velocity), maxSpeed);
        } //This line
    }
}

