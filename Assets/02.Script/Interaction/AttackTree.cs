using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AttackTree : MonoBehaviour, IFoxInteractable
{
    //�� �� ���� ����
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
        //����Ʈ �ʱ�ȭ �� ����
        UpdateFruitsList();
        Debug.LogWarning("����Ʈ ����");
    }
    void UpdateFruitsList()//���� ����Ʈȭ
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
        //��� fruit ����Ʈ
        List<Fruit> allFruits = new List<Fruit>(left);
        allFruits.AddRange(right);

        //right ����Ʈ���� mass�� ū 3�� ��������
        List<Fruit> massFruits = allFruits.OrderByDescending(fruit => fruit.mass).Take(3).ToList();

        //right����Ʈ�� ��� ���ԵǾ��ִ��� Ȯ��
        bool allInRight = massFruits.All(fruit => right.Contains(fruit));

        return allInRight;
    }
    public void Interaction(FoxInteraction obj)
    {
        //���� ������ �ȴٸ� Ȱ��ȭ
        if (!ShouldActivateInteraction())
        {
            Debug.Log("GŰ ��Ȱ��ȭ");
        }
        else if(ShouldActivateInteraction())
        {
            Debug.Log("GŰ Ȱ��ȭ");
            isFall = true;
        }
    }
    void FallTree()
    {
        if (fall > -90) //���� ��������
        {
            transform.Rotate(new Vector3(0f, 0f, fall) * Time.deltaTime);
        }
    }
}
