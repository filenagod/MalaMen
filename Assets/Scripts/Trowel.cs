using UnityEngine;

public class Trowel : MonoBehaviour
{
    public int scoreAmount = 2;
    [SerializeField] private GameObject trowel;
    [SerializeField] private GameObject deadEffect;
    // prefab i�inde 
    Bridge bridge;

    private void Awake()
    {
        bridge = GameObject.FindGameObjectWithTag("Bridge").GetComponent<Bridge>();
    }


    // Update is called once per frame
    void Update()
    {

    }
    // ��inden ge�me durumlar�nda 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.score += scoreAmount;
            Instantiate(deadEffect, transform.position, transform.rotation);
            Destroy(gameObject);

            if (bridge.toArrive.Count > 0)
            {

                bridge.toArrive[0].SetActive(true);
                bridge.toArrive.Remove(bridge.toArrive[0]);
            }

        }
    }
    //private void OnDisable()
    //{
    //    Instantiate(deadEffect, transform.position, transform.rotation);
    //}
}
