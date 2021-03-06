using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    public float cherrySpeed;
    private Rigidbody2D theRB;
    public GameObject cherryEffect;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(cherrySpeed*transform.localScale.x,0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Sophie"){
            FindObjectOfType<GameManager>().DamageSophie();
        }
        if(other.tag == "Claude"){
            FindObjectOfType<GameManager>().DamageClaude();
        }
        Instantiate(cherryEffect, transform.position,transform.rotation);
        Destroy(gameObject);
    }
}
