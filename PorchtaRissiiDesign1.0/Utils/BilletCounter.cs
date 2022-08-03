using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PochtaRossiiDesign1._0.Utils
{
    internal class BilletCounter
    {
        public static double[] BillCounts(double AllMoney)
        {
            double[] Banctotes = new double[8];

            Banctotes[0] = AllMoney / 5000;// 5000 купюры
            double Remain1 = AllMoney % 5000;

            Banctotes[1] = Remain1 / 2000;// 2000 купюры
            double Remain2 = Remain1 % 2000;

            Banctotes[2] = Remain2 / 1000;// 1000 купюры
            double Remain3 = Remain2 % 1000;

            Banctotes[3] = Remain3 / 500;// 500 купюры
            double Remain4 = Remain3 % 500;

            Banctotes[4] = Remain4 / 200;// 200 купюры
            double Remain5 = Remain4 % 200;

            Banctotes[5] = Remain5 / 100;// 100 купюры 
            double Remain6 = Remain5 % 100;

            Banctotes[6] = Remain6 / 50;// 50 купюры

            Banctotes[7] = Remain6 % 50;// остаток монет
            return Banctotes;
        }
    }
}
