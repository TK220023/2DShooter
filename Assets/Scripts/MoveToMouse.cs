using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MoveToMouse : MonoBehaviour
{
    Vector3 touchWorldPos;
    public GameObject destination;
    public GameObject player;

    [SerializeField]
    IsCrushed isCrushed;
    EnemyManager enemyManager;

    [Header("プレイヤーの移動速度")]
    public float speed = 20f;

    [Header("ノルマ数")]
    public int goal = 10;

    /// <summary>
    /// ノルマUI
    /// </summary>
    [SerializeField] TextMeshProUGUI quotaCounter;

    /// <summary>
    /// 残ノルマ数を取得
    /// </summary>
    int Quota => goal - enemyManager.killedEnemyCount;
    /// <summary>
    /// ノルマUIを更新
    /// </summary>
    void UpdateQuotaUI() => quotaCounter.text = Quota.ToString();

    public void Awake()
    {
        enemyManager = GameObject.FindWithTag("GameController").GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameState();
        UpdateQuotaUI();
        UpdatePlayerMovement();
    }

    /// <summary>
    /// ゲームの状態を確認し、ゲームオーバーかクリアかを判定する
    /// </summary>
    void CheckGameState()
    {
        // もしクラッシュしたらゲームオーバー画面に移動
        if (isCrushed.isCrush)
        {
            ChangeScene("RetryScene");
        }
        // もしノルマを達成したらクリア画面に移動
        if(enemyManager.killedEnemyCount >= goal)
        {
            ChangeScene("ClearScene");
        }
    }

    void UpdatePlayerMovement()
    {
        // マウス位置を取得し目的地に設定
        SetDestination();        

        // プレイヤーを移動させる        
        Move();
        // プレイヤーを目的地に向かせる
        Rotate();
    }

    void SetDestination()
    {
        destination.transform.position = GetMousePosition();
    }

    Quaternion GetPlayerRotation(Transform destination, Transform playerPosition)
    {
        Vector3 rotateVec = destination.position - playerPosition.position;
        return Quaternion.FromToRotation(Vector3.up, rotateVec);
    }

    void Rotate()
    {
        player.transform.rotation = GetPlayerRotation(destination.transform, player.transform);
    }

    void Move()
    {
        transform.position = GetPlayerMoveVec(speed);
    }

    Vector3 GetPlayerMoveVec(float speed)
    {
        return Vector3.MoveTowards(player.transform.position, destination.transform.position, speed * Time.deltaTime);
    }

    Vector3 GetMousePosition()
    {
        Vector3 touchScreenPos = Input.mousePosition;
        touchScreenPos.z = 10f;
        Camera camera = Camera.main;
        touchWorldPos = camera.ScreenToWorldPoint(touchScreenPos);

        return touchWorldPos;
    }

    void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(touchWorldPos, 0.1f);
    }
}
