using UnityEngine;
using System.Collections;

public class Crop : MonoBehaviour
{
    public float initialGrowthTime = 10f; // 기본 성장 시간
    public float waterEffect = 0.9f; // 물을 줄 때마다 성장 시간이 줄어드는 비율
    public int maxWaterings = 1; // 최대 물 주기 횟수
    private int waterings = 0; // 현재 물을 준 횟수
    private bool isGrowing = false; // 성장 중인지 여부
    private bool isWatered = false; // 물이 주어졌는지 여부
    private float growthTime; // 현재 성장 시간

    private void Start()
    {
        growthTime = initialGrowthTime; // 초기 성장 시간 설정
        StartCoroutine(Grow()); // 성장 코루틴 시작
    }

    private IEnumerator Grow()
    {
        while (waterings < maxWaterings)
        {
            isGrowing = true;
            yield return new WaitForSeconds(growthTime); // 성장 시간 대기

            if (isWatered)
            {
                waterings++;
                isWatered = false; // 물 상태 초기화
                growthTime *= waterEffect; // 물을 줄 때마다 성장 시간 감소
                growthTime = Mathf.Max(growthTime, 2f); // 최소 성장 시간 제한 (예: 2초)
            }
            else
            {
                isGrowing = false;
                yield break; // 코루틴 종료
            }
        }

        isGrowing = false;
    }

    public void Water()
    {
        if (isGrowing && waterings < maxWaterings)
        {
            isWatered = true; // 물 주기 상태 설정
            StopCoroutine(Grow()); // 현재 성장 코루틴 중단
            StartCoroutine(Grow()); // 새로운 성장 코루틴 시작
        }
    }
}