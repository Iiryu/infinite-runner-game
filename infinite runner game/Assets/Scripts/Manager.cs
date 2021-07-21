using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public List<GameObject>easy = new List<GameObject>();
    public List<GameObject>normal = new List<GameObject>();
    public List<GameObject> hard = new List<GameObject>();
    public List<Material> materials = new List<Material>();
    public List<float> types = new List<float>();
    public GameObject player,gameOverObj;
    public Vector3 pVec;
    public bool z6,z10,z13,z31;
    public float z6i,z10i,z13i,z31i;
    public bool random;
    public Text count;
    public Text last;
    public bool gameOver = false;
    public float score;
    Player p;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        z6 = false;
        z10 = false;
        z13 = false;
        z31 = false;
        z6i = 6f;
        z10i = 10f;
        z13i = 13f;
        z31i = 31f;
        p = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        pVec = player.transform.position;
        Z6();
        Z10();
        Z13();
        Z31();
        Random1();
        SetText();
        GameOver();

        if(z6 == true)
        {
            SetEasy();
            z6 = false;
        }
        if (z13 == true)
        {
            SetNormal();
            z13 = false;
        }
        if (z31 == true)
        {
            SetHard();
            z31 = false;
        }


    }

    void GameOver()
    {
        if(gameOver == true)
        {
            Cursor.visible = true;
            count.gameObject.SetActive(false);
            gameOverObj.SetActive(true);
        }
    }

    public void Restart()
    {
        Cursor.visible = false;
        SetFirst();
        p.stop = false;
        Debug.Log("restart");
        gameOver = false;
        count.gameObject.SetActive(true);
        gameOverObj.SetActive(false);
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Obstacle");
        z6i = 0f;
        z10i = 0f;
        z13i = 0f;
        z31i = 0f;
        foreach (GameObject wall in walls)
        {
            Destroy(wall);
        }
    }

    void SetText()
    {
        score = z10i / 10;
       
        count.text = score.ToString();
        last.text = score.ToString();
    }

    void SetFirst()
    {
        GameObject a = Instantiate(easy[Random.Range(0, easy.Count - 1)], new Vector3(Random.Range(-4.5f, 4.5f), 0, 20 + z6i), Quaternion.identity);
        GameObject b = Instantiate(normal[Random.Range(0, normal.Count - 1)], new Vector3(Random.Range(-2.5f, 2.5f), 0, 20 + z13i), Quaternion.identity);
        GameObject c = Instantiate(hard[Random.Range(0, hard.Count - 1)], new Vector3(Random.Range(-3f, 3f), 0, 20 + z31i), Quaternion.identity);
    }

    void SetEasy()
    {
        if (random == true)
        {
            GameObject g = Instantiate(easy[Random.Range(0, easy.Count - 1)], new Vector3(Random.Range(-4.5f, 4.5f), 0, 30 + z6i), Quaternion.identity);
            if(g != null)
            {
                g.GetComponentInChildren<Renderer>().material = materials[Random.Range(0, materials.Count - 1)];
            }
            if(gameOver == true)
            {
                Destroy(g);
            }
        }
    }

    void SetNormal()
    {
        GameObject g = Instantiate(normal[Random.Range(0, normal.Count - 1)], new Vector3(Random.Range(-2.5f, 2.5f), 0, 20 + z13i), Quaternion.identity);
        if (g != null)
        {
            g.GetComponentInChildren<Renderer>().material = materials[Random.Range(0, materials.Count - 1)];
        }
        if (gameOver == true)
        {
            Destroy(g);
        }
    }

    void SetHard()
    {
        GameObject g = Instantiate(hard[Random.Range(0, hard.Count - 1)], new Vector3(Random.Range(-3f, 3f), 0, 30 + z31i), Quaternion.identity);
        if (g != null)
        {
            g.GetComponentInChildren<Renderer>().material = materials[Random.Range(0, materials.Count - 1)];
        }
        if (gameOver == true)
        {
            Destroy(g);
        }
    }

    void Random1()
    {
        int i = Random.Range(1, 2);
        if (i == 1)
        {
            random = true;
        }
        else
        {
            random = false;
        }
    }


    void Z6()
    {
        if (pVec.z >= z6i)
        {
            z6i += 6f;
            z6 = true;
        }
    }

    void Z10()
    {
        if (pVec.z >= z10i)
        {
            z10i += 10f;
            z6 = true;
        }
    }
    void Z13()
    {
        if (pVec.z >= z13i)
        {
            z13i += 13f;
            z13 = true;
        }
    }

    void Z31()
    {
        if (pVec.z >= z31i)
        {
            z31i += 31f;
            z31 = true;
        }
    }
}
