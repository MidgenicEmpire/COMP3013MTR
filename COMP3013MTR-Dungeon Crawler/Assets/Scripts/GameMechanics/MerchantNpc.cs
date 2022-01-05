using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MerchantNpc : MonoBehaviour
{

    public Transform player;
    
    public GameObject merchant;
    public Image prefabUI;
   // private Image uiUse;
  //  private Transform uiLoc;
    //private Vector3 offset = new Vector3(0, 3.0f, 0);
    private Animator animator;
    bool isEPressed = false;
    public GameObject shopInterface;
    public AudioSource greeting;
    public AudioSource leaving;
    public static bool isInShop = false;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // uiUse = Instantiate(prefabUI, FindObjectOfType<Canvas>().transform).GetComponent<Image>();

        // uiLoc = transform.GetChild(0);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotationPoint = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        transform.LookAt(rotationPoint);
        // player = GameObject.FindGameObjectWithTag("Player");

        //uiUse.transform.position = Camera.main.WorldToScreenPoint(uiLoc.position + offset);
        //
        // float v = Vector3.Distance(transform.position, player.transform.position);
        //  float dist = v;
        //  dist = Mathf.Clamp(dist, 0.5f, 1.0f);

        //  uiUse.transform.localScale = new Vector3(dist, dist, 0);
        //
        // checkDistance();
    }
    private void FixedUpdate()
    {
       
    }
    private void LateUpdate()
    {
        
        //  Interacted();
        if (Input.GetKeyDown(KeyCode.E))
        {
            isEPressed = true;
        }
    }
    private void checkDistance()
    {
        float minDistance = 10;

        float dist = Vector3.Distance(transform.position, player.transform.position);

        if(dist < minDistance)
        {
            merchant.SetActive(true);
        }
        if(dist > minDistance)
        {
            merchant.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        isEPressed = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
       // Interacted();
        Debug.Log("Triggered");
    }
    private void OnTriggerStay(Collider other)
    {
       
       Interacted();
        Debug.Log("Triggered");
    }
    private void OnTriggerExit(Collider other)
    {
        Time.timeScale = 1.0f;

        shopInterface.SetActive(false);

        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;

        leaving.PlayDelayed(1.0f);

        isInShop = false;
    }
    private void Interacted() 
    {

        if (isEPressed == true)
        {
            isInShop = true;

            Time.timeScale = 0f;

            animator.SetBool("isInteracted", true);
            //open the inventory
            Debug.Log("Inventory Open");

            shopInterface.SetActive(true);

            greeting.PlayDelayed(0.5f);

            isEPressed = false;
        }
        else animator.SetBool("isInteracted", false);

        isInShop = false;
    }
}
