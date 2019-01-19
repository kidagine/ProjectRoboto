    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;



public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform player;
    public Transform fullPlayer;
    public GameObject head;

    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    public Vector2 targett;
    public Vector2 focusAreaSize;
    public bool check = false;
    public static bool activateSecond = false;
    private bool Zoom = false;
    private bool follow = false;
    private bool doubleCheck = true;
    private bool now = false;
    private bool nownow = false;
    public float TargetFOV = 5;
    public float smoothTime = 0.3F;
    public float speed = 0.125f;
    public float Speed = 1f;
   
    private float fallDelay = 5f;
    
    [SerializeField] private float xDifference;
    [SerializeField] private float yDifference;
    [SerializeField] private float movementThreshold = 3;

    private void Awake()
    {


    }

    void Update()
    {

        if (PlayerMovement.fallDeath == true)
        {

            transform.position += target.position - new Vector3(0, 10, 0);
        }
        if (MeteoriteGoDown.spawn == true && (doubleCheck = true))
        {
            follow = true;
            Instantiate(head, new Vector3(-5.44f, 1f, 0f), transform.rotation = Quaternion.identity);
            doubleCheck = false;
            MeteoriteGoDown.spawn = false;
        }
        if (Input.anyKey)
        {
            Zoom = true;
        }
        if (Zoom == true)
        {
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, TargetFOV, Speed * Time.deltaTime);
        }
        if (follow == true)
        {
            target = GameObject.Find("PlayerHead(Clone)").transform; 
            transform.position = target.position + offset;


            transform.LookAt(target);
            nownow = true;
        }
        if (PlayerHead.body == true)
        {
          
            doubleCheck = false;
            MeteoriteGoDown.spawn = false;
        }
        if (now == true)
        {
           
            target = GameObject.Find("Player(Clone)").transform; 
            transform.position = target.position + offset;

            transform.LookAt(target);
        }

        if (doubleCheck == false)
            if (target != null)
            {
                doubleCheck = false;
                follow = false;
                StartCoroutine(Fall());
            }
        }
    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        
        yield return 0;
    }
    void LateUpdate()
    {
        xDifference = target.transform.position.x - transform.position.x;
        if (now == true)
        {
            if (xDifference >= movementThreshold) { 
                
            transform.position = target.position + offset;

            transform.LookAt(target);
                }
        }
        if (nownow == true)
        {

            transform.position = target.position + offset;

            transform.LookAt(target);

        }
        if (MeteoriteGoDown.spawn == false)
        {
                    transform.position = target.position + offset;

                    transform.LookAt(target);
            }
        }
    }
