using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtonAction : MonoBehaviour
{
    /// <summary>
    /// Permet d'afficher un panel transmis en paramètre
    /// </summary>
    /// <param name="PanelAOuvrir">Panel à afficher</param>
    public void AfficherPanel(GameObject PanelAOuvrir)
    {
        PanelAOuvrir.SetActive(true);
    }

    /// <summary>
    /// Permet de ferme aussi le panel actuel
    /// </summary>
    /// <param name="PanelAFermer">Panel à fermer</param>
    public void FermerPanel(GameObject PanelAFermer)
    {
        PanelAFermer.SetActive(false);
    }

    /// <summary>
    /// Permet de charger un niveau
    /// </summary>
    /// <param name="nom">Nom du niveau à charger</param>
    public void ChargerNiveau(string nom)
    {
        Debug.Log(GameManager.Instance.PlayerData.AvoirListLevel());

        if (nom.Equals("Level2"))
        {
            if(GameManager.Instance.PlayerData.AvoirListLevel().Contains("Level1") == true)
            {
                SceneManager.LoadScene(nom);
            }
            else
            {
                Debug.Log("Niveau 2 pas debloque");
            }
        }
        else if (nom.Equals("Level3"))
        {
            if (GameManager.Instance.PlayerData.AvoirListLevel().Contains("Level2") == true)
            {
                SceneManager.LoadScene(nom);
            }
            else
            {
                Debug.Log("Niveau 3 pas debloque");
            }
        }
        else
        {
            SceneManager.LoadScene(nom);
        }

    }

    public void AfficherCollectables(GameObject gameObject)
    {
        if (GameManager.Instance.PlayerData.AvoirListBonus().Contains(gameObject.name) == true)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }

    /// <summary>
    /// Permet de fermer l'application
    /// </summary>
    public void Quitter()
    {
        Application.Quit();
    }
}
