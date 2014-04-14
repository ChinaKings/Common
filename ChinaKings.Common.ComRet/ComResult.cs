using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinaKings.Common.ComRet
{
    public class ComResult
    {
        public bool Ret { get; set; }
        public string Msg { get; set; }
        public int ID { get; set; }
        public object Obj { get; set; }

        public ComResult() { Ret = true; }
        public ComResult(bool ret, object obj = null) { Ret = ret; Obj = obj; }
        public ComResult(bool ret, int id, object obj = null) { Ret = ret; ID = id; Obj = obj; }
        public ComResult(bool ret, string msg, object obj = null) { Ret = ret; Msg = msg; Obj = obj; }
        public ComResult(bool ret, int id, string msg, object obj = null) { Ret = ret; ID = id; Msg = msg; Obj = obj; }
    }
}
