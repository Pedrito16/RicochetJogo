using UnityEngine;
using UnityEngine.UI;

public class Ad : MonoBehaviour
{
    [SerializeField] Sprite[] randomAdSprites;
    [SerializeField] Image adImage;
    bool alreadyAdded;
    void Start()
    {
        
    }
    public void OnClick()
    {
        adImage.gameObject.SetActive(true);
        adImage.sprite = randomAdSprites[Random.Range(0, randomAdSprites.Length)];
        if (alreadyAdded) return; //tem que fazer com que este script apareca na tela depois (atualmente, ele ganha o dinheiro normal no OnGameEnd e se ele quiser ele ve o video pra ganhar o dobro, ganhando o triplo)
        alreadyAdded = true;
        PlayerStats.instance.AddMoney(AddMoneyOnGameEnd.instance.moneyToAdd);
    }
}
