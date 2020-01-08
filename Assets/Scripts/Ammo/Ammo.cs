using System;

public class Ammo : Item
{
    string name;
    float amount;
    Vector3 position;
    
    public Ammo(string name, Vector3 position, float amount)
    {
        this.name = name;
        this.position = position;
        this.amount = amount;
    }

}
