using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MerchantNpc : MonoBehaviour
{

    private GameObject player;
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
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        
       // uiUse = Instantiate(prefabUI, FindObjectOfType<Canvas>().transform).GetComponent<Image>();

       // uiLoc = transform.GetChild(0);

    }

    // Update is called once per frame
    void Update()
    {
        
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
        shopInterface.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        leaving.PlayDelayed(1.0f);
    }
    private void Interacted() 
    {

        if (isEPressed == true)
        {

            animator.SetBool("isInteracted", true);
            //open the inventory
            Debug.Log("Inventory Open");

            shopInterface.SetActive(true);

            greeting.PlayDelayed(0.5f);

            isEPressed = false;
        }
        else animator.SetBool("isInteracted", false);
    }
}
