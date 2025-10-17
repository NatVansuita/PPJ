using UnityEngine;

public class SpawnerVisivelNaTela : MonoBehaviour
{
    public GameObject objetoParaSpawnar;
    public float intervaloSpawn = 0.5f;

    public Camera cameraPrincipal;
    
    void Start()
    {
        InvokeRepeating("SpawnarNaTela", 1f, intervaloSpawn);
    }

    void SpawnarNaTela()
    {
        if (cameraPrincipal == null)
        {
            cameraPrincipal = Camera.main;
        }

        // Pega limites da tela em unidades do mundo
        float alturaTela = 2f * cameraPrincipal.orthographicSize;
        float larguraTela = alturaTela * cameraPrincipal.aspect;

        // Gera uma posição dentro da tela
        float posX = Random.Range(cameraPrincipal.transform.position.x - larguraTela / 2f, cameraPrincipal.transform.position.x + larguraTela / 2f);
        float posY = Random.Range(cameraPrincipal.transform.position.y - alturaTela / 2f, cameraPrincipal.transform.position.y + alturaTela / 2f);
      float offsetAdiante = 8f; // Maior distância à frente
        Vector2 posicaoSpawn = new Vector2(posX, posY);
        Instantiate(objetoParaSpawnar, posicaoSpawn, Quaternion.identity);

  


    }
    void SpawnarNaFrente()
{
    if (cameraPrincipal == null)
    {
        cameraPrincipal = Camera.main;
    }

    float offsetY = 15f; // Distância à frente no eixo Y
    float posX = cameraPrincipal.transform.position.x;
    float posY = cameraPrincipal.transform.position.y + offsetY;

    Vector2 posicaoSpawn = new Vector2(posX, posY);
    Instantiate(objetoParaSpawnar, posicaoSpawn, Quaternion.identity);
}

    [Header("Objetos a Gerar")]
    public GameObject[] objetosParaSpawnar;
    public float spawnInterval = 0.5f;

    [Header("Variação Vertical")]
    public float spawnYRange = 2f;

    [Header("Referência ao Jogador")]
    public Transform jogador; // Arraste o jogador aqui pelo Inspector
    public float distanciaFrente = 8f; // Distância à frente do jogador

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnarPertoDoJogador();
            timer = 0f;
        }
    }

    void SpawnarPertoDoJogador()
    {
       
    if (jogador == null) {
        Debug.LogWarning("Jogador não atribuído ao Spawner!");
        return;
    }

    // A posição de spawn será à frente do jogador, no eixo X
    Vector3 spawnPos = jogador.position + Vector3.right * distanciaFrente;

    // Variação vertical para deixar mais dinâmico (opcional)
    spawnPos.y += Random.Range(-spawnYRange, spawnYRange);

    // Instancia um objeto aleatório da lista
    Instantiate(objetosParaSpawnar[Random.Range(0, objetosParaSpawnar.Length)], spawnPos, Quaternion.identity);
}


}