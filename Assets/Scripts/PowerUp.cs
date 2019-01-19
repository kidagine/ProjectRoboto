    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private SpriteRenderer sprite;
    public GameObject player;
	public GameObject playerHead;
    // Use this for initialization
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy(playerHead,0.3f);
	}
	//Invoked by animation
    private void BackgroundLayer()
    {
        player.GetComponent<PlayerPos>().enabled = true;
        sprite.sortingOrder = -12;
        StartCoroutine(playerTransf());
        CameraFollow.activateSecond = true;
    }
   IEnumerator playerTransf()
    {
        yield return new WaitForSeconds(0f);
        player.transform.position = new Vector3(transform.position.x + 0.1f, transform.position.y - 0.8f, 0);
        yield return 0;
    }
}
