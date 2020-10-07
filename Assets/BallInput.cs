﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInput : MonoBehaviour{

    private float deltaX, deltaY;
    private Rigidbody2D rb;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        if (Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            
            
            if (GetComponent<Collider2D>().OverlapPoint(touchPos)){
                //your code
                GetComponent<SpriteRenderer>().color = new Color(0.6f, 0.6f, 0.6f, 1f);
                switch (touch.phase){
                case TouchPhase.Began:
                    deltaX = touchPos.x - transform.position.x;
                    deltaY = touchPos.y - transform.position.y;
                    break;
                
                case TouchPhase.Moved:
                    rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));
                    break;
                
                case TouchPhase.Ended:
                    rb.velocity = Vector2.zero;
                    break;
                } 
            }
            
        }
    }
}
