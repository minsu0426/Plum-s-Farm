using UnityEngine;

public class PlantingSystem2 : MonoBehaviour
{
    public GameObject cropPrefab; // ���� �۹��� ������
    public Transform playerTransform; // �÷��̾��� Transform
    public float interactionDistance = 1.0f; // �÷��̾�� ��ȣ�ۿ� ��� ������ �Ÿ�

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // F Ű Ŭ�� Ȯ��
        {
            Vector2 interactionPosition = playerTransform.position + playerTransform.right * interactionDistance; // �÷��̾��� ���ʿ� ��ȣ�ۿ� ��ġ ����
            RaycastHit2D hit = Physics2D.Raycast(interactionPosition, Vector2.zero); // ��ȣ�ۿ� ��ġ�� ����ĳ��Ʈ ����

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Crop")) // ����ĳ��Ʈ�� �۹��� �¾Ҵ��� Ȯ��
                {
                    Crop crop = hit.collider.GetComponent<Crop>();
                    if (crop != null)
                    {
                        crop.Water(); // �۹��� �� �ֱ�
                    }
                }
                else if (hit.collider.CompareTag("Soil")) // ����ĳ��Ʈ�� ��� Ÿ�Ͽ� �¾Ҵ��� Ȯ��
                {
                    Instantiate(cropPrefab, hit.collider.transform.position, Quaternion.identity); // ���ο� �۹� �ɱ�
                }
            }
        }
    }
}
