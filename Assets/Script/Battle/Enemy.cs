using UnityEngine;
using System.Collections;


public class Enemy : MonoBehaviour
{
    public int AttackPower = 700;
    public int hp = 1000;
    // Spaceshipコンポーネント
    Spaceship spaceship;
    //Scoreコンポーネント
    Score score = new Score();
    // Bulletコンポーネント
    Bullet bullet = new Bullet();
    
    int count = 0;
    public int turningPoint = 500;//何カウントで上下移動の折り返しをするかを決める変数

    IEnumerator Start()
    {
        // Spaceshipコンポーネントを取得
        spaceship = GetComponent<Spaceship>();
        while (true)
        {
            // 子要素を全て取得する
            for (int i = 2; i < transform.childCount; i++)
            {
                Transform shotPosition = transform.GetChild(i);
                // ShotPositionの位置/角度で弾を撃つ
                spaceship.Shot(shotPosition);
            }
            // shotDelay秒待つ
            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }
    void Update()
    {
        EnemyMove();
    }

    //エネミーを上下に動かす
    void EnemyMove()
    {
        if (0 <= count && count <= turningPoint)
        {
            spaceship.Move(transform.up * -1);
        }
        else if (turningPoint < count && count < turningPoint * 2)
        {
            spaceship.Move(transform.up * 1);
        }
        if (count == turningPoint * 2)
        {
            count = 0;
        }
        count++;
    }

    //当たり判定が発生した時の処理
    void OnTriggerEnter2D(Collider2D c)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // レイヤー名がBullet (Player)以外の時は何も行わない
        if (layerName != "Bullet(Player)") return;

        // ヒットポイントを減らす
        hp -= Bullet.power;

        // 弾の削除
        Destroy(c.gameObject);

        //スコアゲット
        Score.score += Bullet.power;

        // ヒットポイントが0以下であれば
        if (hp <= 0)
        {
            //スコア加算
            Score.score += Bullet.power * 10;
            // 爆発
            spaceship.Explosion();
            // エネミーの削除
            Destroy(gameObject);
        }
        else
        {
            spaceship.GetAnimator().SetTrigger("Damage");
        }
    }
}