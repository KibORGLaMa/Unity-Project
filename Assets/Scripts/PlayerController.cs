using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 direction;
    public float speed = 8.0f;
    public Rigidbody2D playerController;
    public string name;
    public int age;
    public Rigidbody2D playerRB;
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<Rigidbody2D>();
        name = "Vasile";
        age = 49;
        gameObject.transform.localScale = new Vector2(2f,2f);
        playerRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        gameObject.transform.Translate(direction * (speed + Time.deltaTime));
        
        
    }
    void Flip()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    void FixedUpdate(){
        playerRB.AddForce(Vector2.up * (Input.GetAxisRaw("Jump") * speed), ForceMode2D.Impulse);
    }
}
