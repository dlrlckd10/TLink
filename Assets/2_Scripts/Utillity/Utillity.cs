public class Utillity
{
    public enum Isdoll
    {
        INE = 0,
        JING,
        LiLL,
        JU,
        Go,
        VII,
        Max
    }
    public static string ConvertIsedollString(Utillity.Isdoll isdoll)
    {
        string str = string.Empty;

        switch (isdoll)
        {
            case Utillity.Isdoll.INE:
                str = "아이네";
                break;
            case Utillity.Isdoll.JING:
                str = "징버거";
                break;
            case Utillity.Isdoll.LiLL:
                str = "릴파";
                break;
            case Utillity.Isdoll.JU:
                str = "주르르";
                break;
            case Utillity.Isdoll.Go:
                str = "고세구";
                break;
            case Utillity.Isdoll.VII:
                str = "비챤";
                break;
        }
        return str;
    }

}
