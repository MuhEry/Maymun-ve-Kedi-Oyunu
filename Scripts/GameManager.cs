using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverUI;
    public GameObject partialSuccessUI;
    public GameObject successUI;
    public Text timerText;
    public Text bananaScoreText;
    public Text watermelonScoreText;
    public float levelTime = 60f; // Bölüm süresi (saniye cinsinden)

    private float currentTime;
    private bool gameHasEnded = false;
    private bool catReached = false;
    private bool monkeyReached = false;
    private int totalBananas;
    private int totalWatermelons;
    private int collectedBananas;
    private int collectedWatermelons;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentTime = 0f; // Baþlangýçta süreyi sýfýrdan baþlatýyoruz
        totalBananas = FindObjectsOfType<BananaCoin>().Length; // Tüm muzlarýn sayýsýný al
        totalWatermelons = FindObjectsOfType<WatermelonCoin>().Length; // Tüm karpuzlarýn sayýsýný al
        UpdateScoreUI();
    }

    void Update()
    {
        if (!gameHasEnded)
        {
            // Süreyi güncelle
            currentTime += Time.deltaTime;
            int minutes = Mathf.FloorToInt(currentTime / 60F);
            int seconds = Mathf.FloorToInt(currentTime % 60F);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            // ESC tuþuna basýldýðýnda oyunu bitir
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                EndGame("esc");
            }
        }
    }

    public void CharacterReachedDoor(string characterTag)
    {
        if (characterTag == "CatDoor")
        {
            catReached = true;
        }
        else if (characterTag == "MonkeyDoor")
        {
            monkeyReached = true;
        }

        CheckLevelComplete();
    }

    public void CharacterLeftDoor(string characterTag)
    {
        if (characterTag == "CatDoor")
        {
            catReached = false;
        }
        else if (characterTag == "MonkeyDoor")
        {
            monkeyReached = false;
        }
    }

    private void CheckLevelComplete()
    {
        if (catReached && monkeyReached)
        {
            if (collectedBananas == totalBananas && collectedWatermelons == totalWatermelons && currentTime <= levelTime)
            {
                LevelComplete(true);
            }
            else
            {
                LevelComplete(false);
            }
        }
    }

    public void AddBananaScore()
    {
        collectedBananas++;
        UpdateScoreUI();
    }

    public void AddWatermelonScore()
    {
        collectedWatermelons++;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (bananaScoreText != null)
        {
            bananaScoreText.text = "Bananas: " + collectedBananas + "/" + totalBananas;
        }

        if (watermelonScoreText != null)
        {
            watermelonScoreText.text = "Watermelons: " + collectedWatermelons + "/" + totalWatermelons;
        }
    }

    public void EndGame(string reason)
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Time.timeScale = 0f; // Oyunu durdur

            // ESC tuþu ile gelirse
            if (reason == "esc")
            {
                gameOverUI.SetActive(true); // ESC basýldýðýnda baþarýsýz ekranýný aç
            }
            else if (reason == "enemy")
            {
                gameOverUI.SetActive(true);
            }
        }
    }

    public void LevelComplete(bool isSuccess)
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Time.timeScale = 0f; // Oyunu durdur

            if (isSuccess)
            {
                successUI.SetActive(true);
            }
            else
            {
                partialSuccessUI.SetActive(true);
            }
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f; // Oyunu tekrar baþlat
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f; // Oyunu tekrar baþlat
        SceneManager.LoadScene("MainMenu");
    }
}
