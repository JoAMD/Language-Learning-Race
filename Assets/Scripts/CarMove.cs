using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    private float speed = 0f;
    public float startTime = -200f;
    public bool first = true;
    private float timeElapsed = 0f;
    public RoadMoveNew1[] roads;
    public float roadInitialSpeed = 0;
    public bool orange = false, yellow = false;
    private float moveDist = 0.5f;
    public AudioClip carDoorClip, carStartClip;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = carDoorClip;
        source.Play();
        source.clip = carStartClip;
        source.PlayDelayed(3);
    }

    private void Update()
    {
        timeElapsed = Time.time - startTime;
        if (timeElapsed < 5f)
        {
            //deciding distance and direction according to correct and wrong answers
            if((!orange && yellow) || (orange && !yellow))
            {
                moveDist = 0.25f;
            }
            else if(!orange && !yellow)
            {
                moveDist = 0f;
            }
            else
            {
                moveDist = 0.5f;
            }


            if (!orange && gameObject.name.Equals("Orange Lambo") || !yellow && gameObject.name.Equals("Yellow Lambo"))
            {

                //Inverting direction for false answer
                moveDist *= -1;

                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-moveDist, 0, 0), speed * Time.deltaTime);
                if (timeElapsed <= 0.25f)
                {
                    speed = 20f * timeElapsed;
                }
                else if (5f - timeElapsed <= 3.5f)
                {
                    /*
                    if (first)
                    {
                        roadInitialSpeed = roads[0].speed;
                        first = false;                                  //Abstract the numbers
                                                                        //Add such that its easy to change the duration and speed with change of a variable
                                                                        //Put each in functions namely roadMove(), orangeCarMove(), yellow.. etc

                    }
                    if (orange && yellow)
                    {
                        for (int i = 0; i < roads.Length; i++)
                        {
                            roads[i].speed = roadInitialSpeed + ((5f / 3.5f) * (timeElapsed - 1.5f));
                        }
                    }
                    */
                    speed = 5f / 3.5f * (5f - timeElapsed);
                    /*if(Mathf.Approximately(10f*(5f - timeElapsed), 35f))
                    {
                        Debug.Log("in");
                        first = true;
                        timeElapsed = 1.4f;
                    }*/
                }
                else
                {
                    //first = true;
                }

                timeElapsed = Time.time - startTime;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-moveDist, 0, 0), speed * Time.deltaTime);
                if (timeElapsed <= 0.25f)
                {
                    speed = 20f * timeElapsed;
                }
                else if (5f - timeElapsed <= 3.5f)
                {
                    if (first)
                    {
                        roadInitialSpeed = roads[0].speed;
                        first = false;                                  //Abstract the numbers
                                                                        //Add such that its easy to change the duration and speed with change of a variable
                                                                        //Put each in functions namely roadMove(), orangeCarMove(), yellow.. etc

                    }
                    if(orange && yellow)
                    {
                        for (int i = 0; i < roads.Length; i++)
                        {
                            roads[i].speed = roadInitialSpeed + ((5f / 3.5f) * (timeElapsed - 1.5f));
                        }
                    }
                    speed = 5f / 3.5f * (5f - timeElapsed);
                    /*if(Mathf.Approximately(10f*(5f - timeElapsed), 35f))
                    {
                        Debug.Log("in");
                        first = true;
                        timeElapsed = 1.4f;
                    }*/
                    }
                else
                {
                    first = true;
                }

                timeElapsed = Time.time - startTime;
            }
        }
    }
            
    

        private void roadMove()
        {
            //if (timeElapsed < 1.5f) // in update 
            for (int i = 0; i < roads.Length; i++)
            {
                roads[i].speed = roadInitialSpeed + ((5f / 1.5f) * timeElapsed);
            }
            timeElapsed = Time.time - startTime;
        }
    }
          /*
           * timeElapsed = Time.time - startTime;
                  if (timeElapsed < 5f)
                  {
                      transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-1, 0, 0), speed * Time.deltaTime);
                      if (timeElapsed <= 0.25f)
                      {
                          speed = 20f * timeElapsed;
                      }
                      else if (5f - timeElapsed <= 3.5f)
                      {
                          if (first)
                          {
                              roadInitialSpeed = roads[0].speed;
                              first = false;                                  //Abstract the numbers
                                                                              //Add such that its easy to change the duration and speed with change of a variable
                                                                              //Put each in functions namely roadMove(), orangeCarMove(), yellow.. etc

                          }
                          for (int i = 0; i < roads.Length; i++)
                          {
                              roads[i].speed = roadInitialSpeed + ((5f / 3.5f) * (timeElapsed - 1.5f));
                          }
                          speed = 5f / 3.5f * (5f - timeElapsed);
                          /*if(Mathf.Approximately(10f*(5f - timeElapsed), 35f))
                          {
                              Debug.Log("in");
                              first = true;
                              timeElapsed = 1.4f;
                          }*/
                /*      }
                      else
                      {
                          first = true;
                      }

                      timeElapsed = Time.time - startTime;
                  }
              */

/*
 * 
 * 
timeElapsed = Time.time - startTime;
    if (timeElapsed < 2f)
    {
        transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-1, 0, 0), speed * Time.deltaTime);
        if (timeElapsed <= 0.5f)
        {
            speed = 25f * timeElapsed;
        }
        else if (timeElapsed >= 1.5f && timeElapsed <=2f)
        {
            if (first)
            {
                roadInitialSpeed = roads[0].speed;
                first = false;                                  //Abstract the numbers
                                                                //Add such that its easy to change the duration and speed with change of a variable
                                                                //Put each in functions namely roadMove(), orangeCarMove(), yellow.. etc

            }
            for (int i = 0; i < roads.Length; i++)
            {
                roads[i].speed = roadInitialSpeed + ((5f / (3.5f)) * (timeElapsed - 1.5f));
            }
            speed = (5f / (5f - 1.5f)) * (5f - timeElapsed);
            /*if(Mathf.Approximately(10f*(5f - timeElapsed), 35f))
            {
                Debug.Log("in");
                first = true;
                timeElapsed = 1.4f;
            }*/
/*      }
      else
      {
          first = true;
      }

      timeElapsed = Time.time - startTime;

*/
      