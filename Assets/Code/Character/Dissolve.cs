using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    public Material dissolveShader;
    public float activationDuration = 3f;

    public List<Renderer> enemyRenderers;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<EnemyCharacter>().DeathEvent += EnemyDied;
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

            Destroy(this.gameObject);

        }


    }

    public void EnemyDied()
    {
        StartCoroutine(EnemyDissolve());

    }
}
