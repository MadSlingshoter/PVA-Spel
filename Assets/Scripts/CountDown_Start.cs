using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.UI;

public class CountDown_Start : MonoBehaviour
{

float cntdnw = 4.0f;
public Text disvar;

void Start(){
    Update();
}

void Update() 
{ 
       
  if(cntdnw>0)     
  {         
    cntdnw -= Time.deltaTime;     
  }     
  double b = System.Math.Round (cntdnw, 2);
  int converted = (int) b;
  if(cntdnw>=1){   
  disvar.text = converted.ToString (); 
  }    
  if(cntdnw < 1)     
  {         
    disvar.text = "GO!"; 
  }
  
}
}
