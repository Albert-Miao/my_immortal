using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    private PolygonCollider2D collider2D;
    public PlayerController p;
    public bool victoryDoor;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody2D>();
        collider2D = this.GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            if (p.isCarry())
            {
                SceneManager.LoadScene("IntroScene", LoadSceneMode.Single);
            }
        }


    }
}
