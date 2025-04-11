using UnityEngine;
using System.Linq;
public class Organizar : MonoBehaviour
{
    [SerializeField] int[] numerosGrandes = new int[4];
    [SerializeField] int[] numerosSelecionados = new int[4];
    void Start()
    {
        numerosGrandes[0] = 4;
        numerosGrandes[1] = 6;
        numerosGrandes[2] = 10;
        numerosGrandes[3] = 99999999;
        OrganizarNumeros();
    }
    void OrganizarNumeros()
    {
        print("Organizando");
        numerosGrandes.Select(numerosGrandes => numerosGrandes)
                      .Where(numerosGrandes => numerosGrandes < 8)
                      .ToArray();
        
                      
    }
}
