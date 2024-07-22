using UnityEngine;
using System.Collections;

public class Crop : MonoBehaviour
{
    public float initialGrowthTime = 10f; // �⺻ ���� �ð�
    public float waterEffect = 0.9f; // ���� �� ������ ���� �ð��� �پ��� ����
    public int maxWaterings = 1; // �ִ� �� �ֱ� Ƚ��
    private int waterings = 0; // ���� ���� �� Ƚ��
    private bool isGrowing = false; // ���� ������ ����
    private bool isWatered = false; // ���� �־������� ����
    private float growthTime; // ���� ���� �ð�

    private void Start()
    {
        growthTime = initialGrowthTime; // �ʱ� ���� �ð� ����
        StartCoroutine(Grow()); // ���� �ڷ�ƾ ����
    }

    private IEnumerator Grow()
    {
        while (waterings < maxWaterings)
        {
            isGrowing = true;
            yield return new WaitForSeconds(growthTime); // ���� �ð� ���

            if (isWatered)
            {
                waterings++;
                isWatered = false; // �� ���� �ʱ�ȭ
                growthTime *= waterEffect; // ���� �� ������ ���� �ð� ����
                growthTime = Mathf.Max(growthTime, 2f); // �ּ� ���� �ð� ���� (��: 2��)
            }
            else
            {
                isGrowing = false;
                yield break; // �ڷ�ƾ ����
            }
        }

        isGrowing = false;
    }

    public void Water()
    {
        if (isGrowing && waterings < maxWaterings)
        {
            isWatered = true; // �� �ֱ� ���� ����
            StopCoroutine(Grow()); // ���� ���� �ڷ�ƾ �ߴ�
            StartCoroutine(Grow()); // ���ο� ���� �ڷ�ƾ ����
        }
    }
}