using System;

namespace Lab_07.Bridge
{
    public class FlyingEnchantment : IEnchantment
    {
        public void OnActivate()
        {
            Console.WriteLine("��������� ������� �� ����� �����.");
        }

        public void Apply()
        {
            Console.WriteLine("��������� ���� � ���� ���������, ���� ������ �� ����� � ������ �� �����������.");
        }

        public void OnDeactivate()
        {
            Console.WriteLine("�������� �� �������� ����������.");
        }
    }
}