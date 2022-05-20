using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.UI;

public class CountDown_Start : MonoBehaviour
{

  public float cntdnw = 3.0f; //Kanske behöver setter
  public bool timerIsRunning = true; //Kanske behöver setter
  public Text disvar;
  public GameObject player2;
  public GameObject player1;

  public void Start(){
    
     Update();
        player2.SetActive(false);
        player1.SetActive(false);
    }

  public void Update() { 


  if(timerIsRunning){
    if(cntdnw > 0){
      cntdnw -= Time.deltaTime;
      DisplayTime(cntdnw);
    }
    else{
      cntdnw = 0;
      timerIsRunning = false;
      disvar.text = "";
    }
  }
    
  if (cntdnw < 0.5){
            player2.SetActive(true);
            player1.SetActive(true);
            disvar.text = "GO!";
  }
  if(cntdnw == 0){
    disvar.text = "";
  }
  

  void DisplayTime(float currentTime){
    currentTime +=1;
    double b = System.Math.Round (currentTime, 2);
    int converted = (int) b;
    disvar.text = converted.ToString();
  }

  void setBool(bool time){
    timerIsRunning = time;
  }

  void setCount(float count){
    cntdnw = count;
  }
}
}
