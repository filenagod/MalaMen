using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public bool gameOver = false;
    public bool gameFinished = false;
    [SerializeField] private Text timeText;
    [SerializeField] private float levelFinishTime = 50f;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    //[SerializeField] private List<GameObject> destoryAfterGame = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameFinished == false && gameOver == false)
        {
            UpdateTheTimer();
        }
        

        if (Time.timeSinceLevelLoad >= levelFinishTime && gameOver == false )
        {
            Time.timeScale = 0f;
            gameFinished = true;
            winPanel.gameObject.SetActive(false);
            losePanel.gameObject.SetActive(true);

        }

        if (gameOver == true)
        {
            Time.timeScale = 0f;
            losePanel.gameObject.SetActive(false);
            winPanel.gameObject.SetActive(true);
            //UpdateObjectList("Objects");
            //UpdateObjectList("Trowel");
            //foreach (GameObject allObjects in destoryAfterGame)
            //{
            //    Destroy(allObjects);
            //}
        }
    }
    //private void UpdateObjectList(string tag)
    //{
    //    destoryAfterGame.AddRange(GameObject.FindGameObjectsWithTag(tag));
    //}
    private void UpdateTheTimer()
    {
        timeText.text = "Time: " + (int)Time.timeSinceLevelLoad;
    }
}
