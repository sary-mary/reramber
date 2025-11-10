using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{

    // 로딩바 UI를 연결할 변수 (Slider나 Image의 Fill Amount를 조작)
    [SerializeField] private Slider progressBar;

    // 로딩 퍼센트를 표시할 Text를 연결할 변수
    [SerializeField] private TextMeshProUGUI progressText;

    // 다른 씬에서 로드할 다음 씬 이름을 저장하는 정적 변수
    public static string nextSceneName { get; private set; }

    private const string LoadingSceneName = "LoadIngScenes";

    // Start 함수에서 비동기 로딩 시작
    private void Start()
    {
        // 로딩 씬에 진입하면 코루틴을 실행하여 씬 로드를 시작합니다.
        StartCoroutine(LoadSceneProcess());
    }

    /// <summary>
    /// 다른 씬에서 로딩 씬으로 이동할 때 호출하는 함수
    /// </summary>
    public static void LoadScene(string sceneName)
    {
        nextSceneName = sceneName; // 로드할 씬 이름을 저장
        SceneManager.LoadScene(LoadingSceneName); // LoadingScene으로 이동
    }

    /// <summary>
    /// 실제 비동기 로딩을 처리하는 코루틴
    /// </summary>
    IEnumerator LoadSceneProcess()
    {
        // 로드할 씬 이름이 설정되지 않았다면 예외 처리
        if (string.IsNullOrEmpty(nextSceneName))
        {
            Debug.LogError("로드할 다음 씬 이름이 설정되지 않았습니다.");
            yield break;
        }
        Debug.Log($"씬 로드 시작: {nextSceneName}"); // (A)
        // 씬을 비동기로 로드 시작
        AsyncOperation op = SceneManager.LoadSceneAsync(nextSceneName);

        // 씬 로드가 90% 완료되어도 자동으로 전환되지 않도록 설정 (선택 사항)
        // 이를 통해 로딩바가 100%에 도달하는 순간을 제어할 수 있습니다.
        op.allowSceneActivation = false;

        // 로드가 완료될 때까지 반복
        while (!op.isDone)
        {
            yield return null; // 한 프레임 대기

            // 로딩 진행 상황 계산
            float progress = Mathf.Clamp01(op.progress / 0.9f);

            Debug.Log($"보정된 progress: {progress}"); // (보정된 값 확인)
            // 로딩 바를 부드럽게 채우기 (Lerp 사용)
            progressBar.value = Mathf.Lerp(progressBar.value, progress, Time.deltaTime * 5f);
            progressText.text = $"Loading... {(int)(progressBar.value * 100)}%";

            // UI의 로딩바가 100%에 도달했는지 확인
            if (progressBar.value >= 0.99f && op.progress >= 0.9f)
            {
                Debug.Log("씬 활성화! 로딩 완료"); // (C) 이 로그가 나오는지 확인

                // 전환 직전에 1.0으로 강제 설정
                progressBar.value = 1.0f;
                progressText.text = "Loading... 100%";

                // 로딩이 완료되면 씬 전환을 허용
                op.allowSceneActivation = true;

                yield break; // 코루틴 종료 및 씬 전환
            }
        }
    }
}
