using System;

namespace Lab_11.Flyweight
{
    public class CoconutMilkTea : IBeverage
    {
        public CoconutMilkTea()
        {
            Console.WriteLine("��������� �� ��� � �������� �����");
        }
        
        public void Drink()
        {
            Console.WriteLine("�����... ���� � ��� � �������� �����");
        }
    }
}