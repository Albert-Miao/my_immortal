using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictimController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private PolygonCollider2D collider2D;
    private float direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = Random.Range(-2 * Mathf.PI, 2 * Mathf.PI);
        rigidbody = this.GetComponent<Rigidbody2D>();
        collider2D = this.GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}