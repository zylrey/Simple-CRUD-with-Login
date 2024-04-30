using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PST
{
    class usableFunction
    {
        public void ResponsiveDtg(DataGridView dtg)
        {
            dtg.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }
    }
}
