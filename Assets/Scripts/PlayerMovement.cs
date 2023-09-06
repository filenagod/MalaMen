using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{   private Animator animator;
    private Rigidbody rigidbody;
    public float maxHealth = 100;
    private float currentHealth;
    public float decreaseSpeed = 0.1f;
    public float lerpSpeed = 4f;
    public Image fillImage;
    private float x1;
    private float x2;
    [SerializeField] private float move = 0;
    [SerializeField] private float speed = 3f;
    private bool leftRun = false;
    private bool rightRun = false;
    [SerializeField] private float distance = 2f;
    [SerializeField] private TimeManager timeManager;
  
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        Time.timeScale = 1f;
    }

    void Update()
    {
        Debug.Log(Time.timeScale);
        Movement();
        currentHealth -= Time.deltaTime * decreaseSpeed;

        fillImage.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            FindObjectOfType<TimeManager>().gameOver = true;
            Time.timeScale = 0f;
        }
    }

    private void Movement()
    {
        float xposition = Mathf.Clamp(transform.position.x, -2.4f, 2.4f);
        transform.position = new Vector3(xposition, transform.position.y, transform.position.z);
        if (Input.GetMouseButtonDown(0))
        {
            x1 = Input.mousePosition.x;

        }

        if (Input.GetMouseButtonUp(0))
        {
            x2 = Input.mousePosition.x;

            if (x1 > x2 && !timeManager.gameOver && !timeManager.gameFinished)
            {

                Vector3 yeniKonum = transform.position + Vector3.left * distance;
                transform.position = yeniKonum;
            }

            if (x2 > x1 && !timeManager.gameOver && !timeManager.gameFinished)
            {

                Vector3 yeniKonum = transform.position + Vector3.right * distance;
                transform.position = yeniKonum;
            }
        }

        if (move == 2 )
        {
            transform.Translate(Vector3.right * (3 * Time.deltaTime));

            if (!rightRun)
            {
                // Ýlgili kodu buraya yazýn
                rightRun = true;
            }
        }


        if (move == 1)
        {
            transform.Translate(Vector3.left * (3 * Time.deltaTime));

            if (!leftRun)
            {
                // Ýlgili kodu buraya yazýn

                leftRun = true;
            }
        }

        transform.Translate(Vector3.forward * (speed * Time.deltaTime));

        //if (timeManager.gameOver || timeManager.gameFinished)
        //{
        //    Time.timeScale = 0f;
        //    Debug.Log("hava çok sýcak");
          
        //}

    }

    public void IncreaseHealth(float rate)
    {
        currentHealth += rate;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
}
