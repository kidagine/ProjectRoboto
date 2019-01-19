using UnityEngine;

public class PowerDestroy : MonoBehaviour {
    public GameObject Power;
	// Use this for initialization
	void Start () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(Power);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
