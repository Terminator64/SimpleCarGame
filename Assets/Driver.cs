using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]float steerSpeed = 10f;
    [SerializeField]float moveSpeed = 5f;
    [SerializeField]float slowSpeed = 5f;
    [SerializeField]float boostSpeed = 20f;
    void Start()
    {
        
    }

    void Update()
    {
        float steerAmmount = Input.GetAxis("Horizontal")*steerSpeed*Time.deltaTime;
        float accelerate = Input.GetAxis("Vertical")*moveSpeed*Time.deltaTime;
        transform.Rotate(0, 0, (-1)*steerAmmount);
        transform.Translate(0, accelerate, 0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="SpeedUp" && moveSpeed<30)
        {
            moveSpeed=moveSpeed+boostSpeed;
            Debug.Log("Speed Up");
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (moveSpeed>10)
        {
            moveSpeed=moveSpeed-slowSpeed;
            Debug.Log("Speed Down");
        }
    }
}
