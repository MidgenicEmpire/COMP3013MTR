using UnityEngine;



public class PickUp : MonoBehaviour
{
    public ItemObject item;
    public GameObject ItemObject;
    public GameObject Player;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other == Player)
        {

            Debug.Log("Item was hit");
            bool wasPickedUp = Inventory.instance.Add(item);
            if (wasPickedUp)
            {
                Destroy(gameObject);
                Debug.Log("Item was found but not picked up");
            }


        }



    }

}