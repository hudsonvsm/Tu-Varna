using System;

namespace Lab_11.Flyweight
{
    public class FoamMilkTea : IBeverage
    {
        
        public FoamMilkTea()
        {
            Console.WriteLine("��������� �� ��� � ������ ����");
        }
        
        public void Drink()
        {
            Console.WriteLine("����... ���� � ��� � ������ ����");
        }
    }
}