using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody playerRigidbody;
    public float speed = 8f;
    void Start()
    {
        // 스크립트가 할당된 오브젝트에서 Rigidbody Component를 찾아서 할당한다.
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVelocity = new Vector3(xSpeed, 0, zSpeed);
        playerRigidbody.velocity = newVelocity;

        //if (Input.GetKey(KeyCode.UpArrow)) playerRigidbody.AddForce(0, 0, speed);
        //if (Input.GetKey(KeyCode.DownArrow)) playerRigidbody.AddForce(0, 0, -speed);
        //if (Input.GetKey(KeyCode.RightArrow)) playerRigidbody.AddForce(speed, 0, 0);
        //if (Input.GetKey(KeyCode.LeftArrow)) playerRigidbody.AddForce(-speed, 0, 0);
    }

    public void Die()
    {
        // 자신의 게임 오브젝트에 접근하여 비활성화
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
