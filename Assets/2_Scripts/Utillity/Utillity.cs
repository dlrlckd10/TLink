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
                str = "���̳�";
                break;
            case Utillity.Isdoll.JING:
                str = "¡����";
                break;
            case Utillity.Isdoll.LiLL:
                str = "����";
                break;
            case Utillity.Isdoll.JU:
                str = "�ָ���";
                break;
            case Utillity.Isdoll.Go:
                str = "����";
                break;
            case Utillity.Isdoll.VII:
                str = "��î";
                break;
        }
        return str;
    }

}
