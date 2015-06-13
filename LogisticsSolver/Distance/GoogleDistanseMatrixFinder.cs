using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace LogisticsSolver.Distance
{
    public class GoogleDistanseMatrixFinder
    {
        public static GoogleDistanseMatrixResponse GetDistanseMatrixResponse(Tuple<double,double,int>[] points)
        {
            const string key = "AIzaSyAFmKUPYnoLDxmJD5-jhOBoB5SbPwgGNws";
            const string url = "https://maps.googleapis.com/maps/api/distancematrix/json";
            const string lang = "uk-UK";
            const string mode = "driving";

            string origins = "";
            string destinations = "";
            var i = 0;
            for (; i < points.Length-1; i++)
            {   
                origins += string.Format("{0},{1}|", points[i].Item1, points[i].Item2);
                destinations += string.Format("{0},{1}|", points[i].Item1, points[i].Item2);
            }

            origins += string.Format("{0},{1}", points[i].Item1, points[i].Item2);
            destinations += string.Format("{0},{1}", points[i].Item1, points[i].Item2);

            var address = String.Format("{0}?origins={1}&destinations={2}&mode={3}&language={4}&key={5}", url, origins, destinations, mode, lang, key);

            var client = new WebClient { Encoding = Encoding.UTF8 };

            var result = client.DownloadString(address);


            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Deserialize<GoogleDistanseMatrixResponse>(result);
        }

        public static RouteChain[][] GetDistanseMatrix(Tuple<double, double, int>[] points)
        {
            var response = GetDistanseMatrixResponse(points);
            var count = response.Origin_Addresses.Length;
            var res = new RouteChain[count][];
            for (var i = 0; i < count; i++)
            {
                res[i] = new RouteChain[count];
            }

            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    res[i][j] = new RouteChain
                    {
                        Dist = response.Rows[i].Elements[j].Distance.Value,
                        From = points[i].Item3,
                        To = points[j].Item3
                    };
                }
            }

            return res;
        }
    }

    public class RouteChain
    {
        public int From { get; set; }
        public int To { get; set; }
        public int Dist { get; set; }
    }
}
