using UnityEngine;

public class PlantingSystem : MonoBehaviour
{
    public GameObject cropPrefab; // ���� �۹��� ������
    public Transform playerTransform; // �÷��̾��� Transform
    public float plantingDistance = 1.0f; // �÷��̾�� �۹� ������ �Ÿ�
    private bool isPlanting = false; // ���� �ɱ� �۾� ������ ����
    private GameObject currentCrop; // ���� �ɰ��� �۹�

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // F Ű Ŭ�� Ȯ��
        {
            Vector2 plantingPosition = playerTransform.position + playerTransform.right * plantingDistance; // �÷��̾��� ���ʿ� �۹� �ɱ�
            RaycastHit2D hit = Physics2D.Raycast(plantingPosition, Vector2.zero); // ���� ��ġ�� ����ĳ��Ʈ ����

            if (hit.collider != null && hit.collider.CompareTag("Soil")) // ����ĳ��Ʈ�� ��� Ÿ�Ͽ� �¾Ҵ��� Ȯ��
            {
                if (!isPlanting) // ���� �ɱ� �۾� ���� �ƴ��� Ȯ��
                {
                    currentCrop = Instantiate(cropPrefab, hit.collider.transform.position, Quaternion.identity); // �۹� ������ �ν��Ͻ�ȭ
                    isPlanting = true; // �ɱ� �۾� ���¸� true�� ����
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.G)) // G Ű Ŭ�� Ȯ�� (�� �ֱ�)
        {
            if (currentCrop != null)
            {
                Crop crop = currentCrop.GetComponent<Crop>();
                if (crop != null)
                {
                    crop.Water(); // �۹��� �� �ֱ�
                }
            }
        }
    }
}