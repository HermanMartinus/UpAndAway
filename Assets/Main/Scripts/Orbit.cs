using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

    [SerializeField] float rotateSpeed = 1f;
    [SerializeField] float radius = 3f;

    [SerializeField] Transform centre;
    float _angle;

    void Start()
    {
    }

    void Update()
    {

        _angle += rotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * radius;
        GetComponent<Rigidbody2D>().MovePosition(new Vector2(centre.position.x, centre.position.y) + offset);
    }
}
