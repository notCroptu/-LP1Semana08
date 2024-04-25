namespace AnimalKingdom
{
    public class Bat : Animal, IMammal, ICanFly
    {
        public int NumberOfWings { get; } = 2;
        public int NumberOfNipples { get; } = 2;
        public override string Sound()
        {
            return base.Sound() + "<Click>";
        }
    }
}
