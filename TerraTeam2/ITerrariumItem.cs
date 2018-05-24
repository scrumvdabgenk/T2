namespace TerraTeam2
{
    public interface ITerrariumItem
    {
        /* Properties */
        Position Position
        {
            get;
            set;
        }
        Terrarium Terrarium
        {
            get;
            set;
        }
        string Type
        {
            get;
            set;
        }
        
    }
}
