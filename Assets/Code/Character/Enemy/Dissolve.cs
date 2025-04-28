using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    [SerializeField]
    private float dissolveDuration = 3f;

    private int dissolveAmount = Shader.PropertyToID("_DissolveAmount");

    [SerializeField]
    private List<Renderer> enemyRenderers;
    [SerializeField]
    private Material dissolverShader;

    private EnemyCharacter myCharacter;

    // Start is called before the first frame update
    void Start()
    {
        myCharacter = gameObject.GetComponent<EnemyCharacter>();

        myCharacter.DeathEvent += EnemyDied;
    }
    public void EnemyDied()
    {
        StartCoroutine(EnemyDissolve());
        myCharacter.SetEnemyBehaviour(new EnemyDeathBehaviour());
    }

    //TODO
    IEnumerator EnemyDissolve()
    {
        yield return new WaitForSeconds(dissolveDuration);
            
        gameObject.SetActive(false);

    }
}
