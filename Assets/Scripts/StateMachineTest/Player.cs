using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 5;
    Vector3 velocity;
   public int contStar = 0;

    public GameObject WIN;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector2 inputDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 targetVelocity = new Vector3(moveSpeed * inputDir.x, 0, moveSpeed * inputDir.y);
        velocity = Vector3.Lerp(velocity, targetVelocity, 10 * Time.deltaTime);
    }

    void FixedUpdate()
    {
        rb.velocity = velocity;
    }

     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="star")
        {
            contStar++;
           
            Destroy(other.gameObject);
            
        }

        if (other.gameObject.tag == "win")
        {

            WIN.SetActive(true);
            Destroy(other.gameObject);

        }
    }
}
