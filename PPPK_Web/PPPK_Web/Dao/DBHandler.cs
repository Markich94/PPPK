using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using PPPK_Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PPPK_Web.Dao
{
    public static class DBHandler
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        private static SqlDatabase db = new SqlDatabase(cs);

        internal static IEnumerable<PutniNalog> GetPutniNalozi()
        {
            using (IDataReader dr = db.ExecuteReader(CommandType.StoredProcedure, nameof(GetPutniNalozi)))
            {
                while (dr.Read())
                {
                    yield return new PutniNalog
                    {
                        IDPutniNalog = (int)dr[nameof(PutniNalog.IDPutniNalog)],
                        VozacID = (int)dr[nameof(PutniNalog.VozacID)],
                        VoziloID = (int)dr[nameof(PutniNalog.VoziloID)],
                        Tip = dr[nameof(PutniNalog.Tip)].ToString(),
                        KoordinataA = dr[nameof(PutniNalog.KoordinataA)].ToString(),
                        KoordinataB = dr[nameof(PutniNalog.KoordinataB)].ToString(),
                        PrijedeniKilometri = (int)dr[nameof(PutniNalog.PrijedeniKilometri)],
                        ProsjecnaBrzina = (int)dr[nameof(PutniNalog.ProsjecnaBrzina)],
                        PotrosenoGorivo = (int)dr[nameof(PutniNalog.PotrosenoGorivo)]
                    };
                }
            }
        }

        internal static PutniNalog SelectNalog(int idNalog)
        {
            DataSet ds = db.ExecuteDataSet(MethodBase.GetCurrentMethod().Name, idNalog);
            DataRow dr = ds?.Tables?[0]?.Rows?[0];
            return dr != null ? new PutniNalog
            {
                IDPutniNalog = (int)dr[nameof(PutniNalog.IDPutniNalog)],
                VozacID = (int)dr[nameof(PutniNalog.VozacID)],
                VoziloID = (int)dr[nameof(PutniNalog.VoziloID)],
                Tip = dr[nameof(PutniNalog.Tip)].ToString(),
                KoordinataA = dr[nameof(PutniNalog.KoordinataA)].ToString(),
                KoordinataB = dr[nameof(PutniNalog.KoordinataB)].ToString(),
                PrijedeniKilometri = (int)dr[nameof(PutniNalog.PrijedeniKilometri)],
                ProsjecnaBrzina = (int)dr[nameof(PutniNalog.ProsjecnaBrzina)],
                PotrosenoGorivo = (int)dr[nameof(PutniNalog.PotrosenoGorivo)]
            } : null;
        }

        internal static int InsertNalog(PutniNalog nalog) => db.ExecuteNonQuery(MethodBase.GetCurrentMethod().Name, nalog.VozacID, nalog.VoziloID, nalog.Datum, nalog.KoordinataA, nalog.KoordinataB);

        internal static int UpdateNalog(PutniNalog nalog, int idNalog) => db.ExecuteNonQuery(MethodBase.GetCurrentMethod().Name, idNalog, nalog.VozacID, nalog.VoziloID, nalog.Datum, nalog.Tip, nalog.KoordinataA, nalog.KoordinataB, nalog.PrijedeniKilometri, nalog.ProsjecnaBrzina, nalog.PotrosenoGorivo);

        internal static int DeleteNalog(int idNalog) => db.ExecuteNonQuery(MethodBase.GetCurrentMethod().Name, idNalog);
    }
}