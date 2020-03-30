using System;

namespace Lab_23.Visitor
{
    public class BedroomVisitor: IUnitVisitor
    {
        public void Visit(Unit bedroom)
        {
            if (bedroom.GetType() == typeof(Bedroom))
            {
                Console.WriteLine("���� � ����: " + bedroom.ToString());
            }
        }
    }
}