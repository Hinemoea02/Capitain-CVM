using UnityEngine;
using UnityEngine.SceneManagement;

public class FinDeNiveau2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Félicitation, le niveau est terminé.");
            GameManager.Instance.SaveData();
            GameManager.Instance.PlayerData.AjouterCompleteLevel("Level2");
            SceneManager.LoadScene("Level3");
        }
    }
}
