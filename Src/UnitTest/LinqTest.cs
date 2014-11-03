using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC.Product.TestWebsite;
using CC.Product.TestWebsite.Controllers;
using CC.Product.TestWebsite.Models;
using Xunit;

namespace UnitTest
{
    public class LinqTest
    {
        [Fact]
        public void test()
        {
            using (var db = new JGXTContext())
            {
                var node = from b in db.GZWCQCZRs
                           from c in db.GZWCQQies.Where(s1=>s1.QY_QYDM == b.CZR_QYDM).DefaultIfEmpty()
                           from t1 in db.GZWCQCZRQKFLs.Where(s2=>s2.CZRQKFL_QYDM == b.CZR_QYDM && s2.CZRQKFL_CZRDM ==c.QY_SJQYDM ).DefaultIfEmpty() //on new { JoinProperty1 = b.CZR_QYDM, JoinProperty2 = c.QY_SJQYDM } equals new { JoinProperty1 = t1.CZRQKFL_QYDM, JoinProperty2 =t1.CZRQKFL_CZRDM }
                           where b.CZR_FJNM.StartsWith("000100010002")
                           select new OrgNode
                           {
                               id = b.CZR_QYDM,
                               name = c.QY_QYMC.Trim().Length > 16 ? c.QY_QYMC.Trim().Substring(0, 15) + "<br><span>...</span>" : c.QY_QYMC.Trim(),
                               parentId = c.QY_SJQYDM,
                               isParent = b.CZR_MX == 1 ? false : true,
                               FJNM = b.CZR_FJNM,
                               //level = b.CZR_JC.HasValue?b.CZR_JC.Value.ToString():"",
                               Type = c.GZWCQQY_QYLB
                               //GQBL = t1.CZRQKFL_GQBL,
                               //TZJE = t1.CZRQKFL_TZJE
                           };
                var orgNodes = node.ToList();
            }
        }
    }
}
