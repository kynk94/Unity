using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
    private void Start()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        // 총알의 이동속도 = 앞쪽 방향 * speed
        bulletRigidbody.velocity = transform.forward * speed;

        // 3초 후 자신 파괴
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other) // other = 충돌한 대상
    {
        // 충돌한 대상의 tag가 "Player"인가?
        if(other.tag == "Player")
        {
            // 대상 오브젝트에서 PlayerController 컴포넌트를 가져옴. 코드가 돌고 있는 부분을 가져오는 것.
            PlayerController playerController = other.GetComponent<PlayerController>();

            // PlayerController.cs 의 Die() method 실행.
            if (playerController != null) playerController.Die();
        }
    }
}
