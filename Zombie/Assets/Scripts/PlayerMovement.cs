using UnityEngine;

// 플레이어 캐릭터를 사용자 입력에 따라 움직이는 스크립트
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 180f;

    private PlayerInput playerInput;
    private Rigidbody playerRigidbody;
    private Animator playerAnimator;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // FixedUpdate는 물리 갱신 주기에 맞춰 실행됨
    // 기본값 0.02초마다 실행
    private void FixedUpdate()
    {
        Rotate();
        Move();
        playerAnimator.SetFloat("Move", playerInput.move);
    }

    private void Move()
    {
        Vector3 moveDistance = playerInput.move * transform.forward * moveSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }
        
    private void Rotate()
    {
        float turn = playerInput.rotate * rotateSpeed * Time.deltaTime;
        playerRigidbody.rotation *= Quaternion.Euler(0f, turn, 0f);
    }
}