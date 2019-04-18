using UnityEngine;

// 발판으로서 필요한 동작을 담은 스크립트
public class Platform : MonoBehaviour
{
    public GameObject[] obstacles;
    private bool stepped = false; // 해당 오브젝트가 밟힌 적이 있는지 확인.

    // OnEnable은 해당 Component가 활성화될 때마다 실행된다.
    private void OnEnable()
    {
        stepped = false;
        for(int i = 0; i < obstacles.Length; i++)
        {
            float rand = Random.Range(0f,1f);
            Debug.Log(rand);
            if (rand < 1f/3f) obstacles[i].SetActive(true);
            else obstacles[i].SetActive(false);
        }        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player" && !stepped)
        {
            stepped = true;
            GameManager.instance.AddScore(1);
        }
    }
}