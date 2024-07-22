using UnityEngine;

public class PlantingSystem : MonoBehaviour
{
    public GameObject cropPrefab; // 심을 작물의 프리팹
    public Transform playerTransform; // 플레이어의 Transform
    public float plantingDistance = 1.0f; // 플레이어와 작물 사이의 거리
    private bool isPlanting = false; // 현재 심기 작업 중인지 여부
    private GameObject currentCrop; // 현재 심겨진 작물

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // F 키 클릭 확인
        {
            Vector2 plantingPosition = playerTransform.position + playerTransform.right * plantingDistance; // 플레이어의 앞쪽에 작물 심기
            RaycastHit2D hit = Physics2D.Raycast(plantingPosition, Vector2.zero); // 심을 위치에 레이캐스트 실행

            if (hit.collider != null && hit.collider.CompareTag("Soil")) // 레이캐스트가 토양 타일에 맞았는지 확인
            {
                if (!isPlanting) // 현재 심기 작업 중이 아닌지 확인
                {
                    currentCrop = Instantiate(cropPrefab, hit.collider.transform.position, Quaternion.identity); // 작물 프리팹 인스턴스화
                    isPlanting = true; // 심기 작업 상태를 true로 설정
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.G)) // G 키 클릭 확인 (물 주기)
        {
            if (currentCrop != null)
            {
                Crop crop = currentCrop.GetComponent<Crop>();
                if (crop != null)
                {
                    crop.Water(); // 작물에 물 주기
                }
            }
        }
    }
}