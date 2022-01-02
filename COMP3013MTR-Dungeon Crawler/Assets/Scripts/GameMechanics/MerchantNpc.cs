using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MerchantNpc : MonoBehaviour
{

    private GameObject player;
    public GameObject merchant;
    public Image prefabUI;
    private Image uiUse;
    private Transform uiLoc;
    private Vector3 offset = new Vector3(0, 3.0f, 0);
    private Animator animator;

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        uiUse = Instantiate(prefabUI, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        uiLoc = transform.GetChild(0);

      


    }

    // Update is called once per frame
    void Update()

    {
       
  
        uiUse.transform.position = Camera.main.WorldToScreenPoint(uiLoc.position + offset);

        float dist = Vector3.Distance(transform.position, player.transform.position);
        dist = Mathf.Clamp(dist, 0.5f, 1.0f);
       
        uiUse.transform.localScale = new Vector3(dist, dist, 0);

        checkDistance();
    }
    private void FixedUpdate()
    {
       
    }
    private void LateUpdate()
    {
        Interacted();
    }
    private void checkDistance()
    {
        float minDistance = 10;

        float dist = Vector3.Distance(transform.position, player.transform.position);

        if(dist < minDistance)
        {
            merchant.SetActive(true);
        }
        else if(dist > minDistance)
        {
            merchant.SetActive(false);
        }
    }
    private void Interacted() 
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetBool("isInteracted", true);
        }
        else animator.SetBool("isInteracted", false);
    
    }
}
