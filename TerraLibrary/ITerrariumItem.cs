namespace TerraLibrary
{
    public interface ITerrariumItem
    {
        /* Properties */
        char DisplayLetter
        {
            get;
        }
        int posX
        {
            get;
            set;
        }
        int posY
        {
            get;
            set;
        }
        ITerrariumItem[,] TerrariumItems
        {
            get;
            set;
        }

    }
}
