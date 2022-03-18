using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSave : MonoBehaviour
{
    [SerializeField]
    private AudioClip _clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameManager.Instance.AudioManager
                .PlayClipAtPoint(_clip, this.transform.position);
            GameManager.Instance
                .PlayerData.AjouterBonus(this.gameObject.name);
            GameObject.Destroy(this.gameObject);
        }
    }
}