﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private PolygonCollider2D collider2D;

    public float speed=1;

    private bool SPRITE_RIGHT = false;
    private bool SPRITE_LEFT = true;

    private bool carrying = false;
    public Sprite carrySprite;

    public void setCarry()
    {
        this.carrying = true;
        speed /= 2;
    }
    public bool isCarry()
    {
        return this.carrying;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        collider2D = this.GetComponent<PolygonCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //move the boyo
        float dx = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float dy = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x+dx, transform.position.y+dy);
        if(dx>0){
            this.GetComponent<SpriteRenderer>().flipX=SPRITE_RIGHT;
        }
        else if (dx<0){
            this.GetComponent<SpriteRenderer>().flipX=SPRITE_LEFT;
        }

        if (carrying)
        {
            this.GetComponent<SpriteRenderer>().sprite = carrySprite;
        }
            
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Victim") 
        {
            Destroy(other.gameObject);
            this.setCarry();
        }

        if (other.gameObject.tag == "Victim")
        {
            Destroy(other.gameObject);
            this.setCarry();
        }


    }

}
