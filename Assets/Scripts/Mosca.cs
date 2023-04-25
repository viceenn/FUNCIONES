using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Mosca : MonoBehaviour
{
    Vector3 initialPosition;
    public bool hasKey;
    public int livesCount = 3;
    public TextMeshProUGUI txtlives;
    public TextMeshProUGUI txtPoints;
    public int Monedas;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        txtlives.text = "Vidas: "+ livesCount.ToString();
    }

    private void Update()
    {
        
    
        if (hasKey)
        {
            Debug.Log("Tiene la llave");
        }
        
        if (livesCount == 0)
        {
            Destroy(gameObject);
        }
    }


    //Destruir la mosca si colisiona con el ventilador
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damager"))
        {
            LoseALife();
        } 
        
        else if (collision.gameObject.CompareTag("Coin"))
        {
            ScorePoint();
            Destroy(collision.gameObject);
        } 
    }

    void LoseALife ()
    {
        transform.position = initialPosition;
        livesCount--;
        txtlives.text = "Vidas: "+ livesCount.ToString();

        if (livesCount <= 0)
        {
            PlayerDeath();
        }
    }

    void ScorePoint()
    {
        Monedas++;
        txtPoints.text = "Score: "+Monedas.ToString();
    }

    void PlayerDeath()
    {
        Destroy(gameObject);
    }
}
