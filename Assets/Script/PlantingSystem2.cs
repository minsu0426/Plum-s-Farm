using UnityEngine;

public class PlantingSystem2 : MonoBehaviour
{
    public GameObject cropPrefab; // 심을 작물의 프리팹
    public Transform playerTransform; // 플레이어의 Transform
    public float interactionDistance = 1.0f; // 플레이어와 상호작용 대상 사이의 거리

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // F 키 클릭 확인
        {
            Vector2 interactionPosition = playerTransform.position + playerTransform.right * interactionDistance; // 플레이어의 앞쪽에 상호작용 위치 설정
            RaycastHit2D hit = Physics2D.Raycast(interactionPosition, Vector2.zero); // 상호작용 위치에 레이캐스트 실행

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Crop")) // 레이캐스트가 작물에 맞았는지 확인
                {
                    Crop crop = hit.collider.GetComponent<Crop>();
                    if (crop != null)
                    {
                        crop.Water(); // 작물에 물 주기
                    }
                }
                else if (hit.collider.CompareTag("Soil")) // 레이캐스트가 토양 타일에 맞았는지 확인
                {
                    Instantiate(cropPrefab, hit.collider.transform.position, Quaternion.identity); // 새로운 작물 심기
                }
            }
        }
    }
}
