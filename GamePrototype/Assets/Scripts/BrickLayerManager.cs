using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickLayerManager: MonoBehaviour {
    public GameObject brick;

    public int rows, columns;

    public float brickSpacing_h;
    public float brickSpacing_v;
   

    
    // Start is called before the first frame update
    void Start() {
	int Index = Random.Range (0, rows*columns); 
	int count = 0;

        for (int i = 0; i < columns; i++) {
            for (int j = 0; j < rows; j++) {
                float xPos = -columns + (i * brickSpacing_h);
                float yPos = rows - (j * brickSpacing_v);
                GameObject BrickX = Instantiate(brick, new Vector3(xPos, yPos, 0), transform.rotation);

				if (count == Index){
            		BrickX.GetComponent<SpriteRenderer>().color = Color.purple;
					BrickScript Nx = BrickX.GetComponent<BrickScript>();
					Nx.Special = true;
}

        		count++;


            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
