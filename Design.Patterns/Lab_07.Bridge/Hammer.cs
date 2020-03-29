using System;

namespace Lab_07.Bridge
{
    public class Hammer : IWeapon
    {
        private readonly IEnchantment _enchantment;
        public Hammer(IEnchantment enchantment)
        {
            _enchantment = enchantment;
        }

        public void Wield()
        {
            Console.WriteLine("����� � �������.");
            _enchantment.OnActivate();
        }

        public void Swing()
        {
            Console.WriteLine("����� � �����.");
            _enchantment.Apply();
        }

        public void Unwield()
        {
            Console.WriteLine("����� � �������.");
            _enchantment.OnDeactivate();
        }

        public IEnchantment GetEnchantment()
        {
            return _enchantment;
        }
    }
}