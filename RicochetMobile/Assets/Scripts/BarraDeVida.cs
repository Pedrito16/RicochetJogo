using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class BarraDeVida : MonoBehaviour
{
    public int vidaTotal;

    [Header("Componentes Barra")]
    [SerializeField] Image vidaVermelha;
    [SerializeField] Image vidaLaranja;
    void Start()
    {
    }
    public void Setup(int maxLife)
    {
        vidaTotal = maxLife;
    }
    public void ResetValues()
    {
        vidaVermelha.fillAmount = 1;
        vidaLaranja.fillAmount = 1;
    }
    public float ConverterDanoParaFill(int valor)
    {
        return (float)valor / vidaTotal;
    }
    public IEnumerator MathLerp(float valueToModify, float finalValue, float duration, Action<float> onValueChange = null)
    {
        float iterador = Time.deltaTime;
        while(iterador < duration)
        {
            valueToModify = Mathf.Lerp(valueToModify, finalValue, iterador / duration);
            onValueChange?.Invoke(valueToModify);
            iterador += Time.deltaTime;
            yield return null;
        }
        onValueChange?.Invoke(valueToModify);
    }
    public void TomarDano(int currentLife)
    {

        StopAllCoroutines();
        //Desse jeito está funcionando, mas PRECISA ter apenas 1 IEnumerator de lerp rolando, o StopAllCoroutines faz isso por mim só pro Lerp ser genérico

        vidaVermelha.fillAmount = ConverterDanoParaFill(currentLife);
        StartCoroutine(MathLerp(vidaLaranja.fillAmount, vidaVermelha.fillAmount, 1, v => vidaLaranja.fillAmount = v));
    }
}
