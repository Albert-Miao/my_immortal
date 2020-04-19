using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class securityGuardController : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private PolygonCollider2D collider2D;

    public float speed=1;
    private float direction;
    private float swapTimer=5;
    private float time=0;
    // Start is called before the first frame update
    void Start()
    {
        direction = Random.Range(-2*Mathf.PI,2*Mathf.PI);
        rigidbody = this.GetComponent<Rigidbody2D>();
        collider2D = this.GetComponent<PolygonCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(time>swapTimer){
            direction = Random.Range(-2*Mathf.PI,2*Mathf.PI);
            time=0;
        }
        time+=Time.deltaTime;

        //move the boyo
        float dy = Mathf.Sin(direction) * speed * Time.deltaTime;
        float dx = Mathf.Cos(direction) * speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x+dx, transform.position.y+dy);
        transform.rotation = Quaternion.Euler(0, 0, direction*360f/2*Mathf.PI);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") { Destroy(other.gameObject);}


    }
}