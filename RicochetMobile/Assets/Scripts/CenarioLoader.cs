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

    [SerializeField] CenarioSO cenario;
    void Start()
    {
        LoadCenario(cenario);
    }

    void Update()
    {
        
    }
    public void LoadCenario(CenarioSO scenario)
    {
        StartCoroutine(GrowShrinkEffect(sideDecorations, scenario.sideDecorationsSprites));
        StartCoroutine(SwitchSpriteNoEffect(sideWalls, new Sprite[] { scenario.sideWalls }));
         
        StartCoroutine(GrowShrinkEffect(new Transform[] {topDecoration}, new Sprite[] {scenario.topSprite}));

        StartCoroutine(SwitchSpriteNoEffect(grounds, new Sprite[] { scenario.groundSprite }));
        StartCoroutine(GrowShrinkEffect(barriers, new Sprite[] { scenario.barrierSprite })); //convertendo para array        
    }
    IEnumerator GrowShrinkEffect(Transform[] array, Sprite[] spritesToChange = null)
    {
        bool isSpritesNull = spritesToChange == null;
        bool hasOnlyOneSprite = spritesToChange?.Length == 1;

        for (int i = 0; i < array.Length; i++)
        {
            
            Transform objectToChange = array[i];
            Vector3 vector3 = objectToChange.localScale;

            objectToChange.gameObject.SetActive(true);
            objectToChange.DOScale(new Vector3(vector3.x + growSize, vector3.y + growSize, vector3.z + growSize), 0.5f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InOutSine);

            if(!isSpritesNull)
            {
                SpriteRenderer objectToChangeRenderer = objectToChange.GetComponent<SpriteRenderer>();

                if (hasOnlyOneSprite)
                {
                    objectToChangeRenderer.sprite = spritesToChange[0];
                }
                else
                {
                    objectToChangeRenderer.sprite = spritesToChange[i];
                }
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator SwitchSpriteNoEffect(Transform[] array, params Sprite[] newSprites)
    {
        bool hasOnlyOneSprite = newSprites.Length == 1;
        Sprite loneSprite = hasOnlyOneSprite ? newSprites[0] : null;
        for(int i = 0; i < array.Length; i++)
        {
            SpriteRenderer sideDecoration = array[i].GetComponent<SpriteRenderer>();
            Sprite sprite = sideDecoration.sprite;
            print("trocando sprite para: " + sprite.name);
            if (sprite == null) 
            {
                sideDecoration.gameObject.SetActive(false);
            }
            else
            {
                if (hasOnlyOneSprite)
                    sideDecoration.sprite = loneSprite;
                else sideDecoration.sprite = sprite;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}
