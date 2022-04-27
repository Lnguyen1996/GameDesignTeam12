using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball_movement : MonoBehaviour
{
    //all these variables are private because nothing else needs to use them
    private float movespeed = 2.5f; //the speed that it moves
    private float movetime = 0.5f; //the time that it moves for
    private Vector2 direction; //I am using vector2 for a movement vector for the urchin
    private float duration; //how long it should move in one direction before changing the direction vector

    private Rigidbody2D rb2d; //the rigid body
    private SpriteRenderer sr; //the sprite renderer

    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>(); //this gets the urchin's rigidbody
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        duration = duration - Time.deltaTime;
        if (duration <= 0)
        {
            direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            duration += movetime;
        }
    }

    void FixedUpdate() //I have to use this with physics because regular update may become desynchronized from the physics engine
    {
        rb2d.AddForce(direction * movespeed); //make it move in the direction of the vector, at the speed of movespeed
    }
}
