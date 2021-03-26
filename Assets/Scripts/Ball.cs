using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;

    public GameObject leftPaddle;
    public GameObject rightPaddle;

    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        leftPaddle = GameObject.Find("LeftPad");
        rightPaddle = GameObject.Find("RightPad");

        Score.canAddScore = true;

        StartCoroutine(Pause());

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      if(Mathf.Abs(this.transform.position.x) >= 24f)
        {
            Score.canAddScore = true;

            this.transform.position = new Vector3(0f, 0f, 0f);
            StartCoroutine(Pause());
        }
    }

    IEnumerator Pause()
    {
        int directionX = Random.Range(-1, 2);
        int directionY = Random.Range(-1, 2);

        if(directionX == 0)
        {
            directionX = 1;
        }

        rb.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(2);
        rb.velocity = new Vector2(16f * directionX, 14f * directionY);
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if(hit.gameObject.name == "LeftPad")
        {
            if (leftPaddle.GetComponent<Rigidbody2D>().velocity.y > 0.5f)
            {
                rb.velocity = new Vector2(20f, 20f);
            }
            else if(leftPaddle.GetComponent<Rigidbody2D>().velocity.y < -0.5f)
            {
                rb.velocity = new Vector2(20f, -20f);
            }
            else
            {
                rb.velocity = new Vector2(28f, 0f);
            }
        }
        if (hit.gameObject.name == "RightPad")
        {
            if (rightPaddle.GetComponent<Rigidbody2D>().velocity.y > 0.5f)
            {
                rb.velocity = new Vector2(-20f, 20f);
            }
            else if (rightPaddle.GetComponent<Rigidbody2D>().velocity.y < -0.5f)
            {
                rb.velocity = new Vector2(-20f, -20f);
            }
            else
            {
                rb.velocity = new Vector2(-28f, 0f);
            }
        }
        audio.Play();
    }

}
