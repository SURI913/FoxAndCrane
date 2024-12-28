using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AttackTree : MonoBehaviour, IFoxInteractable
{
    //좌 우 열매 무게
    public List<Fruit> left = new List<Fruit>();
    public List<Fruit> right = new List<Fruit>();
    [SerializeField]
    float fall;

    [SerializeField]
    bool isFall;
   

    void Start()
    {
        SubscribeToFruits();
        UpdateFruitsList();
    }
    void Update()
    {
        if (isFall)
        {
            FallTree();
        }
        if(Input.GetKeyDown(KeyCode.Escape))//
        {
            left.Clear();
            right.Clear();
        }
    }
    
    void SubscribeToFruits()
    {
        Fruit[] fruits = GetComponentsInChildren<Fruit>();
        foreach(Fruit fruit in fruits)
        {
            fruit.OnPositionChanged += OnFruitPoistionChanged;
        }
    }
    void OnFruitPoistionChanged(Fruit fruit)
    {
        //리스트 초기화 및 갱신
        UpdateFruitsList();
        Debug.LogWarning("리스트 갱신");
    }
    void UpdateFruitsList()//열매 리스트화
    {
        left.Clear();
        right.Clear();

        Fruit[] fruits = GetComponentsInChildren<Fruit>();
        foreach (Fruit fruit in fruits)
        {
            if(fruit.transform.position.x < 0)
            {
                left.Add(fruit);
            }
            else
            {
                right.Add(fruit);
            }
        }
    }
    bool ShouldActivateInteraction()
    {
        //모든 fruit 리스트
        List<Fruit> allFruits = new List<Fruit>(left);
        allFruits.AddRange(right);

        //right 리스트에서 mass가 큰 3개 가져오기
        List<Fruit> massFruits = allFruits.OrderByDescending(fruit => fruit.mass).Take(3).ToList();

        //right리스트에 모두 포함되어있는지 확인
        bool allInRight = massFruits.All(fruit => right.Contains(fruit));

        return allInRight;
    }
    public void Interaction(FoxInteraction obj)
    {
        //무게 조건이 된다면 활성화
        if (!ShouldActivateInteraction())
        {
            Debug.Log("G키 비활성화");
        }
        else if(ShouldActivateInteraction())
        {
            Debug.Log("G키 활성화");
            isFall = true;
        }
    }
    void FallTree()
    {
        if (fall > -90) //나무 쓰러지기
        {
            transform.Rotate(new Vector3(0f, 0f, fall) * Time.deltaTime);
        }
    }
}
