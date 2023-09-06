using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UptdateScoreText();
    }
    private void UptdateScoreText()
    {
        scoreText.text = "Score:" + score.ToString();
    }
}
