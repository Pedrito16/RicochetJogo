using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.SceneManagement;
public class CenarioLoader : MonoBehaviour
{
    [Header("Cenario Elements - Array")]
    [SerializeField] Transform[] sideDecorations = new Transform[12];
    [SerializeField] Transform[] sideWalls = new Transform[8];
    [SerializeField] Transform[] grounds = new Transform[3];
    [SerializeField] Transform[] barriers = new Transform[3];

    [Header("Cenario Elements - single")]
    [SerializeField] Transform topDecoration;
    [SerializeField] float growSize;
    void Start()
    {
        StartCoroutine(GrowShrinkEffect(sideDecorations));
        StartCoroutine(GrowShrinkEffect(barriers));
    }

    void Update()
    {
        
    }
    public void LoadCenario(CenarioSO cenario)
    {
        StartCoroutine(GrowShrinkEffect(sideDecorations, cenario.sideDecorationsSprites));

        StartCoroutine(GrowShrinkEffect(barriers, new Sprite[] { cenario.barrierSprite })); //convertendo para array
        StartCoroutine(GrowShrinkEffect(new Transform[] {topDecoration}, new Sprite[] {cenario.topSprite}));

        StartCoroutine(SwitchSpriteNoEffect(sideWalls, cenario.sideWalls));
        StartCoroutine(SwitchSpriteNoEffect(grounds, cenario.groundSprite));
    }
    IEnumerator GrowShrinkEffect(Transform[] array, Sprite[] spritesToChange = null)
    {
        bool isSpritesNull = spritesToChange == null;
        for (int i = 0; i < array.Length; i++)
        {
            Transform objectToChange = array[i];
            objectToChange.gameObject.SetActive(true);
            Vector3 vector3 = objectToChange.localScale;
            objectToChange.DOScale(new Vector3(vector3.x + growSize, vector3.y + growSize, vector3.z + growSize), 0.5f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutSine);
            if(!isSpritesNull)
            {
                Sprite spriteToChange = spritesToChange[i];
                SpriteRenderer sideDecorationSR = objectToChange.GetComponent<SpriteRenderer>();
                if (spriteToChange != null)
                {
                    sideDecorationSR.sprite = spriteToChange;
                }
                else
                {
                    objectToChange.gameObject.SetActive(false);
                }
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator SwitchSpriteNoEffect(Transform[] array, params Sprite[] newSprites)
    {
        for(int i = 0; i < array.Length; i++)
        {
            SpriteRenderer sideDecoration = sideDecorations[i].GetComponent<SpriteRenderer>();
            Sprite sprite = sideDecoration.sprite;

            if(sprite == null) sideDecoration.gameObject.SetActive(false);
            else sideDecoration.sprite = sprite;

            yield return new WaitForSeconds(0.2f);
        }
    }
    
}
