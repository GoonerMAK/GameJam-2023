using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed;
    public bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * speed * Time.deltaTime * verticalInput);

        if(horizontalInput > 0 && !facingRight) 
        {
            //gameObject.transform.localScale = new Vector3(1, 1, 1);
            Flip();
        }
        else if (horizontalInput < 0 && facingRight)
        {
            //gameObject.transform.localScale = new Vector3(-1, 1, 1);
            Flip();
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
