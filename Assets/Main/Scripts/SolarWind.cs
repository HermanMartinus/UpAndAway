using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarWind : MonoBehaviour {

    public float windMultiplier = 1f;
    [SerializeField] ParticleSystem particles;

    private void Awake()
    {
        particles.startSpeed = windMultiplier / 10;
        particles.startLifetime = 50 / windMultiplier;

    }

    private void OnTriggerStay2D(Collider2D otherCollider)
    {

        Rigidbody2D other = otherCollider.GetComponent<Rigidbody2D>();
        other.AddForce(transform.right * 0.1f * windMultiplier);
    }


    void Update()
    {
      
            
    }
}
