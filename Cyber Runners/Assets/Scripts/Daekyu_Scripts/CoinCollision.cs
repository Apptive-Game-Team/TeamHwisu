using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            GameObject gameManager = GameObject.Find("GameManager");

            if (gameManager != null)
            {
                Wonje_DataManager dataManager = gameManager.GetComponent<Wonje_DataManager>();

                if (dataManager != null)
                {
                    dataManager.curcoin += 1;
                    Debug.Log("ÄÚÀÎ È¹µæ! ÇöÀç ÄÚÀÎ: " + dataManager.curCoin);
                }
            Destroy(other.gameObject);
        }
    }
}
