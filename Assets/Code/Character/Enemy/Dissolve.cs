using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    public Material dissolveShader;
    public float activationDuration = 3f;

    public List<Renderer> enemyRenderers;

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

    IEnumerator EnemyDissolve()
    {
        if (dissolveShader != null && enemyRenderers != null)
        {
            foreach (Renderer enemyParts in enemyRenderers)
            {
                Material originalMaterial = enemyParts.material;
                enemyParts.material = dissolveShader;
            }

            yield return new WaitForSeconds(activationDuration);
            
            gameObject.SetActive(false);

        }
    }
}
