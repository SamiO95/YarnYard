using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    List<GameObject> characters = new List<GameObject>();

    private List<GameObject> WithinRange(Transform c, float r) 
    {
        List<GameObject> charInRange= new List<GameObject>();

        foreach (GameObject chr in characters)
        {
            Vector3 vectorToTarget = new Vector3(chr.transform.position.x - c.transform.position.x, transform.position.y, chr.transform.position.z - c.transform.position.z);

            float distance = Mathf.Sqrt(vectorToTarget.x * vectorToTarget.x + vectorToTarget.z * vectorToTarget.z);

            if (distance < r) 
            {
                charInRange.Add(chr);
            }
        }

        return charInRange;

    }

    public void AddCharacter(GameObject chr) 
    {
        characters.Add(chr);
    }

}
