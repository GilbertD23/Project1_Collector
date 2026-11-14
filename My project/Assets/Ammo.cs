using System;

public class Ammo
{
    public int Max { get; private set; }
    public int Current { get; private set; }
    public bool IsEmpty { get { return Current <= 0; } }

    public event Action Emptied;

    public Ammo(int max)
    {
        Max = max;
        Current = max;
    }

    public bool TryFire()
    {
        if (IsEmpty) return false;
        Current -= 1;
        if (IsEmpty && Emptied != null) Emptied();
        return true;
    }

    public void Reload()
    {
        Current = Max;
    }
}