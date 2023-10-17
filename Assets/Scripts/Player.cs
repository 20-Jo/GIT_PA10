using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    public Rigidbody RB;
    public GameObject Duck;

    public GameManager GameManager;

    public GameObject Score10TXT;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            RB.AddForce(transform.up * 200);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6.63f, 6.63f), Mathf.Clamp(transform.position.y, -5, 3.36f));

        if (transform.position.y < -4.5f)
            SceneManager.LoadScene("Gameover");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
            SceneManager.LoadScene("Gameover");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            GameManager.UpdateScore(10);
            Destroy(other.gameObject);
        }
    }
}
    
