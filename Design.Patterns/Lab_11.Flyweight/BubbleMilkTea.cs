using System;

namespace Lab_11.Flyweight
{
    public class BubbleMilkTea : IBeverage
    {
        public BubbleMilkTea()
        {
            Console.WriteLine("��������� �� ��������� ��� � �����");
        }

        public void Drink()
        {
            Console.WriteLine("�����... ���� � ��������� ��� � �����");
        }
    }
}