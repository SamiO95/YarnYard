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

    IEnumerator EnemyDissolve()
    {
        if ( enemyRenderers != null)
        {
            float elapsedTime = Time.deltaTime;
            float dissolveTime = Time.deltaTime + dissolveDuration;
            while(elapsedTime < dissolveDuration) 
            {
                elapsedTime += Time.deltaTime;

                foreach(Renderer enemyPart in enemyRenderers)
                {
                    float lerpDissolve = Mathf.Lerp(0, 1f,(elapsedTime/dissolveTime));
                    enemyPart.material.SetFloat(dissolveAmount, lerpDissolve);                    
                }
                yield return null;
            }

            yield return new WaitForSeconds(dissolveDuration);
            
            gameObject.SetActive(false);

            foreach(Renderer enemyPart in enemyRenderers)
            {
                enemyPart.material.SetFloat(dissolveAmount, 1);
            }
        }
    }
}
