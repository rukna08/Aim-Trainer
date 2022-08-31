using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour {
    float time;
    int count;

    bool playedGameOverSfx;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameOverText2;
    public TextMeshProUGUI finalPointsText;

    public AudioSource audioSource;
    public AudioClip burhSfx;
    public AudioClip gameoverSfx;

    private SpriteRenderer rend;

    void Start() {
        time = 11f;

        count = 0;

        playedGameOverSfx = false;

        gameOverText.text = "";
        gameOverText2.text = "";
        finalPointsText.text = "";

        rend = GetComponent<SpriteRenderer>();
    }

    void Update() {
        timerText.text = ((int)time).ToString();
        countText.text = count.ToString();

        if (time >= 0) {
            time -= Time.deltaTime;
        }

        if (time <= 0) {
            rend.enabled = false;

            Camera.main.backgroundColor = Color.blue;

            gameOverText.text = "GAME OVER";
            gameOverText2.text = "ENTER TO RESTART";

            finalPointsText.text = count.ToString();

            if (!playedGameOverSfx) {
                audioSource.PlayOneShot(gameoverSfx);
                playedGameOverSfx = true;
            }


            if (Input.GetKeyDown(KeyCode.Return)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void OnMouseDown() {
        if (time >= 0) {
            
            if (audioSource != null) {
                audioSource.PlayOneShot(burhSfx);
            }

            count++;
            transform.position = new Vector2(Random.Range(-8.0f, 8.0f), Random.Range(-4f, 4f));
        }
    }
}