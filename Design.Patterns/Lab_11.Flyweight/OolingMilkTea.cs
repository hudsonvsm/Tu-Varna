using System;

namespace Lab_11.Flyweight
{
    public class OolingMilkTea: IBeverage
    {

        public OolingMilkTea()
        {
            Console.WriteLine("��������� �� ����� ��� � �����");
        }

        public void Drink()
        {
            Console.WriteLine("�����... ���� � ����� ��� � �����");
        }
    }
}