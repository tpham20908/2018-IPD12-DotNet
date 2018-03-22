using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoDBCustDlg
{
    public class Todo
    {
        public long Id { get; set; }
        public String Task { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; }
    }
}
