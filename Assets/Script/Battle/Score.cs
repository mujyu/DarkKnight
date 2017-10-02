using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // スコアを表示するGUIText
    public Text scoreText;

    // ハイスコアを表示するGUIText
    public Text highScoreText;

    //残り体力の表示
    public Text playerHPText;

    // スコア
    public static int score;

    // ハイスコア
    public static int highScore = 0;

    // PlayerPrefsで保存するためのキー
    private string highScoreKey = "highScore";

    //攻撃力を表示する
    public Text attackText;

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        // スコアがハイスコアより大きければ
        if (highScore < score)
        {
            highScore = score;
        }

        // スコア・ハイスコアを表示する
        scoreText.text = score.ToString();
        highScoreText.text = "HighScore : " + highScore.ToString();
        //残り体力の表示
        playerHPText.text = "HP:" + Player.playerHP.ToString();
        if (Player.playerHP <= 0)
        {
            playerHPText.text = "Danger!!!!";
        }
        attackText.text = "Attack:" + Bullet.power;
    }

    // ゲーム開始前の状態に戻す
    private void Initialize()
    {
        // スコアを0に戻す
        score = 0;

        //自機のHPを元に戻す
        Player.playerHP = Player.jikiHP;

        //ダークモードをfalseにする
        DarkMode.darkModeIs = false;

        // ハイスコアを取得する。保存されてなければ0を取得する。
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);

    }


    // ハイスコアの保存
    public void Save()
    {
        // ハイスコアを保存する
        PlayerPrefs.SetInt(highScoreKey, highScore);
        PlayerPrefs.Save();

        // ゲーム開始前の状態に戻す
        Invoke("Initialize",3.7f);
    }
}