using UnityEngine;



public class Condition : MonoBehaviour
{
    
    private PlayerMovement playerMovement;
    public int scoreCondition = 1;
    public float increaseAmount;
    [SerializeField] private GameObject condition;
    [SerializeField] private GameObject deadEffect;
    // Start is called before the first frame update

    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.score += scoreCondition;
            playerMovement.IncreaseHealth(increaseAmount);
            Instantiate(deadEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    //private void OnDisable()
    //{
    //     Instantiate(deadEffect, transform.position,transform.rotation);
    //}
}
