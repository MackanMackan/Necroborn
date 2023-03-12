using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexaMaker : MonoBehaviour
{
    [SerializeField] private int m_amountOfCorners;
    //[SerializeField] private int m_amountOfTiles;
    [SerializeField] private Vector2Int m_amountOfTiles = new Vector2Int(0,0);
    [SerializeField] private float m_hexaRadian;
    private List<Vector2> m_cornerPoints = new List<Vector2>();
    private const int k_degress = 360;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
       


        Gizmos.color = Color.red;
        int distanceBetweenCorners = k_degress / m_amountOfCorners;
        Vector3 startingPositon = transform.position;

        float calculatedDistanceBetweenTiles = m_hexaRadian * 2 - m_hexaRadian / Mathf.PI ;

        for (int x = 0; x < m_amountOfTiles.x; x++)
        {
            
           
            for (int y = 0; y < m_amountOfTiles.y; y++)
            {
                
                if (x % 2 == 1)
                {
                    Vector2 offsetPos = new Vector2(transform.position.x, transform.position.z - calculatedDistanceBetweenTiles/2);
                    startingPositon = new Vector3(offsetPos.x + calculatedDistanceBetweenTiles*.89f * x, transform.position.y, offsetPos.y + calculatedDistanceBetweenTiles*1.024f * y);
                    DrawTile(distanceBetweenCorners, startingPositon);
                }
                else
                {
                    startingPositon = new Vector3(transform.position.x + calculatedDistanceBetweenTiles*.89f * x, transform.position.y, transform.position.z + calculatedDistanceBetweenTiles * 1.024f * y);
                    DrawTile(distanceBetweenCorners, startingPositon);
                }
            }
        }
        //for (int i = 0; i < m_amountOfCorners; i++)
        //{
        //    float degForNewTile = (distanceBetweenCorners / 2) * (1 + 2 * i) * Mathf.Deg2Rad;
        //    float xPos = Mathf.Cos(degForNewTile);
        //    float yPos = Mathf.Sin(degForNewTile);

        //    for (int j = 0; j < m_amountOfTiles; j++)
        //    {
        //        startingPositon = new Vector3(transform.position.x + xPos * calculatedDistanceBetweenTiles * j, transform.position.y, transform.position.z + yPos * calculatedDistanceBetweenTiles * j);
        //        DrawTile(distanceBetweenCorners, startingPositon);
        //    }

        //    degForNewTile = (distanceBetweenCorners / 2) * 2 * i * Mathf.Deg2Rad;
        //    xPos = Mathf.Cos(degForNewTile);
        //    yPos = Mathf.Sin(degForNewTile);

        //    for (int j = 0; j < m_amountOfTiles; j++)
        //    {
        //        startingPositon = new Vector3(transform.position.x + xPos * calculatedDistanceBetweenTiles * 2 * j, transform.position.y, transform.position.z + yPos * calculatedDistanceBetweenTiles * 2 * j);
        //        DrawTile(distanceBetweenCorners, startingPositon);
        //    }

        //}



        //for (int j = 0; j < m_amountOfCorners*2; j++)
        //{
        //    degForNewTile = j == 0 ? distanceBetweenCorners / 2 : (distanceBetweenCorners / 2) * j * Mathf.Deg2Rad;
        //    xPos = Mathf.Cos(degForNewTile);
        //    yPos = Mathf.Sin(degForNewTile);

        //    float multiplier = j%2 == 1 ? 4 : 2;
        //    multiplier = j == 0 ? 0 : multiplier;

        //    startingPositon = new Vector3(transform.position.x + xPos * m_hexaRadian * multiplier, transform.position.y, transform.position.z + yPos * m_hexaRadian * multiplier);
        //    DrawTile(distanceBetweenCorners, startingPositon);
        //}

    }
    private void DrawTile(int distanceBetweenCorners, Vector3 startingPositon)
    {
        Transform myTransfrom = transform;

        float xRad = 0;
        float yRad = 0;


        for (int i = 0; i < m_amountOfCorners; i++)
        {
            float deg = distanceBetweenCorners * i * Mathf.Deg2Rad;
            xRad = Mathf.Cos(deg);
            yRad = Mathf.Sin(deg);

            m_cornerPoints.Add(new Vector2(xRad * m_hexaRadian, yRad * m_hexaRadian));
        }

        for (int i = 0; i < m_amountOfCorners; i++)
        {
            int nextSpot = i + 1 == m_amountOfCorners ? 0 : i + 1;
            Gizmos.DrawLine(new Vector3(m_cornerPoints[i].x + startingPositon.x, startingPositon.y, m_cornerPoints[i].y + startingPositon.z),
                new Vector3(m_cornerPoints[nextSpot].x + startingPositon.x, startingPositon.y, m_cornerPoints[nextSpot].y + startingPositon.z));
            Gizmos.DrawSphere(new Vector3(m_cornerPoints[i].x + startingPositon.x, startingPositon.y, m_cornerPoints[i].y + startingPositon.z), 0.1f);
        }
        m_cornerPoints.Clear();
    }
}
