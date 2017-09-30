using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static int jikiHP = 5000;

    public static int playerHP = jikiHP;

    Enemy enemy = new Enemy();
    // Spaceshipコンポーネント
    Spaceship spaceship;
    public static bool shootingIs = true;

    IEnumerator Start()
    {
        // Spaceshipコンポーネントを取得
        spaceship = GetComponent<Spaceship>();
        while (shootingIs)
        {

            // 弾をプレイヤーと同じ位置/角度で作成
            spaceship.Shot(transform);

            // ショット音を鳴らす
            GetComponent<AudioSource>().Play();

            // shotDelay秒待つ
            yield return new WaitForSeconds(spaceship.shotDelay);
        }

    }

    void Update()
    {

        // 右・左
        //float x = Input.GetAxisRaw("Horizontal");

        // 上・下
        //float y = Input.GetAxisRaw("Vertical");

        // 移動する向きを求める
        //Vector2 direction = new Vector2(x, y).normalized;

        // 移動
        //spaceship.Move(direction);

        //スマホ向けインターフェース
        //if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        //{
        // 右・左
        float xC = CrossPlatformInputManager.GetAxisRaw("Horizontal");

            // 上・下
            float yC = CrossPlatformInputManager.GetAxisRaw("Vertical");

            // 移動する向きを求める
            Vector2 directionC = new Vector2(xC, yC);

            // 移動
            Move(directionC);
        //}
        DarkMode.DarkDamage();
    }

    // 機体の移動
    void Move(Vector2 direction)
    {
        // 画面左下のワールド座標をビューポートから取得
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // 画面右上のワールド座標をビューポートから取得
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // プレイヤーの座標を取得
        Vector2 pos = transform.position;

        // 移動量を加える
        pos += direction * spaceship.speed * Time.deltaTime;

        // プレイヤーの位置が画面内に収まるように制限をかける
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // 制限をかけた値をプレイヤーの位置とする
        transform.position = pos;
    }

    // ぶつかった瞬間に呼び出される
    void OnTriggerEnter2D(Collider2D c)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // レイヤー名がBullet (Enemy)の時は弾を削除
        if (layerName == "Bullet(Enemy)")
        {
            // 弾の削除
            Destroy(c.gameObject);
        }

        // レイヤー名がBullet (Enemy)またはEnemyの場合は体力を減らす
        if (layerName == "Bullet(Enemy)" || layerName == "Enemy")
        {
            playerHP -= enemy.AttackPower;
            if (playerHP <= 0)
            {
                //マイナス表示にならないようにする。
                playerHP = 0;
                // Managerコンポーネントをシーン内から探して取得し、GameOverメソッドを呼び出す
                FindObjectOfType<Manager>().GameOver();

                // 爆発する
                spaceship.Explosion();

                // プレイヤーを削除
                Destroy(gameObject);
            }
        }
    }
    //DestroyAreaから出た瞬間に爆発する
    void OnTriggerExit2D(Collider2D c)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);
        if (layerName == "DestroyArea")
        {
            // Managerコンポーネントをシーン内から探して取得し、GameOverメソッドを呼び出す
            FindObjectOfType<Manager>().GameOver();
            // 爆発する
            spaceship.Explosion();
            Destroy(gameObject);
        }
    }
}