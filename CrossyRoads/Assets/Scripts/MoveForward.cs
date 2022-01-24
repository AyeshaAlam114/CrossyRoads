using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    PlayerController playerRef;
    public float upperBound;
    public float lowerBound;

    // Start is called before the first frame update
    void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerRef.gameOver == false)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.x < lowerBound && this.CompareTag("obstacle"))
            Destroy(gameObject);
        if (transform.position.x > upperBound && this.CompareTag("obstacle"))
            Destroy(gameObject);
    }
}
