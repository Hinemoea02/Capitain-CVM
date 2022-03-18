using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMenuUpgrade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.PlayerData.AvoirListBonus().Contains(this.gameObject.name) == true)
            this.gameObject.SetActive(true);
        else
            this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
