using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class bonus : MonoBehaviour
{
    public string _bonusName;
    public Text _coinCount;
  
    [SerializeField] private GameObject _killa;

    private void Awake()
    {
        _coinCount.text = PlayerPrefs.GetInt("_coins").ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch(_bonusName)
            {
                case "coin":

                    int _coins = PlayerPrefs.GetInt("_coins");
                    PlayerPrefs.SetInt("_coins", _coins + 1);
                    _coinCount.text = (_coins + 1).ToString();
                    Destroy(gameObject);

                break;

                case "vodka":     
                    
                    Instantiate(_killa);
                    Destroy(gameObject);
                    Destroy(collision.gameObject);
                    Debug.Log("destroy");

                break;
            }
        }
    }
}
