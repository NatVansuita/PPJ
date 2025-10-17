using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    [Header("Jogador")]
    public GameObject player;

    [Header("Pontuação")]
    public int score = 0;
    public int pontosParaProximaFase = 10;

    [Header("UI")]
    public GameObject mainCanvas;
    public TMP_Text mainScoreDisplay;

    [Header("Game Over")]
    public GameObject gameOverCanvas;
    public TMP_Text gameOverScoreDisplay;

    [Header("Fase Concluída")]
    public GameObject beatLevelCanvas;

    [Header("Botões")]
    public GameObject botaoReiniciar;
    public GameObject botaoProximaFase;

    [Header("Áudio")]
    public AudioSource backgroundMusic;        // Música de fundo contínua
    public AudioClip gameOverSFX;
    public AudioClip beatLevelSFX;

    [Header("Troca de Cena")]
    public string nomeDaProximaCena = "NomeDaCena";

    public enum GameState { Playing, GameOver, BeatLevel }
    public GameState gameState = GameState.Playing;

    void Awake()
    {
        if (gm == null)
            gm = this;
    }

    void Start()
    {
        score = 0;
        UpdateScore(0);
        gameState = GameState.Playing;

        Time.timeScale = 1f;

        mainCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        beatLevelCanvas.SetActive(false);

        if (botaoReiniciar != null)
            botaoReiniciar.SetActive(false);

        if (botaoProximaFase != null)
            botaoProximaFase.SetActive(false);

        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.loop = true;
            backgroundMusic.Play(); // Inicia a música de fundo automaticamente
        }
    }

    void Update()
    {
        if (gameState == GameState.Playing && score >= pontosParaProximaFase)
        {
            FaseConcluida();
        }
    }

    public void UpdateScore(int amount)
    {
        score += amount;
        mainScoreDisplay.text = $"{score}/{pontosParaProximaFase}";
    }

    public void EndGame()
    {
        if (gameState != GameState.Playing) return;

        gameState = GameState.GameOver;

        if (player != null)
            player.SetActive(false);

        if (backgroundMusic != null)
            backgroundMusic.Stop();

        if (gameOverSFX != null)
            AudioSource.PlayClipAtPoint(gameOverSFX, transform.position);

        mainCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        gameOverScoreDisplay.text = $"Prêmios coletados: {score} Game Over";

        if (botaoReiniciar != null)
            botaoReiniciar.SetActive(true);

        Time.timeScale = 0f;
    }

    void FaseConcluida()
    {
        gameState = GameState.BeatLevel;

        if (player != null)
            player.SetActive(false);

        if (backgroundMusic != null)
            backgroundMusic.Stop();

        if (beatLevelSFX != null)
            AudioSource.PlayClipAtPoint(beatLevelSFX, transform.position);

        mainCanvas.SetActive(false);
        beatLevelCanvas.SetActive(true);

        if (botaoProximaFase != null)
            botaoProximaFase.SetActive(true);

        Time.timeScale = 0f;
    }

    public void ReiniciarFase()
    {
        Time.timeScale = 1f;
        Scene cenaAtual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(cenaAtual.name);
    }

    public void IrParaProximaFase()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nomeDaProximaCena);
    }
}
